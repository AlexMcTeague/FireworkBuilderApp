using Microsoft.EntityFrameworkCore;
using FireworkDomain;
using System.Drawing;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FireworkData {
    public class FireworkContext:DbContext {
        public DbSet<Firework> Fireworks { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Payload> Payloads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FireworkDatabase" //see Module 15 of Lerman video
            ).LogTo(
                log=>Debug.WriteLine(log),
                new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information
            ).EnableSensitiveDataLogging(); //Remove .EnableSensitiveDataLogging to hide parameter values in logs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var rocketArray = new Rocket[] {
                new Rocket { RocketID = 1, Name = "Standard Gold Trail", Speed = 15, TargetAltitude = 800, TrailColor = Color.Gold }
            };
            var payloadArray = new Payload[] {
                new Payload { PayloadID = 1, Name = "Red Flower", Size = 100.0, Shape = PayloadShape.Flower, Color = Color.Red, particleCount = 40 },
                new Payload { PayloadID = 2, Name = "Blue Square", Size = 100.0, Shape = PayloadShape.Square, Color = Color.Blue, particleCount = 40 },
                new Payload { PayloadID = 3, Name = "Green Circle", Size = 100.0, Shape = PayloadShape.Circle, Color = Color.Green, particleCount = 40 }
            };
            var fireworkArray = new Firework[] {
                new Firework { FireworkID = 1, Name = "Standard Red Flower", RocketID = 1 },
                new Firework { FireworkID = 2, Name = "Standard Blue Square", RocketID = 1 },
                new Firework { FireworkID = 3, Name = "Standard Green Circle", RocketID = 1 },
                new Firework { FireworkID = 4, Name = "Triple Threat", RocketID = 1 }
            };

            modelBuilder.Entity<Rocket>().HasData(rocketArray);
            modelBuilder.Entity<Payload>().HasData(payloadArray);
            modelBuilder.Entity<Firework>().HasData(fireworkArray);
        }

        public void ensureCreatedCustom() {
            this.Database.EnsureCreated();

            Payload payload1 = Payloads.Find(1);
            Payload payload2 = Payloads.Find(2);
            Payload payload3 = Payloads.Find(3);
            Firework firework1 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 1).Single();
            Firework firework2 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 2).Single();
            Firework firework3 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 3).Single();
            Firework firework4 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 4).Single();

            Console.WriteLine($"{payload1.Name} {payload2.Name} {payload3.Name} {firework1.Name}, {firework2.Name}, {firework3.Name}, {firework4.Name}");

            if (firework1.Payloads.Count() == 0) firework1.Payloads.Add(payload1);
            if (firework2.Payloads.Count() == 0) firework2.Payloads.Add(payload2);
            if (firework3.Payloads.Count() == 0) firework3.Payloads.Add(payload3);
            if (firework4.Payloads.Count() == 0) firework4.Payloads = new List<Payload> { payload1, payload2, payload3 };
            
            SaveChanges();
        }
    }
}