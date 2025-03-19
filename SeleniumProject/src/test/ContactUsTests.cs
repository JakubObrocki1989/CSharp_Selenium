using NUnit.Framework;
using SeleniumProject.src.main.app.factories;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class ContactUsTests : BaseTest
    {
        ContactMessageFactory contactMessageFactory = new ContactMessageFactory();

        [Test]
        public void test0001_messageShouldBeSentSuccessfully()
        {
            ContactMessage contactMessage = contactMessageFactory.getContactUsMessage();
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Contact us");
            Assert.That(contactUsPage.IsGetInTouchHeaderVisible(), Is.True, "Get in touch header should be visible, but was not.");
            Assert.That(contactUsPage.GetGetInTouchHeaderText(), Is.EqualTo("GET IN TOUCH"), "Header should has: GET IN TOUCH but was:" + contactUsPage.GetGetInTouchHeaderText());
            Assert.That(contactUsPage.FillData(contactMessage).GetSuccessMessageText(), Is.EqualTo("Success! Your details have been submitted successfully."), "Message should has: 'Success! Your details have been submitted successfully.' but was " + contactUsPage.GetSuccessMessageText());
            homePage.ClickMenuOption("Home");
        }
    }
}
