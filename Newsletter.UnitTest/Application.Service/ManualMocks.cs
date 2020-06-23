using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;
using System.Threading.Tasks;

namespace Newsletter.UnitTest.Application.Service
{
    class SubscriptionRepository : ISubscriptionRepository
    {
        public int CallCount { get; private set; } = 0;
        public string CreatedEmailToAddress { get; private set; } = null;
        public Task<bool> Create(Subscription subscription)
        {
            CallCount++;
            CreatedEmailToAddress = subscription.Email;
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

    class EmailService : IEmailService
    {
        public int CallCount { get; private set; } = 0;
        public string SentEmailToAddress { get; private set; } = null;

        public Task<bool> Send(Email email)
        {
            CallCount++;
            SentEmailToAddress = email.To;
            return Task.FromResult(true);
        }
    }
}
