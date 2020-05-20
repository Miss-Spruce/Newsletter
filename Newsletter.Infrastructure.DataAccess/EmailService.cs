using Newsletter.Core.Domain.Model;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
   public class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            return Task.FromResult(true);
        }
    }
}
