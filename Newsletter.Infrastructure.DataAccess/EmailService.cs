using Newsletter.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Newsletter.Core.Domain.Service;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
     class EmailService : IEmailService
    {
        public Task<bool> Send(Email email)
        {
            return Task.FromResult(true);
        }
    }
}
