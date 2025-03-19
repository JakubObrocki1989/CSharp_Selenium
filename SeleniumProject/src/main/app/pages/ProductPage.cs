using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.app.pages.modals;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class ProductPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='product-information']/h2")]
        IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//div[@class='product-information']/p")]
        IWebElement ProductCategory;

        [FindsBy(How = How.XPath, Using = "//div[@class='product-information']/span/span")]
        IWebElement ProductPrice;

        [FindsBy(How = How.XPath, Using = "(//div[@class='product-information']//p)[2]")]
        IWebElement ProductAvailability;

        [FindsBy(How = How.XPath, Using = "(//div[@class='product-information']//p)[3]")]
        IWebElement ProductCondition;

        [FindsBy(How = How.XPath, Using = "(//div[@class='product-information']//p)[4]")]
        IWebElement ProductBrand;

        [FindsBy(How = How.Id, Using = "quantity")]
        IWebElement QuantityInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default cart']")]
        IWebElement AddToCartButton;

        [FindsBy(How = How.Id, Using = "name")]
        IWebElement NameInput;

        [FindsBy(How = How.Id, Using = "email")]
        IWebElement EmailInput;

        [FindsBy(How = How.Id, Using = "review")]
        IWebElement ReviewTextarea;

        [FindsBy(How = How.Id, Using = "button-review")]
        IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='alert-success alert']")]
        IWebElement SuccessAlert;

        public ProductPage(IWebDriver driver) : base(driver) { }

        public string GetProductName()
        {
            return ProductName.Text;
        }

        public string GetProductCategory()
        {
            return ProductCategory.Text;
        }

        public string GetProductPrice()
        {
            return ProductPrice.Text;
        }

        public string GetProductAvailability()
        {
            return ProductAvailability.Text;
        }

        public string GetProductCondition()
        {
            return ProductCondition.Text;
        }

        public string GetProductBrand()
        {
            return ProductBrand.Text;
        }

        public ProductPage SetQuantity(string quantity)
        {
            SendKeys(QuantityInput, quantity);
            return this;
        }

        public CartModalPage AddToCart()
        {
            ClickElement(AddToCartButton);
            IWebElement modal = driver.FindElement(By.ClassName("modal-content"));
            return new CartModalPage(driver, modal);
        }

        public ProductPage WriteAReview(Review review)
        {
            SendKeys(NameInput, review.name);
            SendKeys(EmailInput, review.email);
            SendKeys(ReviewTextarea, review.review);
            ClickElement(SubmitButton);
            return this;
        }

        public string GetReviewAddedText()
        {
            return SuccessAlert.Text;
        }
    }
}
