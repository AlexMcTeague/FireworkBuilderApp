using FireworkData;
using FireworkDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FireworkDisplay {
    public partial class AddRocketForm : Form {
        public AddRocketForm() {
            InitializeComponent();
            colorBox.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();
        }

        private void speedBox_KeyPress(object sender, KeyPressEventArgs e) {
            var tb = sender as System.Windows.Forms.TextBox;

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void targetAltitudeBox_KeyPress(object sender, KeyPressEventArgs e) {
            var tb = sender as System.Windows.Forms.TextBox;

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 4) {
                e.Handled = true;
                return;
            }
        }

        private void colorBox_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            if (e.Index >= 0) {
                var txt = colorBox.GetItemText(colorBox.Items[e.Index]);
                var color = (Color)colorBox.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, colorBox.Font, r2,
                    colorBox.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void submitButton_Click(object sender, EventArgs e) {
            FireworkContext _context = new FireworkContext();
            Rocket rocket = new Rocket();
            bool valid = true;

            rocket.Name = nameBox.Text;
            int speed;
            if (int.TryParse(speedBox.Text, out speed)) {
                rocket.Speed = speed;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Speed is not an integer! Did not save new Rocket.");
            };

            int alt;
            if (int.TryParse(targetAltitudeBox.Text, out alt)) {
                rocket.TargetAltitude = alt;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Target Altitude is not an integer! Did not save new Rocket.");
            };

            rocket.TrailColor = Color.FromName(colorBox.Text);

            if (valid) {
                _context.Rockets.Add(rocket);
                _context.SaveChanges();
                this.Close();
            }
        }
    }
}
