using FireworkData;
using FireworkDomain;
using Microsoft.EntityFrameworkCore;

namespace FireworkDisplay {
    public partial class DrawForm : Form {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        List<FireworkVisual> visuals = new List<FireworkVisual>();
        FireworkContext _context = new FireworkContext();

        public DrawForm() {
            //Initialize the form according to the contents of the Designer class
            InitializeComponent();
            Width = 1280;
            Height = 1024;
            BackColor = Color.Black; //Like the night sky :)

            timer.Interval = 50; //Tick length in milliseconds
            timer.Tick += new EventHandler(Timer_Tick);
            Start();

            //Set three of the four seeded visuals to display to the user when first opening the program
            List<Firework> seedFireworks = _context.Fireworks.Where(f => f.FireworkID <= 3).Include(f => f.Payloads).Include(f => f.Rocket).ToList();
            if (visuals.Count == 0) {
                foreach (Firework f in seedFireworks) {
                    visuals.Add(new FireworkVisual(f));
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e) {
            //This event fires whenever Refresh() is called (every tick)

            base.OnPaint(e);
            for (int i = 0; i < visuals.Count; i++) {
                FireworkVisual v = visuals[i];
                //Draw and update the firework
                v.Draw(e);
                v.Tick();
            }
        }

        public void Start() {
            timer.Start();
        }

        public void Stop() {
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            //This event fires every tick, and triggers OnPaint
            Refresh();
        }

        void AddFireworkVisual(Firework firework) {
            //Registers a new FireworkVisual to the display list, using a Firework object
            visuals.Add(new FireworkVisual(firework));
        }

        private void previewToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            //This event fires whenever a user opens the Quick Preview menu in the tool strip

            ToolStripMenuItem mi = sender as ToolStripMenuItem;

            List<string> fireworkNames = _context.GetFireworkNames();
            ToolStripMenuItem[] tsiArray = new ToolStripMenuItem[fireworkNames.Count];

            //Ensures the list shown by the dropdown contains all the existing Fireworks
            //Registers a click event for each dropdown item
            for (int i = 0; i < tsiArray.Length; i++) {
                ToolStripMenuItem tsi = new ToolStripMenuItem(fireworkNames[i]);
                tsi.Click += new EventHandler(preview_DropDownItem_Click);
                tsiArray[i] = tsi;
            }
            mi.DropDownItems.Clear();
            mi.DropDownItems.AddRange(tsiArray);
        }

        private void preview_DropDownItem_Click(object sender, EventArgs e) {
            //This event fires whenever a user clicks an item in the Quick Preview dropdown

            ToolStripMenuItem mi = sender as ToolStripMenuItem;

            //Quick Preview shows the selected firework on the screen on its own
            string clickedName = mi.Text;
            visuals.Clear();
            Firework f1 = new Firework();
            AddFireworkVisual(_context.Fireworks.Where(f => f.Name == clickedName).Include(f => f.Payloads).Include(f => f.Rocket).Single());
        }

        private void addRocketToolStripMenuItem_Click(object sender, EventArgs e) {
            //This event fires whenever a user selects the "Add Rocket" button in the Add menu
            //Opens a new form to fill out details for a new Rocket

            AddRocketForm addRocketForm = new AddRocketForm();
            addRocketForm.Show();
            addRocketForm.Activate();
        }

        private void addPayloadToolStripMenuItem_Click(object sender, EventArgs e) {
            //This event fires whenever a user selects the "Add Payload" button in the Add menu
            //Opens a new form to fill out details for a new Payload

            AddPayloadForm addPayloadForm = new AddPayloadForm();
            addPayloadForm.Show();
            addPayloadForm.Activate();
        }

        private void addFireworkToolStripMenuItem_Click(object sender, EventArgs e) {
            //This event fires whenever a user selects the "Add Firework" button in the Add menu
            //Opens a new form to fill out details for a new Firework

            AddFireworkForm addFireworkForm = new AddFireworkForm();
            addFireworkForm.Show();
            addFireworkForm.Activate();
        }
    }
}