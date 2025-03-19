using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages.modals
{
    class CartModalPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-footer']/button")]
        IWebElement ContinueShoppingButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-body']/p/a")]
        IWebElement ViewCartLink;

        public CartModalPage(IWebDriver driver, IWebElement element) : base(driver) { }

        public ProductsPage ClickContinueShopping()
        {
            WaitForPageToLoad();
            WaitForElementToBeClickable(ContinueShoppingButton);
            Highlight(ContinueShoppingButton);
            ClickElement(ContinueShoppingButton);
            return new ProductsPage(driver);
        }

        public CartPage ClickViewCart()
        {
            WaitForPageToLoad();
            WaitForElementToBeClickable(ViewCartLink);
            Highlight(ViewCartLink);
            ClickElement(ViewCartLink);
            return new CartPage(driver);
    }
}


    }
