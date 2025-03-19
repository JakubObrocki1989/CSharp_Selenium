using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class LoginSignupPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@data-qa='signup-name']")]
        IWebElement NameInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='signup-email']")]
        IWebElement MailInput;

        [FindsBy(How = How.XPath, Using = "//button[@data-qa='signup-button']")]
        IWebElement SignupButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='signup-form']/h2")]
        IWebElement SignupHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='signup-form']//p")]
        IWebElement SignupEmailExistErrorHeader;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='login-email']")]
        IWebElement LoginEmailInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='login-password']")]
        IWebElement LoginPasswordInput;

        [FindsBy(How = How.XPath, Using = "//button[@data-qa='login-button']")]
        IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='login-form']//p")]
        IWebElement WrongCredentialsMessage;

        public LoginSignupPage(IWebDriver driver) : base(driver) { }

        public bool IsSignupHeaderVisible()
        {
            return IsElementVisible(SignupHeader);
        }

        public LoginSignupPage FillSignUp(string name, string email)
        {
            SendKeys(NameInput, name);
            SendKeys(MailInput, email);
            return this;
        }

        public LoginSignupPage FillLogin(string email, string password)
        {
            SendKeys(LoginEmailInput, email);
            SendKeys(LoginPasswordInput, password);
            return this;
        }

        public HomePage ClickLogin()
        {
            ClickElement(LoginButton);
            return new HomePage(driver);
        }

        public LoginSignupPage ClickSignup()
        {
            ClickElement(SignupButton);
            return this;
        }

        public bool IsEmailExistMessageVisible()
        {
            return IsElementVisible(SignupEmailExistErrorHeader);
        }

        public string GetEmailExistMessageText()
        {
            return SignupEmailExistErrorHeader.Text;
        }

        public bool IsWrongCredentialsMessageVisible()
        {
            return IsElementVisible(WrongCredentialsMessage);
        }

        public string GetWrongCredentialsMessageText()
        {
            return WrongCredentialsMessage.Text;
        }
    }
}
