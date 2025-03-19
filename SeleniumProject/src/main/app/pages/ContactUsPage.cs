using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class ContactUsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='contact-form']//h2")]
        IWebElement GetInTouchHeader;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='name']")]
        IWebElement NameInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='email']")]
        IWebElement EmailInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='subject']")]
        IWebElement SubjectInput;

        [FindsBy(How = How.XPath, Using = "//textarea[@data-qa='message']")]
        IWebElement MessageTextarea;

        [FindsBy(How = How.XPath, Using = "//input[@name='upload_file']")]
        IWebElement UploadFileInput;

        [FindsBy(How = How.XPath, Using = "//input[@data-qa='submit-button']")]
        IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='status alert alert-success']")]
        IWebElement SuccessMessage;

        public ContactUsPage(IWebDriver driver) : base(driver) { }

        public bool IsGetInTouchHeaderVisible()
        {
            return IsElementVisible(GetInTouchHeader);
        }

        public string GetGetInTouchHeaderText()
        {
            return GetInTouchHeader.Text;
        }

        public ContactUsPage FillData(ContactMessage contactMessage)
        {
            SendKeys(NameInput, contactMessage.name);
            SendKeys(EmailInput, contactMessage.email);
            SendKeys(SubjectInput, contactMessage.subject);
            SendKeys(MessageTextarea, contactMessage.message);
            SendKeys(UploadFileInput, contactMessage.filePath);
            ClickElement(SubmitButton, true);
            return this;
        }

        public string GetSuccessMessageText()
        {
            WaitForPageToLoad();
            return SuccessMessage.Text;
        }
    }
}
