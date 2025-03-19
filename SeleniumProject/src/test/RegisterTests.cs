using NUnit.Framework;
using SeleniumProject.src.main.app.factories;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class RegisterTests : BaseTest
    {
        RegisterUserFactory registerUserFactory = new RegisterUserFactory();


        [Test]
        public void test0001_userShouldBeRegistered()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillSignUp(registerUser.username, registerUser.email)
                    .ClickSignup();
            Assert.That(signupPage.IsEnterAccountInformationHeaderVisible(), Is.True, "Enter account information header should be visible, but was not");
            Assert.That(signupPage.GetEnterAccountInformationHeaderText(), Is.EqualTo("ENTER ACCOUNT INFORMATION"), "Header should has: ENTER ACCOUNT INFORMATION but was:" + signupPage.GetEnterAccountInformationHeaderText());
            Assert.That(signupPage.FillSignUpDetails(registerUser).IsAccountCreatedHeaderVisible(), Is.True, "Account created header should be visible, but was not");
            Assert.That(accountCreatedPage.GetAccountCreatedHeaderText(), Is.EqualTo("ACCOUNT CREATED!"), "Account created message should has: ACCOUNT CREATED! but was: " + accountCreatedPage.GetAccountCreatedHeaderText());
            Assert.That(accountCreatedPage.ClickContinueButton().IsMenuOptionVisible("Logged in as " + registerUser.username), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }

        [Test]
        public void test0002_userShouldNotBeAbleToRegisterUsingExistingEmail()
        {
            createUserToLogin();
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillSignUp("test", "automation-ui@sampledomain.com")
                    .ClickSignup();
            Assert.That(loginSignupPage.IsEmailExistMessageVisible(), Is.True, "Enter account information header should be visible, but was not");
            Assert.That(loginSignupPage.GetEmailExistMessageText(), Is.EqualTo("Email Address already exist!"), "Email already exist message should has : Email Address already exist! but was:" + loginSignupPage.GetEmailExistMessageText());

        }
    }
}
