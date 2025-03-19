using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;
using SeleniumProject.src.main.core.utils;

namespace SeleniumProject.src.main.app.pages
{
    class PaymentDonePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//h2[@data-qa='order-placed']/following-sibling::p")]
        IWebElement OrderPlacedText;

        [FindsBy(How = How.XPath, Using = "//a[@class='btn btn-default check_out']")]
        IWebElement DownloadInvoiceButton;

        [FindsBy(How = How.XPath, Using = "//a[@data-qa='continue-button']")]
        IWebElement ContinueButton;

        public PaymentDonePage(IWebDriver driver) : base(driver) { }

        public string GetSuccessMessageText()
        {
            WaitForElementToBeDisplayed(OrderPlacedText);
            return OrderPlacedText.Text;
        }

        public PaymentDonePage DownloadInvoice()
        {
            WaitForElementToBeClickable(DownloadInvoiceButton);
            ClickElement(DownloadInvoiceButton);
            FileHandler.WaitForDownload("invoice.txt");
            return this;
        }

        public HomePage ClickContinueButton()
        {
            ClickElement(ContinueButton);
            return new HomePage(driver);
        }
    }
}
