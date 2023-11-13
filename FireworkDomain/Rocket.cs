using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Rocket {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Speed { get; set; }
        public decimal TargetAltitude { get; set; }

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
