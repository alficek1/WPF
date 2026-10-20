/*  _____ _______         _                      _
 * |_   _|__   __|       | |                    | |
 *   | |    | |_ __   ___| |___      _____  _ __| | __  ___ ____
 *   | |    | | '_ \ / _ \ __\ \ /\ / / _ \| '__| |/ / / __|_  /
 *  _| |_   | | | | |  __/ |_ \ V  V / (_) | |  |   < | (__ / /
 * |_____|  |_|_| |_|\___|\__| \_/\_/ \___/|_|  |_|\_(_)___/___|
 *
 *                      ___ ___ ___
 *                     | . |  _| . |  LICENCE
 *                     |  _|_| |___|
 *                     |_|
 *
 *    REKVALIFIKAČNÍ KURZY  <>  PROGRAMOVÁNÍ  <>  IT KARIÉRA
 *
 * Tento zdrojový kód je součástí profesionálních IT kurzů na
 * WWW.ITNETWORK.CZ
 *
 * Kód spadá pod licenci PRO obsahu a vznikl díky podpoře
 * našich členů. Je určen pouze pro osobní užití a nesmí být šířen.
 * Více informací na https://www.itnetwork.cz/licence
 */

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace UpominacNarozenin
{
	public class SpravceOsob : INotifyPropertyChanged
	{
		// Událost umožňuje WPF aktualizovat text s nejbližšími narozeninami.
		/// <summary>
		/// Událost změny vlastnosti
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Kolekce uložených osob
		/// </summary>
		public ObservableCollection<Osoba> Osoby { get; set; }

		/// <summary>
		/// Cesta k souboru s daty
		/// </summary>
		private readonly string cesta = "osoby.xml";

		/// <summary>
		/// Inicializuje instanci
		/// </summary>
		public SpravceOsob()
		{
			// Kolekce je inicializována hned, aby ji bylo možné bezpečně bindovat v XAML.
			Osoby = [];
		}

		/// <summary>
		/// Osoba s nejbližšími narozeninami
		/// </summary>
		public Osoba NejblizsiOsoba { get; set; }

		/// <summary>
		/// aktuální datum
		/// </summary>
		public static DateTime DnesniDatum
		{
			get
			{
				return DateTime.Now;
			}
		}

		/// <summary>
		/// Najde osobu s nejbližšími narozeninami
		/// </summary>
		/// <returns>Osoba s nejbližšími narozeninami</returns>
		private void NajdiNejblizsi()
		{
			// Vlastnost ZbyvaDni už zohledňuje věk a datum letošních narozenin.
			var serazeneOsoby = Osoby.OrderBy(o => o.ZbyvaDni);
			if (serazeneOsoby.Any())
				NejblizsiOsoba = serazeneOsoby.First();
			else
				NejblizsiOsoba = null;

			VyvolejZmenu("NejblizsiOsoba");
		}

		/// <summary>
		/// Vytvoří novou osobu a přidá ji do kolekce
		/// </summary>
		/// <param name="jmeno">Jméno osoby</param>
		/// <param name="datumNarozeni">Datum narození</param>
		/// <exception cref="ArgumentException"></exception>
		public void Pridej(string jmeno, DateTime? datumNarozeni)
		{
			// Kontroly držíme ve správci, aby platily pro všechny způsoby přidání osoby.
			if (jmeno.Length < 3)
				throw new ArgumentException("Jméno je příliž krátké");
			if (datumNarozeni == null)
				throw new ArgumentException("Nebylo zadané datum narození");
			if (datumNarozeni.Value.Date > DateTime.Today)
				throw new ArgumentException("Datum narození nesmí být v budoucnosti");

			Osoba osoba = new(jmeno, datumNarozeni.Value.Date);
			Osoby.Add(osoba);
			NajdiNejblizsi();
		}

		/// <summary>
		/// Odebere osobu z kolekce
		/// </summary>
		/// <param name="osoba">Osoba k odebrání</param>
		public void Odeber(Osoba osoba)
		{
			// ObservableCollection automaticky oznámí ListBoxu odstranění položky.
			Osoby.Remove(osoba);
			NajdiNejblizsi();
		}

		/// <summary>
		/// Vyvolá událost změny vlastnosti
		/// </summary>
		/// <param name="vlastnost">Název vlastnosti</param>
		protected void VyvolejZmenu(string vlastnost)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(vlastnost));
		}

		/// <summary>
		/// Uloží kolekci do souboru
		/// </summary>
		public void Uloz()
		{
			// XML soubor se ukládá do pracovního adresáře aplikace.
			XmlSerializer serializer = new(Osoby.GetType());
			using StreamWriter sw = new(cesta);
			serializer.Serialize(sw, Osoby);
		}

		/// <summary>
		/// Načte kolekci ze souboru
		/// </summary>
		public void Nacti()
		{
			// Pokud soubor ještě neexistuje, začínáme s prázdnou kolekcí.
			XmlSerializer serializer = new(Osoby.GetType());
			if (File.Exists(cesta))
			{
				using StreamReader sr = new(cesta);
				Osoby = (ObservableCollection<Osoba>)serializer.Deserialize(sr);
			}
			else
				Osoby = [];

			NajdiNejblizsi();
		}
	}
}
