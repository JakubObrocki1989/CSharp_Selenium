using NUnit.Framework;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class SubscriptionTests : BaseTest
    {
        [Test]
        public void test0001_subscribeOnHomePage()
        {
            Assert.That(homePage.GetSubscriptionHeaderText(), Is.EqualTo("SUBSCRIPTION"), "Subscription header should has text: SUBSCRIPTION, but was: " + homePage.GetSubscriptionHeaderText());
            homePage.Subscribe(Faker.Internet.Email());
            Assert.That(homePage.GetSubscriptionSuccessText(), Is.EqualTo("You have been successfully subscribed!"), "Subscription message should be 'You have been successfully subscribed!' but was: " + homePage.GetSubscriptionSuccessText());
        }

        [Test]
        public void test0002_subscribeOnCartPage()
        {
            homePage.ClickMenuOption("Cart");
            Assert.That(homePage.GetSubscriptionHeaderText(), Is.EqualTo("SUBSCRIPTION"), "Subscription header should has text: SUBSCRIPTION, but was: " + homePage.GetSubscriptionHeaderText());
            homePage.Subscribe(Faker.Internet.Email());
            Assert.That(homePage.GetSubscriptionSuccessText(), Is.EqualTo("You have been successfully subscribed!"), "Subscription message should be 'You have been successfully subscribed!' but was: " + homePage.GetSubscriptionSuccessText());
        }
    }
}
