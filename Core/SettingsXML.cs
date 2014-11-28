using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimplePuttyImporter.Core
{
    class SettingsXML
    {
        public static bool CreateXML(RegistryKey rk, string settingsName)
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "  ";

            try
            {
                XmlWriter xmlWriter = XmlWriter.Create(Directory.GetCurrentDirectory() + @"\" + settingsName + ".xml", xmlSettings);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Settings");

                foreach(var value in rk.GetValueNames())
                {
                    RegistryValueKind rvk = rk.GetValueKind(value);

                    Console.WriteLine(value + " | " + rvk.ToString() + " | " + rk.GetValue(value).ToString());
                   // xmlWriter.WriteElementString(value, rk.GetValue(value).ToString());
                    xmlWriter.WriteStartElement(value);
                    xmlWriter.WriteAttributeString("type", rvk.ToString());

                    if(value == "ProxyUsername" || value == "ProxyPassword")
                        xmlWriter.WriteValue("");
                    else
                        xmlWriter.WriteValue(rk.GetValue(value).ToString());
  
                    xmlWriter.WriteEndElement();
                    xmlWriter.Flush();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);

                return false;
            }
            

            return true;
        }
    }
}
