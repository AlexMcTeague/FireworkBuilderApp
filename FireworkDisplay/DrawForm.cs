using FireworkData;
using FireworkDomain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Forms;

namespace FireworkDisplay {
    public partial class DrawForm : Form {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        List<FireworkVisual> fireworks = new List<FireworkVisual>();
        FireworkContext _context = new FireworkContext();

        public DrawForm() {
            InitializeComponent();
            Width = 1280;
            Height = 1024;
            BackColor = Color.Black;

            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer_Tick);
            Start();

            List<Firework> seedFireworks = _context.Fireworks.Where(f => f.FireworkID <= 3).Include(f => f.Payloads).Include(f => f.Rocket).ToList();
            if (fireworks.Count == 0) {
                foreach (Firework f in seedFireworks) {
                    fireworks.Add(new FireworkVisual(f));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            for (int i = 0; i < fireworks.Count; i++) {
                FireworkVisual f = fireworks[i];
                switch (f.state) {
                    case FireworkVisual.FireworkState.Launch:
                        f.Draw(e);
                        f.RocketTick();
                        break;
                    case FireworkVisual.FireworkState.Detonate:
                        f.Draw(e);
                        f.PayloadTick();
                        break;
                }
            }
        }

        public void Start() {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            Refresh();
        }

        void AddFirework(Firework firework) {
            fireworks.Add(new FireworkVisual(firework));
        }

        private void previewToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;

            List<string> fireworkNames = _context.GetFireworkNames();
            ToolStripMenuItem[] tsiArray = new ToolStripMenuItem[fireworkNames.Count];

            for (int i = 0; i < tsiArray.Length; i++) {
                ToolStripMenuItem tsi = new ToolStripMenuItem(fireworkNames[i]);
                tsi.Click += new EventHandler(preview_DropDownItem_Click);
                tsiArray[i] = tsi;
            }
            mi.DropDownItems.Clear();
            mi.DropDownItems.AddRange(tsiArray);
        }

        private void preview_DropDownItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;

            string clickedName = mi.Text;
            fireworks.Clear();
            Firework f1 = new Firework();
            AddFirework(_context.Fireworks.Where(f => f.Name == clickedName).Include(f => f.Payloads).Include(f => f.Rocket).Single());
        }

        private void addRocketToolStripMenuItem_Click(object sender, EventArgs e) {
            AddRocketForm addRocketForm = new AddRocketForm();
            addRocketForm.Show();
            addRocketForm.Activate();
        }

        private void addPayloadToolStripMenuItem_Click(object sender, EventArgs e) {
            AddPayloadForm addPayloadForm = new AddPayloadForm();
            addPayloadForm.Show();
            addPayloadForm.Activate();
        }

        private void addFireworkToolStripMenuItem_Click(object sender, EventArgs e) {
            AddFireworkForm addFireworkForm = new AddFireworkForm();
            addFireworkForm.Show();
            addFireworkForm.Activate();
        }
    }
}