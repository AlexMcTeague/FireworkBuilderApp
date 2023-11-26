using FireworkDomain;

namespace FireworkDisplay {
    public class FireworkVisual {
        public int posX = 0;
        public int posY = 0;
        public int speed = 0;
        public int radius = 0;

        public Color color;
        public PayloadShape shape;
        public enum FireworkState { Launch, Coast, Detonate, Discard }
        public FireworkState state;


        public List<Particle> particles = new List<Particle>();
        public List<Point> points = new List<Point>();

        public FireworkVisual() {
            posX = 200;
            posY = 200;
            color = Color.Red;
            shape = PayloadShape.Circle;
            state = FireworkState.Launch;
        }

        public FireworkVisual(Firework firework) {
            posX = 200;
            posY = 200;
            color = firework.Payloads[0].Color;
            shape = firework.Payloads[0].Shape;
            state = FireworkState.Launch;
        }

        public void Detonate() {
            for (int i = 0; i <= 9; i++) {
                Particle p = new Particle();
                p.angle = (i * 36) * Math.PI / 180;
                Console.WriteLine($"{p.angle}");
                p.speed = 10.0M;
                particles.Add(p);
            }
            state = FireworkState.Detonate;
        }

        public void UpdateParticles() {
            points = new List<Point>();
            posY += speed;
            speed += 1;
            radius += 10;

            for (int i = 0; i < particles.Count; i++) {
                particles[i].speed -= 1;
                Point p = new Point();
                p.X = (int)(posX + (radius * Math.Cos(particles[i].angle)));
                p.Y = (int)(posY + (radius * Math.Sin(particles[i].angle)));
                points.Add(p);
            }
        }
    }
}
