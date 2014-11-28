using SimplePuttyImporter.Core;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SimplePuttyImporter
{
    /// <summary>
    /// Interaction logic for ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnExport_Clicked(object sender, RoutedEventArgs e)
        {
            PuttyRegistry.ExportSettings(SettingsBox.SelectedItem.ToString());
        }
    }
}
