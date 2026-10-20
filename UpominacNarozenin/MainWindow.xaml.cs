
using System.Windows;

namespace UpominacNarozenin
{

	public partial class MainWindow : Window
	{
		/// <summary>
		/// Správce osob používaný datovými vazbami hlavního okna.
		/// </summary>
		private readonly SpravceOsob spravceOsob = new();
		

		/// <summary>
		/// Inicializuje okno, načte data a nastaví datový kontext.
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
			// Vazby v XAML používají správce jako datový kontext okna.
			DataContext = spravceOsob;
		}


		/// <summary>Otevře dialog pro přidání osoby.</summary>
		/// <param name="sender">Prvek, který událost vyvolal.</param>
		/// <param name="e">Argumenty události kliknutí.</param>
		private void PridatButton_Click(object sender, RoutedEventArgs e)
		{
			// Dialog předáme stejný správce, aby se změna ihned projevila v hlavním okně.
			OsobaWindow osobaWindow = new(spravceOsob);
			osobaWindow.ShowDialog();
		}


		/// <summary>Odebere právě vybranou osobu a uloží změny.</summary>
		/// <param name="sender">Prvek, který událost vyvolal.</param>
		/// <param name="e">Argumenty události kliknutí.</param>
		private void OdebratButton_Click(object sender, RoutedEventArgs e)
		{
			// Bez vybrané položky není možné určit osobu, kterou má aplikace odebrat.
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