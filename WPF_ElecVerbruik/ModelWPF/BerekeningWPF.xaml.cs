using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BusinessLayer.Model;

using WPF_ElecVerbruik.Verbinding;

namespace WPF_ElecVerbruik.ModelWPF
{
    /// <summary>
    /// Interaction logic for BerekeningWPF.xaml
    /// </summary>
    public partial class BerekeningWPF : Window
    {
        private LeverancierWPF LeverancierWPF;
        private Berekening Berekening;
        public BerekeningWPF()
        {
            InitializeComponent();
            Berekening = new Berekening();
            LeverancierWPF = new LeverancierWPF();
            cbLeveranciers.ItemsSource = Context.LeverancierManager.GetAllLeveranciers().Select(x=> x.Naam);
        }

        private void btnBereken_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAantalUren.Text) ||
                string.IsNullOrEmpty(txtAantalDagen.Text) ||
                string.IsNullOrEmpty(txtAantalWattage.Text) ||
                string.IsNullOrEmpty(txtPrijsPerKwh.Text))
            {
                MessageBox.Show("Geef alle gegevens in");
                return;
            }
            btnBereken.IsEnabled = true;
            Berekening.Uren = int.Parse(txtAantalUren.Text);
            Berekening.Dagen = int.Parse(txtAantalDagen.Text);
            Berekening.VermogenInWatt = int.Parse(txtAantalWattage.Text);
            Berekening.PrijsPerKwh = decimal.Parse(txtPrijsPerKwh.Text);
            if(cbLeveranciers.SelectedItem != null)
            {
                string naam = cbLeveranciers.SelectedItem.ToString();
                txtPrijsPerKwh.Text = Context.LeverancierManager.GetAllLeveranciers().Where(x => x.Naam == naam).Select(x => x.PrijsKHW).FirstOrDefault().ToString();
            }
            txtbUitkomst.Text = $"Een vermogen van {Berekening.VermogenInWatt} watt die per dag ongeveer " +
                $"{Berekening.Uren} uren in verbruik is, heeft een totaal prijs van {Berekening.Formule()}\u20ac op " +
                $"{Berekening.Dagen} dagen totaal";
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtAantalUren.Text = null;
            txtAantalDagen.Text = null;
            txtAantalWattage.Text = null;
            txtPrijsPerKwh.Text = null;
        }

        private void txtPrijsPerKwh_KeyUp(object sender, KeyEventArgs e)
        {
            cbLeveranciers.SelectedItem = null;
            if (txtPrijsPerKwh.Text.ToCharArray(0, txtPrijsPerKwh.Text.Length).Contains('.'))
            {
                txtPrijsPerKwh.Text = txtPrijsPerKwh.Text.Remove(txtPrijsPerKwh.Text.Length - 1);
                txtPrijsPerKwh.Text += ",";
                txtPrijsPerKwh.SelectionStart = txtPrijsPerKwh.Text.Length;
            }
            if (!string.IsNullOrEmpty(txtAantalUren.Text) && 
                !string.IsNullOrEmpty(txtAantalDagen.Text) &&
                !string.IsNullOrEmpty(txtAantalWattage.Text) &&
                !string.IsNullOrEmpty(txtPrijsPerKwh.Text))
            {
                btnBereken.IsEnabled = true;
            }
            else btnBereken.IsEnabled = false;
        }

        private void txtPrijsPerKwh_KeyDown(object sender, KeyEventArgs e)
        {
            cbLeveranciers.SelectedItem = null;
            if (txtPrijsPerKwh.Text.ToCharArray(0, txtPrijsPerKwh.Text.Length).Contains('.'))
            {
                txtPrijsPerKwh.Text = txtPrijsPerKwh.Text.Remove(txtPrijsPerKwh.Text.Length - 1);
                txtPrijsPerKwh.Text += ",";
                txtPrijsPerKwh.SelectionStart = txtPrijsPerKwh.Text.Length;
            }
            if (!string.IsNullOrEmpty(txtAantalUren.Text) &&
                !string.IsNullOrEmpty(txtAantalDagen.Text) &&
                !string.IsNullOrEmpty(txtAantalWattage.Text) &&
                !string.IsNullOrEmpty(txtPrijsPerKwh.Text))
            {
                btnBereken.IsEnabled = true;
            }
            else btnBereken.IsEnabled = false;
        }
    }
}
