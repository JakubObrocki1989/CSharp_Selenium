using System;
using NUnit.Framework;
using SeleniumProject.src.main.app.factories;
using SeleniumProject.src.main.app.models;
using SeleniumProject.src.main.core.utils;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class OrderTests : BaseTest
    {
        RegisterUserFactory registerUserFactory = new RegisterUserFactory();
        CreditCardDetailsFactory creditCardDetailsFactory = new CreditCardDetailsFactory();

        [Test]
        public void test0001_placeOrderRegisterWhileCheckout()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();
            homePage.ClickMenuOption(" Products");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckoutModal()
                    .ClickRegisterLoginButton()
                    .FillSignUp(registerUser.username, registerUser.email)
                    .ClickSignup();
            Assert.That(signupPage.FillSignUpDetails(registerUser).IsAccountCreatedHeaderVisible(), Is.True, "Account created header should be visible, but was not");
            Assert.That(accountCreatedPage.ClickContinueButton().IsMenuOptionVisible("Logged in as " + registerUser.username), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckout()
                    .TypeDescription(Faker.Internet.DomainWord());
            CheckoutCustomerAddress checkout = new CheckoutCustomerAddress(checkoutPage.GetDeliveryAddressDetails());
            Assert.Multiple(() =>
            {
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(checkout.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(checkout.company));
                Assert.That(registerUser.address, Is.EqualTo(checkout.address));
                Assert.That(registerUser.address2, Is.EqualTo(checkout.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(checkout.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(checkout.country));
                Assert.That(registerUser.mobile, Is.EqualTo(checkout.mobile));
            });
            Assert.That(checkoutPage.ClickPlaceOrder().FillCardDetail(creditCardDetails).ClickPlaceAndConfirmButton().GetSuccessMessageText(), Is.EqualTo("Congratulations! Your order has been confirmed!"), "Success message should be 'Congratulations! Your order has been confirmed!!'");
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }

        [Test]
        public void test0002_placeOrderRegisterBeforeCheckout()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();

            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillSignUp(registerUser.username, registerUser.email)
                    .ClickSignup();
            Assert.That(signupPage.IsEnterAccountInformationHeaderVisible(), Is.True, "Enter account information header should be visible, but was not");
            Assert.That(signupPage.GetEnterAccountInformationHeaderText(), Is.EqualTo("ENTER ACCOUNT INFORMATION"), "Header should has: ENTER ACCOUNT INFORMATION but was:" + signupPage.GetEnterAccountInformationHeaderText());
            Assert.That(signupPage.FillSignUpDetails(registerUser).IsAccountCreatedHeaderVisible(), Is.True, "Account created header should be visible, but was not");
            Assert.That(accountCreatedPage.GetAccountCreatedHeaderText(), Is.EqualTo("ACCOUNT CREATED!"), "Account created message should has: ACCOUNT CREATED! but was: " + accountCreatedPage.GetAccountCreatedHeaderText());
            Assert.That(accountCreatedPage.ClickContinueButton().IsMenuOptionVisible("Logged in as " + registerUser.username), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckout()
                    .TypeDescription(Faker.Lorem.Sentence());
            CheckoutCustomerAddress checkout = new CheckoutCustomerAddress(checkoutPage.GetDeliveryAddressDetails());
            Assert.Multiple(() =>
            {
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(checkout.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(checkout.company));
                Assert.That(registerUser.address, Is.EqualTo(checkout.address));
                Assert.That(registerUser.address2, Is.EqualTo(checkout.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(checkout.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(checkout.country));
                Assert.That(registerUser.mobile, Is.EqualTo(checkout.mobile));
            });
            Assert.That(checkoutPage
                            .ClickPlaceOrder()
                            .FillCardDetail(creditCardDetails)
                            .ClickPlaceAndConfirmButton()
                            .GetSuccessMessageText(), Is.EqualTo("Congratulations! Your order has been confirmed!"), "Success message should be 'Congratulations! Your order has been confirmed!!'");
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }

        [Test]
        public void test0003_loginBeforeCheckout()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();

            createUserToLogin(registerUser);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(registerUser.email, registerUser.password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + registerUser.firstName + " " + registerUser.lastName), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckout()
                    .TypeDescription(Faker.Internet.DomainName());
            CheckoutCustomerAddress checkout = new CheckoutCustomerAddress(checkoutPage.GetDeliveryAddressDetails());
            Assert.Multiple(() =>
            {
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(checkout.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(checkout.company));
                Assert.That(registerUser.address, Is.EqualTo(checkout.address));
                Assert.That(registerUser.address2, Is.EqualTo(checkout.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(checkout.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(checkout.country));
                Assert.That(registerUser.mobile, Is.EqualTo(checkout.mobile));
            });
            Assert.That(checkoutPage
                            .ClickPlaceOrder()
                            .FillCardDetail(creditCardDetails)
                            .ClickPlaceAndConfirmButton()
                            .GetSuccessMessageText(), Is.EqualTo("Congratulations! Your order has been confirmed!"), "Success message should be 'Congratulations! Your order has been confirmed!!'");
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }

        [Test]
        public void test0004_removeProductsFromCart()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();
            homePage.ClickMenuOption(" Products");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            Assert.That(cartPage.GetProductsCount(), Is.EqualTo(2), "Product list size should be: 2 but was: " + cartPage.GetProductsCount());
            cartPage.DeleteProduct();
            Assert.That(cartPage.GetProductsCount(), Is.EqualTo(1), "Product list size should be: 1 but was: " + cartPage.GetProductsCount());
            cartPage.DeleteProduct();
            Assert.That(cartPage.GetProductsCount(), Is.EqualTo(0), "Product list size should be: 0 but was: " + cartPage.GetProductsCount());
        }

        [Test]
        public void test0005_checkBillingAddress()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();

            createUserToLogin(registerUser);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(registerUser.email, registerUser.password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + registerUser.firstName + " " + registerUser.lastName), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckout();
            CheckoutCustomerAddress checkout = new CheckoutCustomerAddress(checkoutPage.GetDeliveryAddressDetails());
            CheckoutCustomerAddress invoice = new CheckoutCustomerAddress(checkoutPage.GetInvoiceAddressDetails());
            Assert.Multiple(() =>
            {
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(checkout.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(checkout.company));
                Assert.That(registerUser.address, Is.EqualTo(checkout.address));
                Assert.That(registerUser.address2, Is.EqualTo(checkout.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(checkout.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(checkout.country));
                Assert.That(registerUser.mobile, Is.EqualTo(checkout.mobile));
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(invoice.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(invoice.company));
                Assert.That(registerUser.address, Is.EqualTo(invoice.address));
                Assert.That(registerUser.address2, Is.EqualTo(invoice.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(invoice.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(invoice.country));
                Assert.That(registerUser.mobile, Is.EqualTo(invoice.mobile));

            });
            homePage.ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible(), Is.True);
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }

        [Test]
        public void test0006_invoiceShouldBeDownloaded()
        {
            RegisterUser registerUser = registerUserFactory.getRandomUser();
            CreditCardDetails creditCardDetails = creditCardDetailsFactory.getRandomCreditCardDetails();

            clearDownloadsFolder();
            createUserToLogin(registerUser);
            homePage.ClickMenuOption("Signup / Login");
            Assert.That(loginSignupPage.IsSignupHeaderVisible(), Is.True, "Login/Signup header should be visible, but was not.");
            loginSignupPage
                    .FillLogin(registerUser.email, registerUser.password)
                    .ClickLogin();
            Assert.That(homePage.IsMenuOptionVisible("Logged in as " + registerUser.firstName + " " + registerUser.lastName), Is.True, "Logged in as " + registerUser.username + " should be visible, but was not");
            productsPage
                    .AddProductToCart(1)
                    .ClickContinueShopping()
                    .AddProductToCart(2)
                    .ClickContinueShopping();
            homePage.ClickMenuOption("Cart");
            cartPage
                    .ProceedToCheckout()
                    .TypeDescription(Faker.Lorem.Sentence());
            CheckoutCustomerAddress checkout = new CheckoutCustomerAddress(checkoutPage.GetDeliveryAddressDetails());
            Assert.Multiple(() =>
            {
                Assert.That(registerUser.gender + ". " + registerUser.firstName + " " + registerUser.lastName, Is.EqualTo(checkout.genderFirstLastName));
                Assert.That(registerUser.company, Is.EqualTo(checkout.company));
                Assert.That(registerUser.address, Is.EqualTo(checkout.address));
                Assert.That(registerUser.address2, Is.EqualTo(checkout.address2));
                Assert.That(registerUser.city + " " + registerUser.state + " " + registerUser.zipcode, Is.EqualTo(checkout.cityStatePostalCode));
                Assert.That(registerUser.country, Is.EqualTo(checkout.country));
                Assert.That(registerUser.mobile, Is.EqualTo(checkout.mobile));
            });
            Assert.That(checkoutPage
                            .ClickPlaceOrder()
                            .FillCardDetail(creditCardDetails)
                            .ClickPlaceAndConfirmButton()
                            .DownloadInvoice()
                            .GetSuccessMessageText(), Is.EqualTo("Congratulations! Your order has been confirmed!"), "Success message should be 'Congratulations! Your order has been confirmed!!'");
            string invoiceContent = FileHandler.ReadFile("invoice.txt");
            Assert.That(invoiceContent.Contains(registerUser.firstName), Is.True);
            Assert.That(invoiceContent.Contains(registerUser.lastName), Is.True);
            paymentDonePage.ClickContinueButton().ClickMenuOption("Delete Account");
            Assert.That(accountDeletedPage.IsAccountDeletedHeaderVisible());
            Assert.That(accountDeletedPage.GetAccountDeletedHeaderText(), Is.EqualTo("ACCOUNT DELETED!"), "Account deleted message should has: ACCOUNT DELETED!' but was: " + accountDeletedPage.GetAccountDeletedHeaderText());
            accountDeletedPage.ClickContinueButton();
        }
    }
}
