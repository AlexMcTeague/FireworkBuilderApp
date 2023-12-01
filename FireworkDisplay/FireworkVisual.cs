using FireworkDomain;

namespace FireworkDisplay {
    public class FireworkVisual {
        //Used load Fireworks into memory with additional relevant data.
        //Not for storage in a database

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
            posY = 1024; //TODO: replace hardcoded value with a calculation based on window height
            radius = 0; //radius is modified by radiusMod to get each particle's final position
            
            lifetime = 0; //In "ticks", 1/20 of a second by default
            maxLifetime = 50;

            state = FireworkState.Launch;

            particles.Clear();

            //Load data from the attached Firework
            ReadyRocket(firework.Rocket);
            foreach (Payload payload in firework.Payloads) {
                ReadyPayload(payload);
            }
        }

        public void ReadyRocket(Rocket rocket) {
            speedY = rocket.Speed;

            Random rnd = new Random();
            posX = rnd.Next(320, 960); //TODO: replace hardcoded values with a calculation based on window width

            targetY = 1024 - rocket.TargetAltitude; //TODO: replace hardcoded value with a calculation based on window height
            
            //Populate the particle list
            Particle p = new Particle();
            p.angle = 0;
            p.color = Color.FromArgb(rocket.TrailColorARGB);
            p.radiusMod = 0;
            particles.Add(p);
        }

        public void ReadyPayload(Payload payload) {
            double particleCount = payload.particleCount;

            //Controls the appearance of each PayloadShape using trig functions
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
            //Draws a trail or explosion based on the current state

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

        public void Tick() {
            //Updates the FireworkVisual based on its state

            if (state == FireworkState.Launch) {
                posY -= speedY; //The rocket rises, no gravity or drag is applied

                //posY to targetY comparison is inverted, because forms coordinates start from the top
                if (posY < targetY) {
                    particles.RemoveAt(0); //Removes the trail particle (assumes ReadyRocket was called before ReadyPayload)
                    state = FireworkState.Detonate;
                }
            } else if (state == FireworkState.Detonate) {
                radius = (int)(radiusMax * Math.Pow(lifetime / maxLifetime, 0.5)); //Exploding logic
                posY -= speedY; //The firework continues its momentum after exploding
                speedY -= 1; //Simplistic simulation of gravity (missing drag force)
                lifetime++;
                if (lifetime > maxLifetime) {
                    Reset(); //Resets the firework but does not remove it, causing the whole process to loop again
                }
            }
        }
    }
}
