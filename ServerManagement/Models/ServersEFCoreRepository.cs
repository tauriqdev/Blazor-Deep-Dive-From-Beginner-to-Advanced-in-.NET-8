using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using ServerManagement.Components.Pages;
using ServerManagement.Data;

namespace ServerManagement.Models
{
    public class ServersEFCoreRepository : IServersEFCoreRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> _contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<Server> GetServers()
        {
            // after the method finished the db will be disposed
            using var db = _contextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public void AddServer(Server server)
        {
            using var db = _contextFactory.CreateDbContext();
            db.Servers.Add(server);

            db.SaveChanges();
        }

        public List<Server> GetServersByCity(string cityName)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers.Where(x => x.City != null && x.City.ToLower().IndexOf(cityName.ToLower()) >= 0).ToList();
        }

        public Server? GetServerById(int id)
        {
            using var db = _contextFactory.CreateDbContext();

            var server = db.Servers.Find(id);
            if (server is not null)
            {
                return server;
            }

            return new Server();
        }

        public void UpdateServer(int serverId, Server server)
        {
            if (server is null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (serverId != server.Id)
            {
                return;
            }

            using var db = _contextFactory.CreateDbContext();

            var serverToUpdate = db.Servers.Find(serverId);
            if (serverToUpdate is not null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;

                db.SaveChanges();
            }
        }

        public void DeleteServer(int id)
        {
            using var db = _contextFactory.CreateDbContext();

            var server = db.Servers.Find(id);
            if (server is null)
            {
                return;
            }

            db.Servers.Remove(server);
            db.SaveChanges();
        }

        public List<Server> SearchServers(string serverFilter)
        {
            using var db = _contextFactory.CreateDbContext();
            return db.Servers.Where(x => x.Name != null && x.Name.ToLower().IndexOf(serverFilter.ToLower()) >= 0).ToList();
        }
    }
}
