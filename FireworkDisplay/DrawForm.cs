using FireworkDomain;
using System.Globalization;

namespace FireworkDisplay {
    public partial class DrawForm : Form {
        IList<Point> points = new List<Point>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        IList<FireworkVisual> fireworks = new List<FireworkVisual>();

        public DrawForm() {
            InitializeComponent();
            Width = 1200;
            Height = 800;
            BackColor = Color.Black;

            Point p = new Point();
            p.X = 100;
            p.Y = 100;
            AddPoint(p);
            p.X = 200;
            p.Y = 100;
            AddPoint(p);
            p.X = 200;
            p.Y = 200;
            AddPoint(p);
            p.X = 100;
            p.Y = 200;
            AddPoint(p);
            p.X = 100;
            p.Y = 100;
            AddPoint(p);

            fireworks.Add(new FireworkVisual());

            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer_Tick);
            Start();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            for (int i = 0; i < fireworks.Count; i++) {
                switch (fireworks[i].state) {
                    case FireworkVisual.FireworkState.Launch:
                        fireworks[i].state = FireworkVisual.FireworkState.Coast;
                        break;
                    case FireworkVisual.FireworkState.Coast:
                        fireworks[i].Detonate();
                        break;
                    case FireworkVisual.FireworkState.Detonate:
                        fireworks[i].UpdateParticles();
                        for (int j = 0; j < fireworks[i].points.Count; j++) {
                            e.Graphics.FillEllipse(new SolidBrush(fireworks[i].color), fireworks[i].points[j].X, fireworks[i].points[j].Y, 10, 10);
                        }
                        break;
                    case FireworkVisual.FireworkState.Discard:
                        fireworks.Remove(fireworks[i]);
                        break;
                }
            }
        }

        public void AddPoint(Point point) {
            points.Add(point);
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