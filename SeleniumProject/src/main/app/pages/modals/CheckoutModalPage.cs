using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages.modals
{
    class CheckoutModalPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-footer']/button")]
        IWebElement ContinueOnCartButton;
        
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-body']/p/a")]
        IWebElement RegisterLoginLink;

        public CheckoutModalPage(IWebDriver driver, IWebElement element) : base(driver) { }

        public LoginSignupPage ClickRegisterLoginButton()
        {
            ClickElement(RegisterLoginLink);
            return new LoginSignupPage(driver);
        }
    }
}
