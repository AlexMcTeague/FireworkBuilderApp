using FireworkData;
using FireworkDomain;
using System.Data;

namespace FireworkDisplay {
    public partial class AddRocketForm : Form {
        FireworkContext _context = new FireworkContext();

        public AddRocketForm() {
            //Initialize the form according to the contents of the Designer class
            InitializeComponent();

            //Ensures the Color dropdown will include all the colors from the Color class
            colorBox.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();
        }

        private void speedBox_KeyPress(object sender, KeyPressEventArgs e) {
            //This event fires when a user types into the Speed field

            var tb = sender as System.Windows.Forms.TextBox;

            //Allows 0-9 and backspace. Limits entry to 3 digits
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void targetAltitudeBox_KeyPress(object sender, KeyPressEventArgs e) {
            //This event fires when a user types into the Target Altitude field

            var tb = sender as System.Windows.Forms.TextBox;

            //Allows 0-9 and backspace. Limits entry to 4 digits
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 4) {
                e.Handled = true;
                return;
            }
        }

        private void submitButton_Click(object sender, EventArgs e) {
            //This event fires when the user clicks the Save button on this Form

            Rocket rocket = new Rocket();
            bool valid = true;

            //Name
            rocket.Name = nameBox.Text;
            if (_context.Rockets.Where(r => r.Name == rocket.Name).ToList().Count > 0) {
                valid = false;
                Console.WriteLine($"ERROR: A Rocket with name \"{rocket.Name}\" already exists! Did not save new Rocket.");
            }

            //Speed
            int speed;
            if (int.TryParse(speedBox.Text, out speed)) {
                rocket.Speed = speed;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Speed is not an integer! Did not save new Rocket.");
            };

            //Target Altitude
            int alt;
            if (int.TryParse(targetAltitudeBox.Text, out alt)) {
                rocket.TargetAltitude = alt;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Target Altitude is not an integer! Did not save new Rocket.");
            };

            //Color
            rocket.TrailColor = Color.FromName(colorBox.Text);

            //If any errors were detected, the submit button won't close the window or save anything to the database
            if (valid) {
                _context.Rockets.AddAsync(rocket);
                _context.SaveChangesAsync();
                this.Close();
            }
        }
    }
}
