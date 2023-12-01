using FireworkData;
using FireworkDomain;
using System.Data;

namespace FireworkDisplay {
    public partial class AddPayloadForm : Form {
        FireworkContext _context = new FireworkContext();

        public AddPayloadForm() {
            //Initialize the form according to the contents of the Designer class
            InitializeComponent();

            //Ensures the Shpae dropdown will include all values of the PayloadShape enum
            shapeBox.DataSource = Enum.GetValues(typeof(PayloadShape)).Cast<PayloadShape>();
            //Ensures the Color dropdown will include all the colors from the Color class
            colorBox.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();
        }

        private void sizeBox_KeyPress(object sender, KeyPressEventArgs e) {
            //This event fires when a user types into the Size field

            var tb = sender as System.Windows.Forms.TextBox;

            //Allows 0-9 and backspace. Limits entry to 3 digits
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void countBox_KeyPress(object sender, KeyPressEventArgs e) {
            //This event fires when a user types into the Particle Count field
            
            var tb = sender as System.Windows.Forms.TextBox;

            //Allows 0-9 and backspace. Limits entry to 3 digits
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void submitButton_Click(object sender, EventArgs e) {
            //This event fires when the user clicks the Save button on this Form

            Payload payload = new Payload();
            bool valid = true;

            //Name
            payload.Name = nameBox.Text;
            if (_context.Payloads.Where(p => p.Name == payload.Name).ToList().Count > 0) {
                valid = false;
                Console.WriteLine($"ERROR: A Payload with name \"{payload.Name}\" already exists! Did not save new Payload.");
            }

            //Shape
            PayloadShape shape;
            if (PayloadShape.TryParse(shapeBox.Text, out shape)) {
                payload.Shape = shape;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Shape is an invalid value! Did not save new Payload.");
            }

            //Size
            int size;
            if (int.TryParse(sizeBox.Text, out size)) {
                payload.Size = size;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Size is not an integer! Did not save new Payload.");
            };

            //Particle Count
            int count;
            if (int.TryParse(sizeBox.Text, out count)) {
                payload.particleCount = count;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Particle Count is not an integer! Did not save new Payload.");
            };

            //Color
            payload.Color = Color.FromName(colorBox.Text);

            //If any errors were detected, the submit button won't close the window or save anything to the database
            if (valid) {
                _context.Payloads.Add(payload);
                _context.SaveChanges();
                this.Close();
            }
        }
    }
}
