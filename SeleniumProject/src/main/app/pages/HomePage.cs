using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.app.pages.modals;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class HomePage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "logo")]
        private IWebElement Logo;

        [FindsBy(How = How.CssSelector, Using = "div[class='shop-menu pull-right'] a")]
        private IList<IWebElement> ShopMenu;

        [FindsBy(How = How.XPath, Using = "//div[@class='footer-widget']//h2")]
        private IWebElement SubscriptionHeader;

        [FindsBy(How = How.Id, Using = "susbscribe_email")]
        private IWebElement SubscribeEmailInput;

        [FindsBy(How = How.Id, Using = "subscribe")]
        private IWebElement SubscribeButton;

        [FindsBy(How = How.Id, Using = "success-subscribe")]
        private IWebElement SuccessSubscribeMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='carousel-inner']//div[@class='single-products']")]
        private IList<IWebElement> RecommendedItems;

        [FindsBy(How = How.XPath, Using = "//div[@class='single-products']//h2")]
        private IWebElement RecommendedItemPrice;

        [FindsBy(How = How.XPath, Using = "//div[@class='single-products']//p")]
        private IWebElement RecommendedItemName;

        [FindsBy(How = How.XPath, Using = "//div[@class='carousel-inner']//div[@class='single-products']//a[@class='btn btn-default add-to-cart']")]
        private IWebElement RecommendedItemAddToCartButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='carousel-inner']//h2")]
        private IWebElement FullFledgedHeader;


        public HomePage(IWebDriver driver) : base(driver) { }

        public bool IsLogoVisible()
        {
            WaitForPageToLoad();
            return Logo.Displayed;
        }

        public HomePage ClickMenuOption(string menuOption)
        {
            WaitForPageToLoad();
            IWebElement menuButton = ShopMenu.Where(o => o.Text.Contains(menuOption)).First();
            ClickElement(menuButton);
            return this;
        }

        public bool IsMenuOptionVisible(string menuOption)
        {
            return ShopMenu.Where(o => o.Text.Equals(menuOption)).First().Displayed;
        }

        public string GetSubscriptionHeaderText()
        {
            return SubscriptionHeader.Text;
        }

        public HomePage Subscribe(string email)
        {
            SendKeys(SubscribeEmailInput, email);
            ClickElement(SubscribeButton);
            return this;
        }

        public string GetSubscriptionSuccessText()
        {
            return SuccessSubscribeMessage.Text;
        }

        public ProductDetails GetProductDetails()
        {
            WaitForPageToLoad();
            ProductDetails productDetails = new ProductDetailsBuilder()
            .SetName(RecommendedItems.Where(e => e.Displayed).First().FindElement(By.XPath(".//p")).Text)
            .SetPrice(RecommendedItems.Where(e => e.Displayed).First().FindElement(By.XPath(".//h2")).Text)
            .Build();

            return productDetails;
        }

        public CartModalPage AddRecomenndedItemToCart()
        {
            ClickElement(RecommendedItems.Where(e => e.Displayed).First().FindElement(By.XPath(".//a[@class='btn btn-default add-to-cart']")));
            IWebElement modal = driver.FindElement(By.ClassName("modal-content"));
            return new CartModalPage(driver, modal);
        }

        public bool IsSubscriptionHeaderVisible()
        {
            ScrollToElement(SubscriptionHeader);
            return IsElementVisible(SubscriptionHeader);
        }

        public bool IsFullFledgedHeaderVisible()
        {
            return IsElementVisible(FullFledgedHeader);
        }

        public HomePage ClickScrollUpArrow()
        {
            IWebElement element = driver.FindElement(By.Id("scrollUp"));
            WaitForElementToBeClickable(element);
            ClickElement(element);
            return this;
        }

        public HomePage ScrollToTop()
        {
            ScrollToElement(FullFledgedHeader);
            return this;
        }


    }
}
