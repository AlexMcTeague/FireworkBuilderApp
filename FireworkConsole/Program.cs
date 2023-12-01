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
            // ensureCreatedCustom is only necessary on the first run to create the database
            //_context.ensureCreatedCustom();
            _context.Dispose();

            /*
            ReadPayloads();
            CreatePayload();
            ReadPayloads();
            UpdatePayload();
            ReadPayloads();
            DeletePayload();
            ReadPayloads();
            */


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