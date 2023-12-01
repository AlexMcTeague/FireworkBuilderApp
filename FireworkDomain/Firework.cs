namespace FireworkDomain {
    public class Firework {
        //A Firework is a combination of one rocket and any number of different payloads.
        //Fireworks have a one-to-many relationship with rockets, and a many-to-many relationship with payloads

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
