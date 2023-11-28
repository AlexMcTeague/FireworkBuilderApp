using FireworkDomain;

namespace FireworkDisplay {
    public class FireworkVisual {
        public int posX;
        public int posY = 1200;
        public int targetY;
        public double speedY;
        public double radius = 0;
        public double radiusMax;
        public double lifetime = 0;
        public double maxLifetime = 40;

        public enum FireworkState { Launch, Detonate, Discard }
        public FireworkState state;

        public List<Particle> particles = new List<Particle>();

        public FireworkVisual() {
            //Only for use in examples
            state = FireworkState.Launch;
            radiusMax = 100.0;

            Rocket rocket = new Rocket();
            rocket.Speed = 15.0;
            rocket.TargetAltitude = 800;
            rocket.TrailColor = Color.Gold;
            ReadyRocket(rocket);

            Payload payload = new Payload();
            payload.particleCount = 40;
            payload.Shape = PayloadShape.Square;
            payload.Color = Color.Green;
            //ReadyPayload(payload);
            payload.Shape = PayloadShape.Circle;
            payload.Color = Color.Blue;
            //ReadyPayload(payload);
            payload.Shape = PayloadShape.Flower;
            payload.Color = Color.Yellow;
            ReadyPayload(payload);
        }

        public FireworkVisual(Firework firework) {
            state = FireworkState.Launch;
            radiusMax = 100;
            // radiusMax = firework.Payloads[0].Size;
            ReadyRocket(firework.Rocket);
            foreach (Payload payload in firework.Payloads) {
                ReadyPayload(payload);
            }
        }

        public void ReadyRocket(Rocket rocket) {
            speedY = rocket.Speed;

            Random rnd = new Random();
            posX = rnd.Next(400, 800);

            targetY = (int)(1200 - rocket.TargetAltitude);  //TODO: remove hardcoded "1200", refer to targetAltitude and window height
            
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
                        p.radiusMod = 1.0;
                        p.color = payload.Color;
                        particles.Add(p);
                    }
                    break;
                case PayloadShape.Square:
                    for (int i = 0; i < particleCount; i++) {
                        Particle p = new Particle();
                        p.angle = (i * 2 * Math.PI / particleCount);
                        if (Math.Truncate((p.angle + (Math.PI/4.0)) / (Math.PI/2.0)) % 2 == 0) {
                            p.radiusMod = 1.0 / Math.Cos(p.angle);
                        } else {
                            p.radiusMod = 1.0 / Math.Sin(p.angle);
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
                        p.radiusMod = 1.0 + (0.2 * Math.Sin(8*p.angle));
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
            posY -= (int)speedY;


            if (posY < targetY) {
                particles.RemoveAt(0);
                state = FireworkState.Detonate;
            }
        }

        public void PayloadTick() {
            radius = (int)(radiusMax * Math.Pow(lifetime / maxLifetime, 0.5));
            posY -= (int)speedY;
            speedY -= 1;
            lifetime++;
            if (lifetime > maxLifetime) {
                state = FireworkState.Discard;
            }
        }
    }
}
