using Microsoft.AspNetCore.Mvc;
using Newsletter.Core.Application.Service;
using Newsletter.Core.Domain.Model;
using System.Threading.Tasks;

namespace Newsletter.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscribeController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<bool> Subscribe(string name, string email)
        {
            var subscription = new Subscription { Name = name, Email = email };
            return await _subscriptionService.Subscribe(subscription);
            {
            }
        }
    }
}
