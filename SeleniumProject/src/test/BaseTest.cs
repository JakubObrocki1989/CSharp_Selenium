using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFramework.util;
using SeleniumProject.src.main.api.factories;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.app.pages;
using SeleniumProject.src.main.core.driver;
using SeleniumProject.src.main.core.utils;

namespace SeleniumProject.src.test
{
    class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage homePage;
        protected LoginSignupPage loginSignupPage;
        protected SignupPage signupPage;
        protected AccountCreatedPage accountCreatedPage;
        protected AccountDeletedPage accountDeletedPage;
        protected ContactUsPage contactUsPage;
        protected ProductsPage productsPage;
        protected ProductPage productPage;
        protected CartPage cartPage;
        protected CheckoutPage checkoutPage;
        protected PaymentPage paymentPage;
        protected TestCasesPage testCasesPage;
        protected PaymentDonePage paymentDonePage;
        DriverFactory driverFactory = new DriverFactory();
        protected TestDataManager TestData = null;


        static public void createUserToLogin()
        {
            DataFactory.createAutomationTestsUser();
        }

        static public void createUserToLogin(RegisterUser registerUser)
        {
            DataFactory.createAutomationTestsUser(registerUser);
        }

        public void clearDownloadsFolder()
        {
            FileHandler.DeleteFiles(TestDataManager.GetInstance.GetDownloadPath());
        }

        [SetUp]
        public void setupTest()
        {
            TestData = TestDataManager.GetInstance;
            driver = driverFactory.create();
            driver.Navigate().GoToUrl(TestData.environments.AppUrl);
            WaitForExtensionInstallationComplete(driver);
            homePage = new HomePage(driver);
            loginSignupPage = new LoginSignupPage(driver);
            signupPage = new SignupPage(driver);
            accountCreatedPage = new AccountCreatedPage(driver);
            accountDeletedPage = new AccountDeletedPage(driver);
            contactUsPage = new ContactUsPage(driver);
            productsPage = new ProductsPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            paymentPage = new PaymentPage(driver);
            testCasesPage = new TestCasesPage(driver);
            paymentDonePage = new PaymentDonePage(driver);
        }

        [TearDown]
        public void tearDown()
        {
            driverFactory.closeDriver();
        }

        private static void WaitForExtensionInstallationComplete(IWebDriver driver)
        {
            var windowHandles = driver.WindowHandles;
            while (windowHandles.Count == 1)
            {
                Thread.Sleep(1000);
                windowHandles = driver.WindowHandles;
            }
            if (windowHandles.Count == 2)
            {
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }
    }
}
