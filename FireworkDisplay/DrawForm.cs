namespace FireworkDisplay {
    public partial class DrawForm : Form {
        IList<Point> points = new List<Point>();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public DrawForm() {
            InitializeComponent();
            Width = 800;
            Height = 500;
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

            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer_Tick);
            Start();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Point previousPoint = Point.Empty;
            for (int i = 0; i < points.Count; i++) {
                Point p = points[i];
                p.X = points[i].X + 1;
                p.Y = points[i].Y + 1;
                points[i] = p;
                if (previousPoint != Point.Empty) {
                    e.Graphics.DrawLine(Pens.Red, previousPoint, points[i]);
                }
                previousPoint = points[i];
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
    }
}