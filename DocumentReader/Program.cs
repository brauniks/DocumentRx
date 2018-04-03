using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DocumentReader.BLL;
using DocumentReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentReader
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
            var container = new WindsorContainer();

            // Register the CompositionRoot type with the container
            container.Register(Component.For<IFile>().ImplementedBy<CsvFile>());
            container.Register(Component.For<IFileReader>().ImplementedBy<CsvFileReader>());

            Application.Run(new DocumentReader());
        }
    }
}
