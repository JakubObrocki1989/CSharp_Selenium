using System;
using System.Collections.Generic;
using NUnit.Framework;
using SeleniumProject.src.main.app.factories;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class ProductsTests : BaseTest
    {
        ReviewFactory reviewFactory = new ReviewFactory();

        [Test]
        public void test0001_openAndVerifyProductDetail()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption(" Products");
            productsPage.ClickOnViewProduct(0);
            Assert.Multiple(() =>
            {
                Assert.That(productPage.GetProductName(), Is.Not.Empty);
                Assert.That(productPage.GetProductCategory(), Is.Not.Empty);
                Assert.That(productPage.GetProductPrice(), Is.Not.Empty);
                Assert.That(productPage.GetProductAvailability(), Is.Not.Empty);
                Assert.That(productPage.GetProductCondition(), Is.Not.Empty);
                Assert.That(productPage.GetProductBrand(), Is.Not.Empty);
            });
        }

        [Test]
        public void test0002_searchProduct()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption(" Products");
            Assert.That(productsPage.SearchItem("Sleeveless Dress").GetProductCount(), Is.EqualTo(1), "There should be 1 product but was: " + productsPage.GetProductCount());
        }

        [Test]
        public void test0003_addProductsToCart()
        {
            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption(" Products");
            IList<ProductDetails> productInfo = new List<ProductDetails> { productsPage.GetProductInfo(1), productsPage.GetProductInfo(2) };
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickViewCart();
            IList<CartItem> cartItems = cartPage.GetCartItemList();
            Assert.That(productInfo.Count, Is.EqualTo(cartItems.Count), "Product list and cart item list should have the same size");
            for (int i = 0; i < productInfo.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(productInfo[i].name, Is.EqualTo(cartItems[i].name));
                    Assert.That(productInfo[i].price, Is.EqualTo(cartItems[i].price));
                    Assert.That(int.Parse(productInfo[i].price.Replace("Rs. ", "")), Is.EqualTo(int.Parse(cartItems[i].price.Replace("Rs. ", "")) * int.Parse(cartItems[i].quantity)));
                });
            }
        }

        [Test]
        public void test0004_checkProductQuantityInCart()
        {
            homePage.ClickMenuOption(" Products");
            string currentQuantity = productsPage
                    .ClickOnViewProduct(3)
                    .SetQuantity("4")
                    .AddToCart()
                    .ClickViewCart()
                    .GetCartItemList()[0].quantity;
            Assert.That(int.Parse(currentQuantity), Is.EqualTo(4), "Chosen quantity should be 4 but was: " + cartPage.GetCartItemList()[0].quantity);
        }

        [Test]
        public void test0005_checkSubCategoryHeaders()
        {
            homePage.ClickMenuOption(" Products");
            productsPage.OpenCategory("WOMEN").OpenSubCategory("TOPS");
            Assert.That(productsPage.GetProductsHeaderText(), Is.EqualTo("WOMEN - TOPS PRODUCTS"), "Producs header should be: 'WOMEN - TOPS PRODUCTS' but was: " + productsPage.GetProductsHeaderText());
            productsPage.OpenCategory("MEN").OpenSubCategory("JEANS");
            Assert.That(productsPage.GetProductsHeaderText(), Is.EqualTo("MEN - JEANS PRODUCTS"), "Producs header should be: 'Men - Jeans Products' but was: " + productsPage.GetProductsHeaderText());
        }

        [Test]
        public void test0006_checkBrandHeaders()
        {
            homePage.ClickMenuOption(" Products");
            productsPage.OpenBrand("POLO");
            Assert.That(productsPage.GetProductsHeaderText(), Is.EqualTo("BRAND - POLO PRODUCTS"), "Producs header should be: 'BRAND - POLO PRODUCTS' but was: " + productsPage.GetProductsHeaderText());
            productsPage.OpenBrand("BABYHUG");
            Assert.That(productsPage.GetProductsHeaderText(), Is.EqualTo("BRAND - BABYHUG PRODUCTS"), "Producs header should be: 'Brand - Babyhug Products' but was: " + productsPage.GetProductsHeaderText());
        }

        [Test]
        public void test0007_writeReviewForProduct()
        {
            Review review = reviewFactory.getRandomReview();

            Assert.That(homePage.IsLogoVisible(), Is.True);
            homePage.ClickMenuOption(" Products");
            productsPage.ClickOnViewProduct(0).WriteAReview(review);
            Assert.That(productPage.GetReviewAddedText(), Is.EqualTo("Thank you for your review."), "Alert message should be: 'Thank you for your review.', but was: " + productPage.GetReviewAddedText());
        }
    }
}
