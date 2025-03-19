using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class TestCasesPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//h2[@class='title text-center']")]
        IWebElement TestCasesHeader;

        public TestCasesPage(IWebDriver driver) : base(driver) { }

        public bool IsTestCasesHeaderVisible()
        {
            return IsElementVisible(TestCasesHeader);
        }

        public string GetTestCasesHeaderText()
        {
            return TestCasesHeader.Text;
        }
    }
}
