using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using eLibraryClasses;
using Autofac;
using Autofac.Diagnostics;
using eLibraryUI.Autofac_logic;

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

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IStartUp>();
                app.Run();
            }
        }
    }
}
