using FireworkData;
using FireworkDomain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Forms;

namespace FireworkDisplay {
    public partial class DrawForm : Form {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        IList<FireworkVisual> fireworks = new List<FireworkVisual>();
        Random rnd = new Random(); //temporary
        Menu menu = new Menu();

        public DrawForm() {
            InitializeComponent();
            Width = 1280;
            Height = 1024;
            BackColor = Color.Black;

            timer.Interval = 50;
            timer.Tick += new EventHandler(Timer_Tick);
            Start();

            ListBox listBox = new ListBox();
            listBox.Location = new Point(12, 793);
            listBox.Size = new Size(1240, 116); //Height is 4 plus 28 times number of rows
            listBox.Click += new EventHandler(listBox_Click);
            string[] menuArray = new string[] { "Add Component", "List Components", "Preview Fireworks", "Exit Program" };
            listBox.Items.AddRange(menuArray);
            listBox.SelectionMode = SelectionMode.One;
            Controls.Add(listBox);
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

        private void listBox_Click(object sender, EventArgs e) {
            ListBox lb = sender as ListBox;
            Console.WriteLine($"DEBUG: Selected item {lb.SelectedIndex}: {lb.Items[lb.SelectedIndex].ToString()}");
            menu.SelectItem(lb.Items[lb.SelectedIndex].ToString());

            lb.Items.Clear();
            lb.Items.AddRange(menu.Items.ToArray());
            lb.Size = new Size(1240, 4 + (28 * menu.Items.Count));
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