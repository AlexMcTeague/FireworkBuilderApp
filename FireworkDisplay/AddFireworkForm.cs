using FireworkData;
using FireworkDomain;
using System.Data;

namespace FireworkDisplay {
    public partial class AddFireworkForm : Form {
        FireworkContext _context = new FireworkContext();

        public AddFireworkForm() {
            //Initialize the form according to the contents of the Designer class
            InitializeComponent();

            //Ensures the Rocket dropdown will include all the Rocket names from the database
            rocketBox.DataSource = _context.Rockets.Select(r => r.Name).ToArray();
            //Ensures the Payload CheckBoxList will include all the Payload names from the database
            payloadsChecklist.Items.AddRange(_context.Payloads.Select(p => p.Name).ToArray());
        }

        private void submitButton_Click(object sender, EventArgs e) {
            //This event fires when the user clicks the Save button on this Form

            Firework firework = new Firework();
            bool valid = true;

            //Name
            firework.Name = nameBox.Text;
            if (_context.Fireworks.Where(f => f.Name == firework.Name).ToList().Count > 0) {
                valid = false;
                Console.WriteLine($"ERROR: A Firework with name \"{firework.Name}\" already exists! Did not save new Firework.");
            }

            //Rocket
            firework.Rocket = _context.Rockets.Where(r => r.Name == rocketBox.Text).Single();
            
            //Payloads
            List<Payload> payloads = new List<Payload>();
            List<string> payloadsChecked = payloadsChecklist.CheckedItems.Cast<string>().ToList();
            foreach (string payload in payloadsChecked) {
                payloads.Add(_context.Payloads.Where(p => p.Name == payload).Single());
            }
            firework.Payloads = payloads;

            //If any errors were detected, the submit button won't close the window or save anything to the database
            if (valid) {
                _context.Fireworks.AddAsync(firework);
                _context.SaveChangesAsync();
                this.Close();
            }
        }
    }
}
