using FireworkData;
using FireworkDomain;
using System.Drawing;

namespace FireworkConsole {
    internal class Program {
        static void Main(string[] args) {
            FireworkContext _context = new FireworkContext();
            _context.Database.EnsureCreated();


            CreatePayload();
            ReadPayloads();
            UpdatePayload();
            ReadPayloads();
            DeletePayload();
            ReadPayloads();


            void CreatePayload() {
                var payload = new Payload { Name = "Sample Payload", Size = 10.0M, Shape = PayloadShape.Star, Color = Color.Red };
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