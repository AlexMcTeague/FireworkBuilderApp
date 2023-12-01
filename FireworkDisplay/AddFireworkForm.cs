using FireworkData;
using FireworkDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FireworkDisplay {
    public partial class AddFireworkForm : Form {
        public AddFireworkForm() {
            InitializeComponent();
            FireworkContext _context = new FireworkContext();

            rocketBox.DataSource = _context.Rockets.Select(r => r.Name).ToArray();
            payloadsChecklist.Items.AddRange(_context.Payloads.Select(p => p.Name).ToArray());
        }

        private void submitButton_Click(object sender, EventArgs e) {
            FireworkContext _context = new FireworkContext();
            Firework firework = new Firework();
            bool valid = true;

            firework.Name = nameBox.Text;
            if (_context.Fireworks.Where(f => f.Name == firework.Name).ToList().Count > 0) {
                valid = false;
                Console.WriteLine($"ERROR: A Firework with name \"{firework.Name}\" already exists! Did not save new Firework.");
            }

            firework.Rocket = _context.Rockets.Where(r => r.Name == rocketBox.Text).Single();
            
            List<Payload> payloads = new List<Payload>();
            List<string> payloadsChecked = payloadsChecklist.CheckedItems.Cast<string>().ToList();
            foreach (string payload in payloadsChecked) {
                payloads.Add(_context.Payloads.Where(p => p.Name == payload).Single());
            }
            firework.Payloads = payloads;

            if (valid) {
                _context.Fireworks.Add(firework);
                _context.SaveChanges();
                this.Close();
            }
        }
    }
}
