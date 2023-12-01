using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Payload {
        public int PayloadID { get; set; }
        public string Name { get; set; }
        public PayloadShape Shape { get; set; }
        public int Size { get; set; } //Radius in pixels
        public int particleCount { get; set; }
        public List<Firework> Fireworks { get; set; }

        public Payload() {
            Fireworks = new List<Firework>();
        }

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
