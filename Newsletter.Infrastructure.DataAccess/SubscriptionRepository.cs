using Dapper;
using Newsletter.Core.Domain.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public int CallCount { get; private set; } = 0;
        public Task<bool>Create(Subscription subscription)
        {
            string connStr = "";
            var conn = new SqlConnection(connStr);
            conn.ExecuteAsync("INSERT INTO Registrations (Email, Code) VALUES (@Email, @Code)");
                return Task.FromResult(true);
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            CallCount++;
            return Task.FromResult(new Subscription());
        }

        public Task<bool> Update(Subscription subscription)
        {
            CallCount++;
            return Task.FromResult(true);
        }
    }
}
