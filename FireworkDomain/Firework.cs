namespace FireworkDomain {
    internal class Firework {
        public int ID { get; set; }
        public string Name { get; set; }
        public Rocket Rocket { get; set; }
        public List<Payload> Payloads { get; set; }

        public Firework() {
            Payloads = new List<Payload>();
        }
    }
}
