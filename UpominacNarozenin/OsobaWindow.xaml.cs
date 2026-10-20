

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
