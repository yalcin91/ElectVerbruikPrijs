using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WPF_ElecVerbruik.Languages;
using System.Windows;
using System.Windows.Markup;
using System.Threading;
using System.Globalization;

namespace WPF_ElecVerbruik
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private App()
        {
            string nederlands = "nl-BE";
            //string engels = "en-US";
            Translations.Culture = new System.Globalization.CultureInfo(nederlands); // en-US
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(nederlands);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: "
            + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            // We zeggen hier dat de exception door ons afgehandeld is
            e.Handled = true;
        }
    }
}
