using FireworkDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Drawing;

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
            ).EnableSensitiveDataLogging(); //Remove .EnableSensitiveDataLogging to make SQL logs more secure
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //Seeding the database
            var rocketArray = new Rocket[] {
                new Rocket { RocketID = 1, Name = "Standard Gold Trail", Speed = 20, TargetAltitude = 650, TrailColor = Color.Gold }
            };
            var payloadArray = new Payload[] {
                new Payload { PayloadID = 1, Name = "Red Flower", Size = 100, Shape = PayloadShape.Flower, Color = Color.Red, particleCount = 40 },
                new Payload { PayloadID = 2, Name = "Blue Square", Size = 100, Shape = PayloadShape.Square, Color = Color.Blue, particleCount = 40 },
                new Payload { PayloadID = 3, Name = "Green Circle", Size = 100, Shape = PayloadShape.Circle, Color = Color.Green, particleCount = 40 }
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

        public void ensureSeeded() {
            this.Database.EnsureCreated();

            //In this version of EF Core, you can't seed the database with many-to-many relationships.
            //The below code further modifies the previously seeded data to include the proper relationships.
            Payload payload1 = Payloads.Find(1);
            Payload payload2 = Payloads.Find(2);
            Payload payload3 = Payloads.Find(3);
            Firework firework1 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 1).Single();
            Firework firework2 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 2).Single();
            Firework firework3 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 3).Single();
            Firework firework4 = Fireworks.Include(f => f.Payloads).Where(f => f.FireworkID == 4).Single();

            if (firework1.Payloads.Count() == 0) firework1.Payloads.Add(payload1);
            if (firework2.Payloads.Count() == 0) firework2.Payloads.Add(payload2);
            if (firework3.Payloads.Count() == 0) firework3.Payloads.Add(payload3);
            if (firework4.Payloads.Count() == 0) firework4.Payloads = new List<Payload> { payload1, payload2, payload3 };
            
            SaveChanges();
        }

        public List<string> GetFireworkNames() {
            //This method returns a List with the names of all Fireworks
            return Fireworks.Select(f => f.Name).ToList();
        }
    }
}