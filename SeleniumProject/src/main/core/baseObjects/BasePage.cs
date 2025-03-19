using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.utils;

namespace SeleniumProject.src.main.core.baseObjects
{
    class BasePage : BrowserActions
    {
        public BasePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

    }
}
