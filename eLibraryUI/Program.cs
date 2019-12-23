using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;

namespace eLibraryUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            eLibraryClasses.GlobalConfig.InitializeConnections();

            Application.Run(new LibraryAccessForm());
        }
    }
}
