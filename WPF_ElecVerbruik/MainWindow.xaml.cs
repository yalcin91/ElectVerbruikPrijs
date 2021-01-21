using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using BusinessLayer.Model;

using WPF_ElecVerbruik.ModelWPF;
using WPF_ElecVerbruik.Verbinding;

namespace WPF_ElecVerbruik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LeverancierWPF LeverancierWPF ;
        private ObservableCollection<Leverancier> Leverancier;
        public MainWindow()
        {
            InitializeComponent();
            LeverancierWPF = new LeverancierWPF();
            Leverancier = new ObservableCollection<Leverancier>(Context.LeverancierManager.GetAllLeveranciers());
            dgOrderSelection.ItemsSource = Leverancier;
            Leverancier.CollectionChanged += Leverancier_CollectionChanged;
            Closing += MainWindow_Closing;
            LeverancierWPF.Closing += LeverancierWPF_Closing;
        }
        private void Leverancier_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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
            this.InitializeComponent();
        }

        #region Sluiten en Verbergen
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LeverancierWPF_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate (object o)
            {
                ((Window)sender).Hide();
                return null;
            }, null);
            e.Cancel = true;
        }
        private void MenuItem_Sluiten_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        #endregion

        private void MenuItem_Leveranciers_Click(object sender, RoutedEventArgs e)
        {
            if (LeverancierWPF != null) { LeverancierWPF.Show(); }
        }

        private void MenuItem_Berekening_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Statusbar_Tonen(object sender, MouseButtonEventArgs e)
        {

        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
