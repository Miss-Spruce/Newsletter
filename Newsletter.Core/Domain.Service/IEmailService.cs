
using Newsletter.Core.Domain.Model;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}

