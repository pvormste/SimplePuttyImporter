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

            return settingsList;
        }
    }
}
