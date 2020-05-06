using Newsletter.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
    public interface ISubscriptionRepository
    {
        Task<bool> Create(Subscription subscription);

       Task<Subscription> ReadByEmail(string email);

        Task<bool> Update(Subscription subscription);
    }
}
