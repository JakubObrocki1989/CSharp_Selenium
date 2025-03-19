using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.app.pages.modals;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class CartPage : BasePage
    {
        IList<CartItem> cartItemsList = new List<CartItem>();

        [FindsBy(How = How.XPath, Using = "//table[@id='cart_info_table']/tbody/tr")]
        IList<IWebElement> CartItems;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default check_out']")]
        IWebElement ProceedToCheckoutButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='cart_quantity_delete']")]
        IList<IWebElement> DeleteProductButtonList;


        public CartPage(IWebDriver driver) : base(driver) { }

        //@Step("Get cart items list")
        public IList<CartItem> GetCartItemList()
        {
            foreach (IWebElement element in CartItems)
            {
                CartItemBuilder cartItemsListBuilder = new CartItemBuilder();
                cartItemsListBuilder.SetName(element.FindElement(By.XPath(".//td[@class='cart_description']/h4/a")).Text);
                cartItemsListBuilder.SetPrice(element.FindElement(By.XPath(".//td[@class='cart_price']/p")).Text);
                cartItemsListBuilder.SetQuantity(element.FindElement(By.XPath(".//td[@class='cart_quantity']/button")).Text);
                cartItemsListBuilder.SetTotalPrice(element.FindElement(By.XPath(".//td[@class='cart_total']/p")).Text);
                CartItem cartItem = cartItemsListBuilder.Build();
                cartItemsList.Add(cartItemsListBuilder.Build());
            }
            return cartItemsList;
        }

        public CheckoutModalPage ProceedToCheckoutModal()
        {
            ClickElement(ProceedToCheckoutButton);
            IWebElement modal = driver.FindElement(By.ClassName("modal-content"));
            return new CheckoutModalPage(driver, modal);
        }

        public CheckoutPage ProceedToCheckout()
        {
            ClickElement(ProceedToCheckoutButton);
            return new CheckoutPage(driver);
        }

        public int GetProductsCount()
        {
            IList<IWebElement> CartItems = driver.FindElements(By.XPath("//a[@class='cart_quantity_delete']"));
            return CartItems.Count;
        }

        public CartPage DeleteProduct()
        {
            int listSize = GetProductsCount();
            bool isSizeChanged = false;
            ClickElement(DeleteProductButtonList[0]);
            while (!isSizeChanged)
            {

                if (GetProductsCount() < listSize)
                {
                    isSizeChanged = true;
                }
                else
                {
                    isSizeChanged = false;
                }
                Thread.Sleep(1000);
            }
            return this;
        }
    }
}
