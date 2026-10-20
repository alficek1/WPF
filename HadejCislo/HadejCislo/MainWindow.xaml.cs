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

/*  _____ _______         _                      _
     * |_   _|__   __|       | |                    | |
     *   | |    | |_ __   ___| |___      _____  _ __| | __  ___ ____
     *   | |    | | '_ \ / _ \ __\ \ /\ / / _ \| '__| |/ / / __|_  /
     *  _| |_   | | | | |  __/ |_ \ V  V / (_) | |  |   < | (__ / /
     * |_____|  |_|_| |_|\___|\__| \_/\_/ \___/|_|  |_|\_(_)___/___|
     *                                _
     *              ___ ___ ___ _____|_|_ _ _____
     *             | . |  _| -_|     | | | |     |  LICENCE
     *             |  _|_| |___|_|_|_|_|___|_|_|_|
     *             |_|
     *
     * IT ZPRAVODAJSTVÍ  <>  PROGRAMOVÁNÍ  <>  HW A SW  <>  KOMUNITA
     *
     * Tento zdrojový kód je součástí výukových seriálů na
     * IT sociální síti WWW.ITNETWORK.CZ
     *
     * Kód spadá pod licenci prémiového obsahu a vznikl díky podpoře
     * našich členů. Je určen pouze pro osobní užití a nesmí být šířen.
     * Více informací na http://www.itnetwork.cz/licence
     */


namespace HadejCislo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly Random ramdom;

		List<int> hadaneHodnoty;
		int maxHodnota = 0;
		int pokus = 0;
		int hledanaHodnota;
		int hadanaHodnota;

		public MainWindow()
		{
			ramdom = new Random();

			InitializeComponent();
		}

		private void Zacit_Click(object sender, RoutedEventArgs e)
		{
			hadaneHodnoty = [];
			maxHodnota = int.Parse(maxHodnotaComboBox.Text);
			tipTextBox.Text = "";
			mensiVetsiTextBlock.Text = "Myslím si nové číslo";
			hledanaHodnota = ramdom.Next(0, maxHodnota + 1);
			pokus = 0;
		}

		private void Tipnout_Click(object sender, RoutedEventArgs e)
		{
			//ověření zadání
			if (maxHodnota == 0 || tipTextBox.Text == "")
				return;

			//ověření tipnuté hodnoty
			if (!int.TryParse(tipTextBox.Text, out hadanaHodnota))
				return;

			hadaneHodnoty.Add(hadanaHodnota);

			pokus++;

			if (hadanaHodnota > hledanaHodnota)
				mensiVetsiTextBlock.Text = "Hledané číslo je menší";
			else if (hadanaHodnota < hledanaHodnota)
				mensiVetsiTextBlock.Text = "Hledané číslo je větší";
			else
			{
				//hadanaHodnota==HledanaHodnota, Uživatel tipl správně
				mensiVetsiTextBlock.Text = "";

				MessageBox.Show("UHODL JSI!" + "\n\nČíslo " + hledanaHodnota + " jsi uhodl na " + pokus + ". pokus"
					+ "\n\nTvé tipy: " + string.Join(" ", hadaneHodnoty));

				maxHodnota = 0;
			}

		}
	}
}