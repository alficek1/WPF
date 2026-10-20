using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace HadejCislo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Generátor náhodných čísel používaný pro výběr hledaného čísla.
		readonly Random ramdom;

		// Seznam všech hodnot, které už uživatel zadal.
		List<int> hadaneHodnoty;
		// Nejvyšší možné číslo v aktuální hře. Hodnota 0 znamená, že hra neběží.
		int maxHodnota = 0;
		// Počet pokusů v aktuální hře.
		int pokus = 0;
		// Číslo, které má uživatel uhodnout.
		int hledanaHodnota;
		// Poslední číslo zadané uživatelem.
		int hadanaHodnota;

		/// <summary>
		/// Inicializuje okno a vytvoří generátor náhodných čísel.
		/// </summary>
		public MainWindow()
		{
			ramdom = new Random();

			InitializeComponent();
		}

		private void Zacit_Click(object sender, RoutedEventArgs e)
		{
			// Zahodíme tipy z předchozí hry a načteme horní hranici rozsahu.
			hadaneHodnoty = [];
			maxHodnota = int.Parse(maxHodnotaComboBox.Text);

			// Připravíme uživatelské rozhraní pro novou hru.
			tipTextBox.Text = "";
			mensiVetsiTextBlock.Text = "Myslím si nové číslo";

			// Vygenerujeme číslo včetně hodnot 0 a maxHodnota.
			hledanaHodnota = ramdom.Next(0, maxHodnota + 1);
			pokus = 0;
		}

		private void Tipnout_Click(object sender, RoutedEventArgs e)
		{
			// Pokud hra nebyla spuštěna nebo je pole prázdné, nic neděláme.
			if (maxHodnota == 0 || tipTextBox.Text == "")
				return;

			// Ověříme, že uživatel zadal celé číslo.
			if (!int.TryParse(tipTextBox.Text, out hadanaHodnota))
				return;

			// Uložíme tip a zvýšíme počet pokusů.
			hadaneHodnoty.Add(hadanaHodnota);

			pokus++;

			// Porovnáme tip s hledaným číslem a zobrazíme nápovědu.
			if (hadanaHodnota > hledanaHodnota)
				mensiVetsiTextBlock.Text = "Hledané číslo je menší";
			else if (hadanaHodnota < hledanaHodnota)
				mensiVetsiTextBlock.Text = "Hledané číslo je větší";
			else
			{
				// Uživatel tipnul správné číslo, proto hru ukončíme.
				mensiVetsiTextBlock.Text = "";

				MessageBox.Show("UHODL JSI!" + "\n\nČíslo " + hledanaHodnota + " jsi uhodl na " + pokus + ". pokus"
					+ "\n\nTvé tipy: " + string.Join(" ", hadaneHodnoty));

				// Nulová horní hranice označuje ukončenou hru.
				maxHodnota = 0;
			}

		}
	}
}