using NUnit.Framework;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class LoginTests : BaseTest
    {
        [SetUp]
        public void init()
        {
            createUserToLogin();
        }

        [Test]
        public void test0001_loginWithCorrectCredentialsAndDeleteAccount()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(TestData.GetUserById("automationuser").Email, TestData.GetUserById("automationuser").Password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + TestData.GetUserById("automationuser").Username), Is.True, "Logged in as " + TestData.GetUserById("automationuser").Username + " should be visible, but was not");
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }
        [Test]
        public void test0002_loginWithIncorrectCredentials()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(TestData.GetUserById("wrongcredentialsuser").Email, TestData.GetUserById("wrongcredentialsuser").Password)
                    .ClickLogin();
            Assert.That(loginSignupPage.IsWrongCredentialsMessageVisible(), Is.True, "Your email or password is incorrect! message should be visible, but was not");
            Assert.That(loginSignupPage.GetWrongCredentialsMessageText(), Is.EqualTo("Your email or password is incorrect!"), "Your email or password is incorrect! message should has 'Your email or password is incorrect! message should' but was: " + loginSignupPage.GetWrongCredentialsMessageText());
        }
        [Test]
        public void test0003_loginWithCorrectCredentialsAndLogout()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(TestData.GetUserById("automationuser").Email, TestData.GetUserById("automationuser").Password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + TestData.GetUserById("automationuser").Username), Is.True, "Logged in as " + TestData.GetUserById("automationuser").Username + " should be visible, but was not");
            homePage.ClickMenuOption("Logout");
        }
    }
}
