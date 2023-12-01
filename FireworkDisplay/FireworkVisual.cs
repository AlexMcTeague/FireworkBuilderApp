using FireworkDomain;

namespace FireworkDisplay {
    public class FireworkVisual {
        public Firework firework { get; set; }
        public int posX;
        public int posY;
        public int targetY;
        public int speedY;
        public double radius;
        public double radiusMax;
        public double lifetime;
        public double maxLifetime;

        public enum FireworkState { Launch, Detonate }
        public FireworkState state;

        public List<Particle> particles = new List<Particle>();

        public FireworkVisual(Firework f) {
            firework = f;
            radiusMax = 100.0;
            Reset();
        }

        public void Reset() {
            posY = 1080;
            radius = 0;
            lifetime = 0;
            maxLifetime = 40;

            state = FireworkState.Launch;

            particles.Clear();

            ReadyRocket(firework.Rocket);
            foreach (Payload payload in firework.Payloads) {
                ReadyPayload(payload);
            }
        }

        public void ReadyRocket(Rocket rocket) {
            speedY = rocket.Speed;

            Random rnd = new Random();
            posX = rnd.Next(400, 800);

            targetY = 1080 - rocket.TargetAltitude;  //TODO: remove hardcoded "1080", refer to targetAltitude and window height
            
            Particle p = new Particle();
            p.angle = 0;
            p.color = Color.FromArgb(rocket.TrailColorARGB);
            p.radiusMod = 0;
            particles.Add(p);
        }

        public void ReadyPayload(Payload payload) {
            double particleCount = payload.particleCount;
            switch (payload.Shape) {
                case PayloadShape.Circle:
                    for (int i = 0; i < particleCount; i++) {
                        Particle p = new Particle();
                        p.angle = (i * 2 * Math.PI / particleCount);
                        p.radiusMod = ((double)payload.Size) / radiusMax;
                        p.color = payload.Color;
                        particles.Add(p);
                    }
                    break;
                case PayloadShape.Square:
                    for (int i = 0; i < particleCount; i++) {
                        Particle p = new Particle();
                        p.angle = (i * 2 * Math.PI / particleCount);
                        if (Math.Truncate((p.angle + (Math.PI/4.0)) / (Math.PI/2.0)) % 2 == 0) {
                            p.radiusMod = (((double)payload.Size) / radiusMax) / Math.Cos(p.angle);
                        } else {
                            p.radiusMod = (((double)payload.Size) / radiusMax) / Math.Sin(p.angle);
                        }
                        p.radiusMod = Math.Abs(p.radiusMod);
                        p.color = payload.Color;
                        particles.Add(p);
                    }
                    break;
                case PayloadShape.Flower:
                    for (int i = 0; i < particleCount; i++) {
                        Particle p = new Particle();
                        p.angle = (i * 2 * Math.PI / particleCount);
                        p.radiusMod = (((double)payload.Size) / radiusMax) + (0.2 * Math.Sin(8*p.angle));
                        p.color = payload.Color;
                        particles.Add(p);
                    }
                    break;
            }
        }

        public void Draw(PaintEventArgs e) {
            if (state == FireworkState.Launch) {
                Particle p = particles[0];
                SolidBrush brush = new SolidBrush(p.color);
                int x = (int)posX;
                int y = (int)posY;

                e.Graphics.FillEllipse(brush, x, y, 10, 10);
            } else if (state == FireworkState.Detonate) {
                for (int i = 0; i < particles.Count; i++) {
                    Particle p = particles[i];
                    SolidBrush brush = new SolidBrush(p.color);
                    int x = (int)(posX + (radius * p.radiusMod * Math.Cos(particles[i].angle)));
                    int y = (int)(posY + (radius * p.radiusMod * Math.Sin(particles[i].angle)));

                    e.Graphics.FillEllipse(brush, x, y, 10, 10);
                }
            }
        }

        public void RocketTick() {
            posY -= speedY;


            if (posY < targetY) {
                particles.RemoveAt(0);
                state = FireworkState.Detonate;
            }
        }

        public void PayloadTick() {
            radius = (int)(radiusMax * Math.Pow(lifetime / maxLifetime, 0.5));
            posY -= speedY;
            speedY -= 1;
            lifetime++;
            if (lifetime > maxLifetime) {
                Reset();
            }
        }
    }
}
