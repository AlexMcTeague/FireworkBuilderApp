using FireworkData;
using FireworkDisplay;
using FireworkDomain;
using System.Drawing;
using System.Windows.Forms;

namespace FireworkConsole {
    internal class Program {
        [STAThread]
        static void Main() {
            FireworkContext _context = new FireworkContext();
            // EnsureCreated() was only necessary on the first run. Needs to be replaced with more consistent logic for users on other computers
            _context.Database.EnsureCreated();

            /*
            ReadPayloads();
            CreatePayload();
            ReadPayloads();
            UpdatePayload();
            ReadPayloads();
            DeletePayload();
            ReadPayloads();
            */

            //Set up example fireworks
            var rocket1 = _context.Rockets.Find(1);
            var payload1 = _context.Payloads.Find(1);
            var payload2 = _context.Payloads.Find(2);
            var payload3 = _context.Payloads.Find(3);
            var firework1 = new Firework();
            firework1.Name = "Standard Red Flower";
            firework1.Rocket = rocket1;
            firework1.Payloads.Add(payload1);
            var firework2 = new Firework();
            firework2.Name = "Standard Blue Square";
            firework2.Rocket = rocket1;
            firework2.Payloads.Add(payload2);
            var firework3 = new Firework();
            firework3.Name = "Standard Green Circle";
            firework3.Rocket = rocket1;
            firework3.Payloads.Add(payload3);
            var firework4 = new Firework();
            firework4.Name = "Triple Threat";
            firework4.Rocket = rocket1;
            firework4.Payloads.Add(payload1);
            firework4.Payloads.Add(payload2);
            firework4.Payloads.Add(payload3);

            _context.Fireworks.Add(firework1);
            _context.Fireworks.Add(firework2);
            _context.Fireworks.Add(firework3);
            _context.Fireworks.Add(firework4);
            _context.SaveChanges();


            //Set up the Draw Form Window
            ApplicationConfiguration.Initialize();
            DrawForm f = new DrawForm();
            Application.Run(f);


            void CreatePayload() {
                var payload = new Payload { Name = "Sample Payload", Size = 100.0, Shape = PayloadShape.Flower, Color = Color.Red };
                _context.Payloads.Add(payload);
                _context.SaveChanges();
            }

            void ReadPayloads() {
                Console.WriteLine("=== All Payloads ===");
                var payloads = _context.Payloads.ToList();
                foreach (var payload in payloads) {
                    Console.WriteLine(
                        $"{payload.Name}:\n" +
                        $" - Size: {payload.Size}\n" +
                        $" - Shape: {payload.Shape}\n" +
                        $" - Color: {payload.Color}"
                    );
                }
            }

            void UpdatePayload() {
                var payload = _context.Payloads.FirstOrDefault(a => a.Name == "Sample Payload");
                if (payload != null) {
                    payload.Color = Color.Blue;
                    _context.SaveChanges();
                }
            }

            void DeletePayload() {
                var payload = _context.Payloads.FirstOrDefault(a => a.Name == "Sample Payload");
                if (payload != null) {
                    _context.Payloads.Remove(payload);
                    _context.SaveChanges();
                }
            }
        }
    }
}