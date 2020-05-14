
using Newsletter.Core.Domain.Model;
using System.Threading.Tasks;
using System;

namespace Newsletter.Core.Domain.Service
{
    public interface IEmailService
    {
        Task<bool> Send(Email email);
    }
}

