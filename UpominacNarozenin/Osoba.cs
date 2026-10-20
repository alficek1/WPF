

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
				// Věk je nutné snížit, pokud letošní narozeniny ještě nenastaly.
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
				// AddYears zachovává den a měsíc a posune datum do dalšího roku.
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
