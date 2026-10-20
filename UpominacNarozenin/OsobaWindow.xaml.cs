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

using System.Windows;

namespace UpominacNarozenin
{
	/// <summary>
	/// Formulář k přidání nové osoby
	/// </summary>
	public partial class OsobaWindow : Window
	{
		/// <summary>
		/// Instance správce osob
		/// </summary>
		private readonly SpravceOsob spravceOsob;

		/// <summary>
		/// Získá správce osob
		/// </summary>
		/// <param name="spravceOsob">Správce osob</param>
		public OsobaWindow(SpravceOsob spravceOsob)
		{
			InitializeComponent();
			this.spravceOsob = spravceOsob;
		}

		/// <summary>
		/// Potvrzení formuláře
		/// </summary>
		/// <param name="sender">Tlačítko, které formulář potvrdilo.</param>
		/// <param name="e">Argumenty události kliknutí.</param>
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Správce provede validaci vstupu; při úspěchu se údaje uloží a dialog zavře.
				spravceOsob.Pridej(jmenoTextBox.Text, narozeninyDatePicker.SelectedDate);
				spravceOsob.Uloz();
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
		}
	}
}
