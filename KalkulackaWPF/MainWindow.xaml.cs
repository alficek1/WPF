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

namespace KalkulackaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void vypocitejButton_Click(object sender, RoutedEventArgs e)
        {
            // příprava proměnných
            string operace = operaceComboBox.Text;
            double cislo1 = double.Parse(cislo1TextBox.Text);
            double cislo2 = double.Parse(cislo2TextBox.Text);
            double vysledek = 0;

            // výpočet
            if (operace == "+")
                vysledek = cislo1 + cislo2;
            else if (operace == "-")
                vysledek = cislo1 - cislo2;
            else if (operace == "*")
                vysledek = cislo1 * cislo2;
            else if (operace == "/")
            {
                if (cislo2 != 0)
                    vysledek = cislo1 / cislo2;
                else
                    MessageBox.Show("Nulou nelze dělit");
            }
            vysledekTextBlock.Text = vysledek.ToString();
        }
    }
}