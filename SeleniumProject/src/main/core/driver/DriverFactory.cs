using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using SeleniumFramework.util;

namespace SeleniumProject.src.main.core.driver
{
    class DriverFactory
    {
        IWebDriver driver;
        public IWebDriver create()
        {

            string name = TestDataManager.GetInstance.browserConfig.Name;
            try
            {
                switch (name.ToUpper())
                {
                    case "CHROME":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        setupDownloadOptions(chromeOptions);
                        setupChromiumOptions(chromeOptions);
                        driver = new ChromeDriver(chromeOptions);
                        break;
                    case "EDGE":
                        EdgeOptions edgeOptions = new EdgeOptions();
                        setupChromiumOptions(edgeOptions);
                        driver = new EdgeDriver(edgeOptions);
                        break;
                    default:
                        throw new Exception("Browser {} is not supported yet.");
                }
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
            }
            return driver;
        }

        public void closeDriver()
        {
            driver.Quit();
        }

        public static void setupChromiumOptions(ChromiumOptions options)
        {
            options.AddExtension(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../src/main/resources/ublock.crx")));
            options.AddArguments("--start-maximized");
            options.AddArguments("window-size=" + TestDataManager.GetInstance.browserConfig.Size); options.AddArguments("--remote-allow-origins=*");
            options.AddArguments("--disable-search-engine-choice-screen");
            options.AcceptInsecureCertificates = true;


        }

        private static void setupDownloadOptions(ChromiumOptions options)
        {
            options.AddUserProfilePreference("download.default_directory", TestDataManager.GetInstance.GetDownloadPath());
            options.AddArguments("--safebrowsing-disable-download-protection");
            options.AddArguments("--safebrowsing-disable-extension-blacklist");
        }
    }
}
