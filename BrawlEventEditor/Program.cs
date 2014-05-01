using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BrawlEventEditor
{
    static class Program
    {
        public static Brawl.DataFile<Brawl.Event> event_file = new Brawl.DataFile<Brawl.Event>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
