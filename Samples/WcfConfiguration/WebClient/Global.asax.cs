﻿using System;
using NConfig;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {

        static Global()
        {
            // This will simulate single core CPU so we can check how configuration substitution works on such systems.
            //System.Diagnostics.Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)1;

            // We need to initialize NConfigurator once per AppDomain. Static ctor works well for this purpose.
            NConfigurator.UsingFiles(@"~\Config\WebClientSvc.config",
                @"~\Config\Custom.config").SetAsSystemDefault();
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Precache app settings, and check that they are not frozen in nested pages.
            // This made to test selective NConfig AppSettings caching
            var defaultSettings = NConfigurator.Default.AppSettings;

        }

    }
}
