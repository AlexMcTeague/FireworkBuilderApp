namespace FireworkDomain {
    public class Firework {
        public int FireworkID { get; set; }
        public string Name { get; set; }
        public Rocket Rocket { get; set; }
        public int RocketID { get; set; }
        public List<Payload> Payloads { get; set; }
        public Firework() {
            Payloads = new List<Payload>();
        }
    }
}
