using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Payload {
        public int PayloadID { get; set; }
        public string Name { get; set; }
        public PayloadShape Shape { get; set; } //The appearance of each shape is controlled in FireworkVisual
        public int Size { get; set; } //Radius in pixels
        public int particleCount { get; set; } //Number of particles created by the payload
        public List<Firework> Fireworks { get; set; }

        public Payload() {
            Fireworks = new List<Firework>();
        }

        //Since EFCore doesn't natively understand how to store the Color class, ColorARGB is used to bridge the gap;
        //EFCore is able to save ARGB to the database as just a number
        //Meanwhile, the get/set functions allow the user/dev to interact primarily with the friendly Color names
        public int ColorARGB {
            get {
                return Color.ToArgb();
            }
            set {
                Color = Color.FromArgb(value);
            }
        }
        [NotMapped]
        public Color Color { get; set; }
    }
}
