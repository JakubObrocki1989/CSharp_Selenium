using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class SignupPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//b[text()='Enter Account Information']")]
        IWebElement EnterAccountInformationHeader;

        [FindsBy(How = How.XPath, Using = "//input[@type='radio']")]
        IList<IWebElement> GenderRadios;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//select[@data-qa='days']")]
        IWebElement DaysSelect;

        [FindsBy(How = How.XPath, Using = "//select[@data-qa='months']")]
        IWebElement MonthsSelect;

        [FindsBy(How = How.XPath, Using = "//select[@data-qa='years']")]
        IWebElement YearsSelect;

        [FindsBy(How = How.Id, Using = "newsletter")]
        IWebElement NewsletterCheckbox;

        [FindsBy(How = How.Id, Using = "optin")]
        IWebElement OptinCheckbox;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='first_name']")]
        IWebElement FirstNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='last_name']")]
        IWebElement LastNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='company']")]
        IWebElement CompanyInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='address']")]
        IWebElement AddressInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='address2']")]
        IWebElement Address2Input;

        [FindsBy(How = How.XPath, Using = "//select[@data-qa='country']")]
        IWebElement CountrySelect;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='state']")]
        IWebElement StateInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='city']")]
        IWebElement CityInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='zipcode']")]
        IWebElement ZipcodeInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='mobile_number']")]
        IWebElement MobileNumberInput;

        [FindsBy(How = How.XPath, Using = "//button[@data-qa='create-account']")]
        IWebElement CreateAccountButton;

        public SignupPage(IWebDriver driver) : base(driver) { }

        public bool IsEnterAccountInformationHeaderVisible()
        {
            return IsElementVisible(EnterAccountInformationHeader);
        }

        public string GetEnterAccountInformationHeaderText()
        {
            return EnterAccountInformationHeader.Text;
        }

        public AccountCreatedPage FillSignUpDetails(RegisterUser registerUser)
        {
            GenderRadios.Where(o => o.GetAttribute("value").Equals(registerUser.gender)).First().Click();
            SendKeys(PasswordInput, registerUser.password);
            SelectByText(DaysSelect, registerUser.day);
            SelectByText(MonthsSelect, registerUser.month);
            SelectByText(YearsSelect, registerUser.year);
            SelectCheckbox(NewsletterCheckbox, registerUser.signUpForNewsletter);
            SelectCheckbox(OptinCheckbox, registerUser.receiveSpecialOffers);
            SendKeys(FirstNameInput, registerUser.firstName);
            SendKeys(LastNameInput, registerUser.lastName);
            SendKeys(CompanyInput, registerUser.company);
            SendKeys(AddressInput, registerUser.address);
            SendKeys(Address2Input, registerUser.address2);
            SelectByText(CountrySelect, registerUser.country);
            SendKeys(StateInput, registerUser.state);
            SendKeys(CityInput, registerUser.city);
            SendKeys(ZipcodeInput, registerUser.zipcode);
            SendKeys(MobileNumberInput, registerUser.mobile);
            ClickElement(CreateAccountButton);
            return new AccountCreatedPage(driver);
        }
    }
}
