using Moq;
using Newsletter.Core.Application.Service;
using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Newsletter.UnitTest
{
    public class Tests
    {

        [Test]
        public async Task Test1()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                  .ReturnsAsync(true);

            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>()))
              .ReturnsAsync(true);

            var subscription = new Subscription("Lena", "Lenatherese_gran@hotmail.com");
            await service.Subscribe(subscription);

            emailServiceMock.Verify(es => es.Send(It.Is<Email>(e => e.To=="Lenatherese_gran@hotmail.com")));

            subscriptionRepoMock.Verify(sr => sr.Create(
                It.Is<Subscription>(s=>s.Email=="Lenatherese_gran@hotmail.com")));
        }
    }
}