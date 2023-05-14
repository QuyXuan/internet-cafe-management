using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIClient
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*string appName = "GUIClient";
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(appName, Application.ExecutablePath.ToString());*/
            CultureInfo culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLoginClient());
        }
    }
}
