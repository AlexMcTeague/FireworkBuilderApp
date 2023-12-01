using FireworkData;
using FireworkDisplay;
using FireworkDomain;
using System.Drawing;
using System.Windows.Forms;

namespace FireworkConsole {
    internal class Program {
        [STAThread]
        static void Main() {
            FireworkContext _context = new FireworkContext();
            // ensureCreatedCustom is only necessary on the first run to create the database
            _context.ensureCreatedCustom();

            //Set up the Draw Form Window
            //DrawForm can be accessed by right clicking it in the Solution View and selecting "View Code"
            ApplicationConfiguration.Initialize();
            DrawForm f = new DrawForm();
            Application.Run(f);

        }
    }
}