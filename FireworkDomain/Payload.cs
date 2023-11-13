using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FireworkDomain {
    public class Payload {
        public int ID { get; set; }
        public string Name { get; set; }
        public PayloadShape Shape { get; set; }
        public decimal Size { get; set; }

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
