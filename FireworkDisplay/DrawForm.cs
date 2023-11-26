namespace FireworkDisplay {
    public partial class DrawForm : Form {
        IList<Point> points = new List<Point>();

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

            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Point previousPoint = Point.Empty;
            foreach (Point point in points) {
                if (previousPoint != Point.Empty) {
                    e.Graphics.DrawLine(Pens.Red, previousPoint, point);
                }
                previousPoint = point;
            }
        }

        public void AddPoint(Point point) {
            points.Add(point);
            this.Refresh();
        }
    }
}