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
    public partial class AddPayloadForm : Form {
        public AddPayloadForm() {
            InitializeComponent();
            shapeBox.DataSource = Enum.GetValues(typeof(PayloadShape)).Cast<PayloadShape>();
            colorBox.DataSource = typeof(Color).GetProperties()
                .Where(x => x.PropertyType == typeof(Color))
                .Select(x => x.GetValue(null)).ToList();
        }

        private void sizeBox_KeyPress(object sender, KeyPressEventArgs e) {
            var tb = sender as System.Windows.Forms.TextBox;

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void countBox_KeyPress(object sender, KeyPressEventArgs e) {
            var tb = sender as System.Windows.Forms.TextBox;

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) || tb.Text.Length >= 3) {
                e.Handled = true;
                return;
            }
        }

        private void colorBox_DrawItem(object sender, DrawItemEventArgs e) {
            e.DrawBackground();
            if (e.Index >= 0) {
                var txt = shapeBox.GetItemText(shapeBox.Items[e.Index]);
                var color = (Color)shapeBox.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, shapeBox.Font, r2,
                    shapeBox.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void submitButton_Click(object sender, EventArgs e) {
            FireworkContext _context = new FireworkContext();
            Payload payload = new Payload();
            bool valid = true;

            payload.Name = nameBox.Text;

            PayloadShape shape;
            if (PayloadShape.TryParse(shapeBox.Text, out shape)) {
                payload.Shape = shape;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Shape is an invalid value! Did not save new Payload.");
            }

            int size;
            if (int.TryParse(sizeBox.Text, out size)) {
                payload.Size = size;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Size is not an integer! Did not save new Payload.");
            };

            int count;
            if (int.TryParse(sizeBox.Text, out count)) {
                payload.particleCount = count;
            } else {
                valid = false;
                Console.WriteLine("ERROR: Particle Count is not an integer! Did not save new Payload.");
            };

            payload.Color = Color.FromName(colorBox.Text);

            if (valid) {
                _context.Payloads.Add(payload);
                _context.SaveChanges();
                this.Close();
            }
        }
    }
}
