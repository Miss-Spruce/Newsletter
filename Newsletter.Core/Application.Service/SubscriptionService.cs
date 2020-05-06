using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Core.Application.Service
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IEmailService _emailService;

        public SubscriptionService(
            IEmailService emailService, 
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _emailService = emailService;
            
        }
 public async Task<bool> Subscribe(Subscription request)
        {
            var subscription = new Subscription(request.Name,request.Email);
            var isCreated =  await _subscriptionRepository.Create(subscription);
            if (!isCreated) return false;

            var email = new Email(
                request.Email,
                "Newsletter@mail.com",
                "Bekreft abonnoment på nyhetsbrev",
                $"<a href=\"http://localhost:5000/subscription?email={request.Email}&{subscription.VerificationCode}\">Klikk her for å bekrefte</a>"
                );
          var isSent = await _emailService.Send(email);
            if (!isSent) return false;
            return true;

        }
        public async Task<bool> Verify(Subscription verificationRequest)
        {
            // lese rad fra db - utfra epost
            // sjekke om kode stemmer
            var subscription = await _subscriptionRepository.ReadByEmail(verificationRequest.Email);
            if (verificationRequest.VerificationCode != subscription.VerificationCode)
            {
                return false;
            }

            var hasUpdated = await _subscriptionRepository.Update(subscription);
            if (!hasUpdated) return false;
            return true; 
        }
    }
}
