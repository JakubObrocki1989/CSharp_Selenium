using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class HomeTests : BaseTest
    {
        [Test]
        public void test0001_scrollUpByArrowButton()
        {
            Assert.That(homePage.IsSubscriptionHeaderVisible(), Is.True);
            homePage.ClickScrollUpArrow();
            Assert.That(homePage.IsFullFledgedHeaderVisible(), Is.True);
        }

        [Test]
        public void test0002_scrollUpByScroll()
        {
            Assert.That(homePage.IsSubscriptionHeaderVisible(), Is.True);
            homePage.ScrollToTop();
            Assert.That(homePage.IsSubscriptionHeaderVisible(), Is.True);
        }
    }
}
