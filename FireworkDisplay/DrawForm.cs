using FireworkData;
using FireworkDomain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FireworkDisplay {
    public partial class DrawForm : Form {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        IList<FireworkVisual> fireworks = new List<FireworkVisual>();
        Random rnd = new Random(); //temporary

        public DrawForm() {
            InitializeComponent();
            Width = 1200;
            Height = 1200;
            BackColor = Color.Black;

            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer_Tick);
            Start();
        }

        protected override void OnPaint(PaintEventArgs e) {
            //Temporary loop logic
            var _context = new FireworkContext();
            List<Firework> tempFireworks = _context.Fireworks.Include(f => f.Payloads).Include(f => f.Rocket).ToList();
            if (fireworks.Count == 0) {
                Firework tempFirework = tempFireworks[rnd.Next(0, tempFireworks.Count)];
                fireworks.Add(new FireworkVisual(tempFirework));
            }


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
                    case FireworkVisual.FireworkState.Discard:
                        fireworks.Remove(fireworks[i]);
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

        void AddFirework(FireworkVisual firework) {
            fireworks.Add(firework);
        }

        void AddFirework(Firework firework) {
            fireworks.Add(new FireworkVisual(firework));
        }
    }
}