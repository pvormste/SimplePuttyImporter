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
            if(SettingsBox.SelectedIndex != -1)
            {
                string settingName = SettingsBox.SelectedItem.ToString();
                string fingerprint = "";

                if(FingerprintBox.IsEnabled && FingerprintBox.SelectedIndex != -1)
                {
                    fingerprint = FingerprintBox.SelectedItem.ToString();
                }
                else if (FingerprintBox.IsEnabled && FingerprintBox.SelectedIndex == -1) 
                {
                    MessageBox.Show("Please select a fingerprint!", "Error: No fingerprint selected", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (PuttyRegistry.ExportSettings(settingName, ChkBxFingerprint.IsEnabled, fingerprint))
                    MessageBox.Show("Successfully exported Settings to "+ settingName+".xml", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Unknown error on exporting!", "Unkown Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            MessageBox.Show("Please select a setting!", "Error: No setting selected", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ChkBxFingerprint_Checked(object sender, RoutedEventArgs e)
        {
            FingerprintBox.IsEnabled = !FingerprintBox.IsEnabled;
        }

    }
}
