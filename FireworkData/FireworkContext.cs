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
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FireworkDatabase"
            ).LogTo(
                log=>Debug.WriteLine(log),
                new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information
            ).EnableSensitiveDataLogging(); //Remove .EnableSensitiveDataLogging to hide parameter values in logs
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var payloadArray = new Payload[] {
                new Payload() { ID = 1, Name = "Gold Star", Size = 10.0M, Shape = PayloadShape.Star, Color = Color.Gold },
                new Payload() { ID = 2, Name = "Blue Square", Size = 10.0M, Shape = PayloadShape.Square, Color = Color.Blue },
                new Payload() { ID = 3, Name = "Green Circle", Size = 10.0M, Shape = PayloadShape.Circle, Color = Color.Green }
            };

            modelBuilder.Entity<Payload>().HasData(payloadArray);
        }
    }
}