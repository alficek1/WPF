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

namespace UpominacNarozenin
{
	/// <summary>
	/// Nastaví novou instanci osoby
	/// </summary>
	/// <param name="jmeno">Jméno</param>
	/// <param name="narozeniny">Datum narození</param>
	public class Osoba
	{
		/// <summary>
		/// Celé jméno osoby
		/// </summary>
		public string Jmeno { get; set; }

		/// <summary>
		/// Datum narození
		/// </summary>
		public DateTime Narozeniny { get; set; }

		/// <summary>
		/// Bezparametrický konstruktor kvůli deserializaci
		/// </summary>
		public Osoba()
		{
		}

		/// <summary>
		/// Nastaví novou instanci osoby
		/// </summary>
		/// <param name="jmeno">Jméno</param>
		/// <param name="narozeniny">Datum narození</param>
		public Osoba(string jmeno, DateTime narozeniny) 
		{
			Jmeno = jmeno;
			Narozeniny = narozeniny;
		}

		/// <summary>
		/// Věk osoby
		/// </summary>
		public int Vek
		{
			get
			{
				DateTime dnes = DateTime.Today;
				int vek = dnes.Year - Narozeniny.Year;
				if (dnes < Narozeniny.AddYears(vek))
					vek--;
				return vek;
			}
		}

		/// <summary>
		/// Kolik dní zbývá do příštích narozenin
		/// </summary>
		public int ZbyvaDni
		{
			get
			{
				DateTime dalsiNarozeniny = Narozeniny.AddYears(Vek + 1);

				TimeSpan rozdil = dalsiNarozeniny - DateTime.Today;

				return Convert.ToInt32(rozdil.TotalDays);
			}
		}

		/// <summary>
		/// Vrátí textovou reprezentaci osoby
		/// </summary>
		/// <returns>textová reprezentace osoby</returns>
		public override string ToString()
		{
			return Jmeno;
		}
	}
}
