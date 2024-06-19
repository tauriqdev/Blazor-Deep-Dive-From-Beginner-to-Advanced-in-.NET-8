using Microsoft.EntityFrameworkCore;
using ServerManagement.Models;

namespace ServerManagement.Data
{
    public class ServerManagementContext : DbContext
    {
        public ServerManagementContext(DbContextOptions<ServerManagementContext> options): base(options)
        {
        }

        public DbSet<Server> Servers { get; set; }

        // when model is being created do
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Server>().HasData(
                new() { Id = 1, Name = "Server1", City = "Toronto" },
                new() { Id = 2, Name = "Server2", City = "Toronto" },
                new() { Id = 3, Name = "Server3", City = "Toronto" },
                new() { Id = 4, Name = "Server4", City = "Montreal" },
                new() { Id = 5, Name = "Server5", City = "Montreal" },
                new() { Id = 6, Name = "Server6", City = "Montreal" },
                new() { Id = 7, Name = "Server7", City = "Ottawa" },
                new() { Id = 8, Name = "Server8", City = "Ottawa" },
                new() { Id = 9, Name = "Server9", City = "Ottawa" },
                new() { Id = 10, Name = "Server10", City = "Calgary" },
                new() { Id = 11, Name = "Server11", City = "Calgary" },
                new() { Id = 12, Name = "Server12", City = "Halifax" },
                new() { Id = 13, Name = "Server13", City = "Halifax" },
                new() { Id = 14, Name = "Server14", City = "Halifax" },
                new() { Id = 15, Name = "Server15", City = "Halifax" }
            );
        }
    }
}
