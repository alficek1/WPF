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
	/// hlavní formulář aplikace
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// Správce osob
		/// </summary>
		private readonly SpravceOsob spravceOsob = new();
		
		/// <summary>
		/// Inicializuje formulář
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			try
			{
				spravceOsob.Nacti();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			DataContext = spravceOsob;
		}

		/// <summary>
		/// Přidání osoby
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PridatButton_Click(object sender, RoutedEventArgs e)
		{
			OsobaWindow osobaWindow = new(spravceOsob);
			osobaWindow.ShowDialog();
		}

		/// <summary>
		/// Odebrání osoby
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OdebratButton_Click(object sender, RoutedEventArgs e)
		{
			if (osobyListBox.SelectedItem != null)
			{
				try
				{
					spravceOsob.Odeber((Osoba)osobyListBox.SelectedItem);
					spravceOsob.Uloz();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Chyba", MessageBoxButton.OK,MessageBoxImage.Error);
				}
			}
		}
	}
}