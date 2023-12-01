using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Rocket {
        public int RocketID { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; } //Speed in pixels per tick
        public int TargetAltitude { get; set; } //The number of pixels traveled before the firework detonates
        public List<Firework> Fireworks { get; set; }

        public Rocket() {
            Fireworks = new List<Firework>();
        }

        //Since EFCore doesn't natively understand how to store the Color class, ColorARGB is used to bridge the gap;
        //EFCore is able to save ARGB to the database as just a number
        //Meanwhile, the get/set functions allow the user/dev to interact primarily with the friendly Color names
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
