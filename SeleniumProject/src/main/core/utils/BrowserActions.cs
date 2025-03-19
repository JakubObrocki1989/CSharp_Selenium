using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.util;

namespace SeleniumProject.src.main.core.utils
{
    class BrowserActions
    {
        private static BrowserConfig config = TestDataManager.GetInstance.browserConfig;
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;
        protected IJavaScriptExecutor jse;
        private bool extensionInstalled = false;
        Actions actions;

        public BrowserActions(IWebDriver webDriver)
        {
            this.driver = webDriver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            this.actions = new Actions(driver);
            this.jse = (IJavaScriptExecutor)driver;
        }

        public void WaitForPageToLoad()
        {
            wait.Until(driver => jse.ExecuteScript("return document.readyState").Equals("complete"));
            AcceptConsant();
        }


        public void Highlight(IWebElement element)
        {
            jse.ExecuteScript("arguments[0].style.border='3px solid red'", element);
        }

        public void ClickElement(IWebElement element)
        {
            ClickElement(element, false);
        }

        public void ClickElement(IWebElement element, bool isAlertExpected)
        {
            WaitForElementToBeClickable(element);
            element.Click();
            if (isAlertExpected)
            {
                AcceptAlert();
            }
            WaitForPageToLoad();
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForElementToBeDisplayed(IWebElement element)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void SendKeys(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public bool IsElementVisible(IWebElement element)
        {
            WaitForElementToBeDisplayed(element);
            return element.Displayed;
        }

        public void SelectByText(IWebElement element, string text)
        {
            ClickElement(element);
            IList<IWebElement> selectOptions = element.FindElements(By.XPath("./option"));
            ClickElement(selectOptions.Where(o => o.Text.Equals(text)).First());
        }

        public void SelectCheckbox(IWebElement element, bool value)
        {
            if (element.Selected != value)
            {
                element.Click();
            }
        }

        public bool IsAlertPresent()
        {
            return wait.Until(d =>
                {
                    try
                    {
                        d.SwitchTo().Alert();
                        return true;
                    }
                    catch (Exception ex) when (
                    ex is WebDriverTimeoutException || ex is NoAlertPresentException)
                    {
                        return false;
                    }
                });
        }

        public bool IsConsantModalPresent()
        {
            bool isFound = false;
            int counter = 0;
            while (!isFound || counter == 5)
            {
                try
                {
                    driver.FindElement(By.XPath("//button[@class='fc-button fc-cta-consent fc-primary-button']"));
                    isFound = true;
                    return isFound;
                }
                catch (Exception ex) when (
                    ex is WebDriverTimeoutException || ex is NoSuchElementException)
                {
                    isFound = false;
                    return isFound;
                }
                Thread.Sleep(1000);
                counter++;

            }
            return isFound;
        }

        public void AcceptAlert()
        {
            if (IsAlertPresent())
            {
                driver.SwitchTo().Alert().Accept();
            }
        }

        public void AcceptConsant()
        {
            if (IsConsantModalPresent())
            {
                driver.FindElement(By.XPath("//button[@class='fc-button fc-cta-consent fc-primary-button']")).Click();
            }
        }

        public void HoverOverElement(IWebElement element)
        {
            actions.MoveToElement(element).Perform();
        }

        public void ScrollToElement(IWebElement element)
        {
            actions.ScrollToElement(element).Perform();
        }

    }
}
