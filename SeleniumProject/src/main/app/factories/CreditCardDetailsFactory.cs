using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.app.factories
{
    class CreditCardDetailsFactory
    {
        public CreditCardDetails getRandomCreditCardDetails()
        {
            CreditCardDetails creditCardDetails = new CreditCardDetailsBuilder()
            .SetCardOwner(Faker.Name.FullName())
            .SetCardNumber(Faker.RandomNumber.Next().ToString())
            .SetCvcNumber(Faker.RandomNumber.Next(100, 999).ToString())
            .SetExpiryMonth(Faker.RandomNumber.Next(1, 12).ToString())
            .SetExpiryYear(Faker.RandomNumber.Next(2024, 2030).ToString())
            .Build();
            return creditCardDetails;
        }
    }
}
