using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;

namespace ServerManagement.StateStore
{
    public class SessionStorage
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public SessionStorage(ProtectedSessionStorage protectedSessionStorage)
        {
            _protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            var result = await _protectedSessionStorage.GetAsync<Server>("server");

            if (result.Success)
            {
                return result.Value;
            }
            else
            {
                return null;
            }
        }

        public async Task SetServerAsync(Server? server)
        {
            await _protectedSessionStorage.SetAsync("server", server);
        }
    }
}
