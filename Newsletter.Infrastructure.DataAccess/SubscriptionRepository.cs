using Newsletter.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Core.Domain.Service
{
    class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<bool>Create(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> ReadByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
