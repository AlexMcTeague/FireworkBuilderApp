using Microsoft.EntityFrameworkCore;
using FireworkDomain;

namespace FireworkData {
    public class FireworkContext:DbContext {
        public DbSet<Firework> Fireworks { get; set; }
        public DbSet<Rocket> Rockets { get; set; }
        public DbSet<Payload> Payloads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = FireworkDatabase"
            );
        }
    }
}