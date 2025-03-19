using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class AccountDeletedPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//h2[@data-qa='account-deleted']")]
        IWebElement AccountDeletedHeader;

        [FindsBy(How = How.XPath, Using = "//a[@data-qa='continue-button']")]
        IWebElement ContinueButton;

        public AccountDeletedPage(IWebDriver driver) : base(driver) { }

        public bool IsAccountDeletedHeaderVisible()
        {
            return IsElementVisible(AccountDeletedHeader);
        }

        public string GetAccountDeletedHeaderText()
        {
            return AccountDeletedHeader.Text;
        }

        public HomePage ClickContinueButton()
        {
            ClickElement(ContinueButton);
            return new HomePage(driver);
        }
    }
}
