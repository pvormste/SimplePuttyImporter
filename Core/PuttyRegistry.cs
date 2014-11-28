using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePuttyImporter.Core
{
    class PuttyRegistry
    {
        public static List<String> GetSettings()
        {
            List<String> settingsList = new List<string>();
            string keyName = @"Software\SimonTatham\PuTTY\Sessions";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(keyName);

            foreach(var value in rk.GetSubKeyNames())
            {
                settingsList.Add(value);
            }

            rk.Close();

            return settingsList;
        }

        public static List<String> GetFingerprints()
        {
            List<String> fingerprintsList = new List<string>();
            string keyName = @"Software\SimonTatham\PuTTY\SshHostKeys";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(keyName);

            foreach (var value in rk.GetValueNames()) 
            {
                fingerprintsList.Add(value);
            }

            rk.Close();

            return fingerprintsList;
        }

        public static string GetFingerprint(string value)
        {
            string keyName = @"Software\SimonTatham\PuTTY\SshHostKeys";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(keyName);

            string fingerprint = rk.GetValue(value).ToString();

            rk.Close();

            return fingerprint;
        }

        public static string GetFingerprintKind(string value)
        {
            string keyName = @"Software\SimonTatham\PuTTY\SshHostKeys";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(keyName);

            string fingerprintKind = rk.GetValueKind(value).ToString();

            rk.Close();

            return fingerprintKind;
        }

        public static bool ExportSettings(String subkey, bool withFingerprint, string fingerprint)
        {
            string keyName = @"Software\SimonTatham\PuTTY\Sessions\"+subkey;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(keyName);
            bool exportResult = false;


            if(withFingerprint)
                exportResult = SettingsXML.CreateXML(rk, subkey, true, fingerprint);
            else
                exportResult = SettingsXML.CreateXML(rk, subkey, false, "");

            rk.Close();

            return exportResult;
        }
    }
}
