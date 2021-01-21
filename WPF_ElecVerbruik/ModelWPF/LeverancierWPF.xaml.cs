using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for LeverancierWPF.xaml
    /// </summary>
    public partial class LeverancierWPF : Window, INotifyPropertyChanged
    {
        #region For WPF interface INotifyProperyChanged
        // Deze code kan altijd in een class gecopieerd worden
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<Leverancier> LeveranciersOBS;

        public LeverancierWPF()
        {
            InitializeComponent();
            LeveranciersOBS = new ObservableCollection<Leverancier>(Context.LeverancierManager.GetAllLeveranciers());
            dgOrderSelection.ItemsSource = LeveranciersOBS;
            LeveranciersOBS.CollectionChanged += LeveranciersOBS_CollectionChanged;
        }

        private void LeveranciersOBS_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Leverancier p in e.OldItems) { Context.LeverancierManager.VerwijderLeveranciers(p); }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Leverancier p in e.NewItems)
                {
                    Context.LeverancierManager.VoegLeveranciers(p);
                }
            }
        }

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaam.Text) || string.IsNullOrEmpty(txtPrijsEuro.Text.ToString()) || 
                string.IsNullOrEmpty(txtMaatschappelijkeZetel.Text) || 
                string.IsNullOrEmpty(datepToekenningLeveringvergunning.SelectedDate.Value.ToString()) || 
                string.IsNullOrEmpty(datepPublicatiebeslissing.SelectedDate.Value.ToString()))
            {
                MessageBox.Show("Geef alle gegevens in");
                return;
            }
            var leverrancier = new Leverancier();
            leverrancier.Naam = txtNaam.Text;
            leverrancier.PrijsKHW = decimal.Parse(txtPrijsEuro.Text);
            leverrancier.MaatschappelijkeZetel = txtMaatschappelijkeZetel.Text;
            leverrancier.ToekenningLeveringvergunning =  datepToekenningLeveringvergunning.SelectedDate.Value;
            leverrancier.PublicatiebeslissingInBelGischStaatsblad =  datepPublicatiebeslissing.SelectedDate.Value;
            leverrancier.AutoTimeCreation = DateTime.Now;

            LeveranciersOBS.Add(leverrancier);
            //UpdateProduct?.Invoke(this, e);
            txtPrijsEuro.Text = null;
            txtNaam.Text = null;
        }

        private void txtb_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPrijsEuro.Text.ToCharArray(0, txtPrijsEuro.Text.Length).Contains('.'))
            {
                txtPrijsEuro.Text = txtPrijsEuro.Text.Remove(txtPrijsEuro.Text.Length - 1);
                txtPrijsEuro.Text += ",";
                txtPrijsEuro.SelectionStart = txtPrijsEuro.Text.Length;
            }
            if (!string.IsNullOrEmpty(txtNaam.Text) && !string.IsNullOrEmpty(txtPrijsEuro.Text.ToString()) &&
                !string.IsNullOrEmpty(txtMaatschappelijkeZetel.Text) &&
                !string.IsNullOrEmpty(datepToekenningLeveringvergunning.SelectedDate.ToString()) &&
                !string.IsNullOrEmpty(datepPublicatiebeslissing.SelectedDate.ToString()))
            {
                btnVoegToe.IsEnabled = true;
            }
            else btnVoegToe.IsEnabled = false;
        }

        private void dgProduct_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }    
    }
}
