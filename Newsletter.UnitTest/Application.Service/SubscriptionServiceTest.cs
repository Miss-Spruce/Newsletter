using Moq;
using Newsletter.Core.Application.Service;
using Newsletter.Core.Domain.Model;
using Newsletter.Core.Domain.Service;
using Newsletter.UnitTest.Application.Service;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Newsletter.UnitTest
{
    public class Tests
    {

        [Test]
        public async Task TestSubscriptionOk()
        {
            //arrange

            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                  .ReturnsAsync(true);

            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>()))
              .ReturnsAsync(true);

            //act
            var subscription = new Subscription("Lena", "Lena@mail.com");
            var subscribeIsSucces =  await service.Subscribe(subscription);

            //assert
            Assert.IsTrue(subscribeIsSucces);
            emailServiceMock.Verify(es => es.Send(It.Is<Email>(e => e.To=="Lena@mail.com")));
            subscriptionRepoMock.Verify(sr => sr.Create(
                It.Is<Subscription>(s=>s.Email=="Lena@mail.com")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task TestSubscriptionOk2()
        {
            // Samme som over, men uten mock-rammverk

            // arrange
            var emailService = new EmailService();
            var subscriptionRepo = new SubscriptionRepository();
            var service = new SubscriptionService(emailService, subscriptionRepo);

            // act
            var subscription = new Subscription("Terje", "terje@kolderup.net");
            var subscribeIsSuccess = await service.Subscribe(subscription);

            // assert
            Assert.IsTrue(subscribeIsSuccess);
            Assert.AreEqual("terje@kolderup.net", emailService.SentEmailToAddress);
            Assert.AreEqual("terje@kolderup.net", subscriptionRepo.CreatedEmailToAddress);
            Assert.AreEqual(1, emailService.CallCount);
            Assert.AreEqual(1, subscriptionRepo.CallCount);
        }

        [Test]
        public async Task TestSubscriptionEmailFail()
        {
            var emailServiceMock = new Mock<IEmailService>();
            var subscriptionRepoMock = new Mock<ISubscriptionRepository>();
            emailServiceMock.Setup(es => es.Send(It.IsAny<Email>()))
                .ReturnsAsync(false);
            subscriptionRepoMock.Setup(sr => sr.Create(It.IsAny<Subscription>()))
                .ReturnsAsync(true);
            var service = new SubscriptionService(emailServiceMock.Object, subscriptionRepoMock.Object);
            var subscription = new Subscription("Terje", "terje@kolderup.net");
            var isSuccess = await service.Subscribe(subscription);
            Assert.IsFalse(isSuccess);
            emailServiceMock.Verify(es => es.Send(
                It.Is<Email>(e => e.To == "terje@kolderup.net")));
            subscriptionRepoMock.Verify(sr => sr.Create(
                It.Is<Subscription>(s => s.Email == "terje@kolderup.net")));
            emailServiceMock.VerifyNoOtherCalls();
            subscriptionRepoMock.VerifyNoOtherCalls();

        }
    }
}