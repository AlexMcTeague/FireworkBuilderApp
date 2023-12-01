using FireworkData;
using FireworkDisplay;
using System.Windows.Forms;

namespace FireworkConsole {
    internal class Program {
        [STAThread]
        static void Main() {
            //This console is mostly vestigial, however it is still used to display some error messages

            FireworkContext _context = new FireworkContext();
            //ensureSeeded is only necessary on the first run to create and seed the database
            _context.ensureSeeded();

            //Set up the Draw Form Window, where most of the logic is controlled
            //DrawForm can be accessed by right clicking it in the Solution View and selecting "View Code"
            ApplicationConfiguration.Initialize();
            Application.Run(new DrawForm());
        }
    }
}