using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class AccountCreatedPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//h2[@data-qa='account-created']")]
        private IWebElement AccountCreatedHeader;

        [FindsBy(How = How.XPath, Using = "//a[@data-qa='continue-button']")]
        private IWebElement ContinueButton;

        public AccountCreatedPage(IWebDriver driver) : base(driver) { }

        public bool IsAccountCreatedHeaderVisible()
        {
            return IsElementVisible(AccountCreatedHeader);
        }

        public string GetAccountCreatedHeaderText()
        {
            return AccountCreatedHeader.Text;
        }

        public HomePage ClickContinueButton()
        {
            ClickElement(ContinueButton);
            return new HomePage(driver);
        }
    }
}
