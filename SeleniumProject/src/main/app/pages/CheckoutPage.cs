using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class CheckoutPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//ul[@id='address_delivery']//li")]
        IList<IWebElement> DeliverAddressDetails;

        [FindsBy(How = How.XPath, Using = "//ul[@id='address_invoice']//li")]
        IList<IWebElement> InvoiceAddressDetails;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='message']")]
        IWebElement DescriptionTextArea;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default check_out']")]
        IWebElement PlaceOrderButton;

        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public List<string> GetDeliveryAddressDetails()
        {
            return DeliverAddressDetails.Select(e => e.Text).ToList();
        }

        public List<string> GetInvoiceAddressDetails()
        {
            return InvoiceAddressDetails.Select(e => e.Text).ToList();
        }

        public CheckoutPage TypeDescription(string text)
        {
            SendKeys(DescriptionTextArea, text);
            return this;
        }

        public PaymentPage ClickPlaceOrder()
        {
            ClickElement(PlaceOrderButton);
            return new PaymentPage(driver);
        }
    }
}
