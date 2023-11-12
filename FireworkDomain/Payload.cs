using System.Drawing;

namespace FireworkDomain {
    internal class Payload {
        public int ID { get; set; }
        public string Name { get; set; }
        public PayloadShape Shape { get; set; }
        public decimal Size { get; set; }
        public List<Color> Colors { get; set; }
    }
}
