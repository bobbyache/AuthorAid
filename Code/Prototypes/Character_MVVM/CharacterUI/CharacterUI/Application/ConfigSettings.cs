using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CharacterUI.Application
{
    public static class ConfigSettings
    {
        private static string registryFolder;
        public static string RegistryPath
        {
            get
            {
                if (string.IsNullOrEmpty(registryFolder))
                    registryFolder = ConfigurationManager.AppSettings["RegistryPath"];

                return registryFolder;
            }
            set
            {
                ConfigurationManager.AppSettings["RegistryPath"] = value;
            }
        }

        private static string applicationTitle;
        public static string ApplicationTitle
        {
            get
            {
                if (string.IsNullOrEmpty(applicationTitle))
                    applicationTitle = ConfigurationManager.AppSettings["ApplicationTitle"];

                return applicationTitle;
            }
        }


        public static void Refresh()
        {
            registryFolder = ConfigurationManager.AppSettings["RegistryPath"];
            applicationTitle = ConfigurationManager.AppSettings["ApplicationTitle"];
        }

    }
}
