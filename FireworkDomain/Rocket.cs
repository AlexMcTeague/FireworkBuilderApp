using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Rocket {
        public int RocketID { get; set; }
        public string Name { get; set; }
        public double Speed { get; set; }
        public decimal TargetAltitude { get; set; }
        public List<Firework> Fireworks { get; set; }

        public Rocket() {
            Fireworks = new List<Firework>();
        }

        public int TrailColorARGB {
            get {
                return TrailColor.ToArgb();
            }
            set {
                TrailColor = Color.FromArgb(value);
            }
        }
        [NotMapped]
        public Color TrailColor { get; set; }
    }
}
