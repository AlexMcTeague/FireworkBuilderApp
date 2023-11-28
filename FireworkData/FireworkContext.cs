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

            modelBuilder.Entity<Rocket>().HasData(rocketArray);
            modelBuilder.Entity<Payload>().HasData(payloadArray);
        }
    }
}