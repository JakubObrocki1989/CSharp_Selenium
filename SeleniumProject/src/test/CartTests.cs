using System.Linq;
using NUnit.Framework;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class CartTests : BaseTest
    {

        [Test]
        public void test0001_addProductsCheckCartLoginAndCheckCartAgain()
        {
            createUserToLogin();
            homePage.ClickMenuOption(" Products");
            Assert.That(productsPage.SearchItem("Top for women").GetProductCount(), Is.EqualTo(2), "There should be 2 product but was: " + productsPage.GetProductCount());
            productsPage.AddAllVisibleProducts();
            homePage.ClickMenuOption("Cart");
            Assert.That(cartPage.GetProductsCount(), Is.EqualTo(2), "Product list size should be: 2 but was: " + cartPage.GetProductsCount());
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(TestData.GetUserById("automationuser").Email, TestData.GetUserById("automationuser").Password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + TestData.GetUserById("automationuser").Username), Is.True, "Logged in as " + TestData.GetUserById("automationuser").Username + " should be visible, but was not");
            homePage.ClickMenuOption("Cart");
            Assert.That(cartPage.GetProductsCount(), Is.EqualTo(2), "Product list size should be: 2 but was: " + cartPage.GetProductsCount());
        }

        [Test]
        public void test0002_addRecomendedItemsToCart()
        {
            ProductDetails productDetails = homePage.GetProductDetails();
            homePage.AddRecomenndedItemToCart().ClickViewCart();
            CartItem cartItem = cartPage.GetCartItemList().First();
            Assert.Multiple(() =>
            {
                Assert.That(productDetails.name, Is.EqualTo(cartItem.name));
                Assert.That(productDetails.price, Is.EqualTo(cartItem.price));
                Assert.That(int.Parse(productDetails.price.Replace("Rs. ", "")), Is.EqualTo(int.Parse(cartItem.price.Replace("Rs. ", "")) * int.Parse(cartItem.quantity)));
            });
        }
    }
}
