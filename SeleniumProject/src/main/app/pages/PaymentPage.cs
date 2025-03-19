using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class PaymentPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@data-qa='name-on-card']")]
        IWebElement NameOnCardInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='card-number']")]
        IWebElement CardNumberInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='cvc']")]
        IWebElement CvcInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='expiry-month']")]
        IWebElement ExpiryMonthInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='expiry-year']")]
        IWebElement ExpiryYearInput;

        [FindsBy(How = How.Id, Using = "submit")]
        IWebElement PlaceAndConfirmButton;

        public PaymentPage(IWebDriver driver) : base(driver) { }

        public PaymentPage FillCardDetail(CreditCardDetails creditCardDetails)
        {
            SendKeys(NameOnCardInput, creditCardDetails.cardOwner);
            SendKeys(CardNumberInput, creditCardDetails.cardNumber);
            SendKeys(CvcInput, creditCardDetails.cvcNumber);
            SendKeys(ExpiryMonthInput, creditCardDetails.expiryMonth);
            SendKeys(ExpiryYearInput, creditCardDetails.expiryYear);
            return this;
        }

        public PaymentDonePage ClickPlaceAndConfirmButton()
        {
            ClickElement(PlaceAndConfirmButton);
            return new PaymentDonePage(driver);
        }
    }
}
