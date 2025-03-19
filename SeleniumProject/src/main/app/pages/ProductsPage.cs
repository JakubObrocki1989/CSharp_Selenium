using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.app.pages.modals;
using SeleniumProject.src.main.core.baseObjects;

namespace SeleniumProject.src.main.app.pages
{
    class ProductsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='features_items']/h2")]
        IWebElement ProductsHeader;

        [FindsBy(How = How.XPath, Using = "//div[@class='features_items']/div[@class='col-sm-4']")]
        IList<IWebElement> ProductsList;

        [FindsBy(How = How.Id, Using = "search_product")]
        IWebElement SearchInput;

        [FindsBy(How = How.Id, Using = "submit_search")]
        IWebElement SubmitSearchButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel-group category-products']//a")]
        IList<IWebElement> CategoriesList;

        [FindsBy(How = How.XPath, Using = "//div[@class='brands-name']//a")]
        IList<IWebElement> BrandsList;

        public ProductsPage(IWebDriver driver) : base(driver) { }

        public bool IsProductsHeaderVisible()
        {
            return IsElementVisible(ProductsHeader);
        }

        public string GetProductsHeaderText()
        {
            return ProductsHeader.Text;
        }

        public ProductPage ClickOnViewProduct(int productIndex)
        {
            ClickElement(ProductsList[productIndex].FindElement(By.XPath(".//div[@class='choose']")));
            return new ProductPage(driver);
        }

        public ProductDetails GetProductInfo(int productIndex)
        {
            ProductDetails productDetails = new ProductDetailsBuilder()
            .SetName(ProductsList[productIndex].FindElement(By.XPath(".//div[@class='productinfo text-center']/p")).Text)
            .SetPrice(ProductsList[productIndex].FindElement(By.XPath(".//div[@class='productinfo text-center']/h2")).Text)
            .Build();
            return productDetails;

        }


        public CartModalPage AddProductToCart(int productIndex)
        {
            HoverOverElement(ProductsList[productIndex]);
            ClickElement(ProductsList[productIndex].FindElement(By.XPath(".//div[@class='product-overlay']//a")));
            IWebElement modal = driver.FindElement(By.ClassName("modal-content"));
            return new CartModalPage(driver, modal);
        }

        public ProductsPage AddAllVisibleProducts()
        {
            foreach (IWebElement element in ProductsList)
            {
                HoverOverElement(element);
                ClickElement(element.FindElement(By.XPath(".//div[@class='product-overlay']//a")));
                IWebElement modal = driver.FindElement(By.ClassName("modal-content"));
                new CartModalPage(driver, modal).ClickContinueShopping();
            }
            return this;
        }

        public ProductsPage SearchItem(string itemName)
        {
            SendKeys(SearchInput, itemName);
            ClickElement(SubmitSearchButton);
            return this;
        }

        public int GetProductCount()
        {
            return ProductsList.Count;
        }

        public ProductsPage OpenCategory(string categoryName)
        {
            ClickElement(CategoriesList.Where(o => o.Text.Equals(categoryName)).First());
            return this;
        }

        public ProductsPage OpenSubCategory(string subCategoryName)
        {
            bool isElementVisible = false;
            while (!isElementVisible)
            {
                IList<IWebElement> tmpList = driver.FindElements(By.XPath("//div[@class='panel-body']//a"));
                if (tmpList.Where(o => o.GetAttribute("innerText").Equals(subCategoryName)).First().Displayed)
                {
                    isElementVisible = true;
                }
                else
                {
                    isElementVisible = false;
                }


            }
            IList<IWebElement> subCategoriesList = driver.FindElements(By.XPath("//div[@class='panel-body']//a"));
            ClickElement(subCategoriesList.Where(o => o.Text.Equals(subCategoryName)).First());
            return this;
        }

        //@Step("Open brand")
        public ProductsPage OpenBrand(string brandName)
        {
            ClickElement(BrandsList.Where(o => o.Text.Contains(brandName)).First());
            return this;
        }
    }
}
