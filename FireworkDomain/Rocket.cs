using System.Drawing;

namespace FireworkDomain {
    internal class Rocket {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Speed { get; set; }
        public decimal TargetAltitude { get; set; }
        public Color TrailColor { get; set; }
    }
}
