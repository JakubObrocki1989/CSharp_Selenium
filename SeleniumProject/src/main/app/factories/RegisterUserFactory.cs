using System;
using System.Collections.Generic;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.app.factories
{
    class RegisterUserFactory
    {
        public RegisterUser getRandomUser()
        {
            List<string> genders = new List<string> { "Mr", "Mrs"};
            List<string> months = new List<string> { "January", "February", "March", "April", "May", "June", "July", "September", "October", "November", "December" };
            List<string> countries = new List<string> { "India", "United States", "Canada", "Australia", "Israel", "New Zealand", "Singapore"};
            Random rand = new Random();
            RegisterUser registerUser = new RegisterUserBuilder()
                    .SetUsername(Faker.Internet.UserName())
                    .SetEmail(Faker.Internet.Email())
                    .SetGender(genders[rand.Next(genders.Count)])
                    .SetPassword(Faker.Internet.UserName())
                    .SetDay(Faker.RandomNumber.Next(1, 31).ToString())
                    .SetMonth(months[rand.Next(months.Count)])
                    .SetYear(Faker.RandomNumber.Next(1900, 2024).ToString())
                    .SetSignUpForNewsletter(true)
                    .SetReceiveSpecialOffers(true)
                    .SetFirstName(Faker.Name.First())
                    .SetLastName(Faker.Name.Last())
                    .SetCompany(Faker.Company.Name())
                    .SetAddress(Faker.Address.StreetAddress())
                    .SetAddress2(Faker.Address.StreetName())
                    .SetCountry(countries[rand.Next(countries.Count)])
                    .SetState(Faker.Address.UsState())
                    .SetCity(Faker.Address.City())
                    .SetZipcode(Faker.Address.ZipCode())
                    .SetMobile(Faker.Phone.Number())
                    .Build();
            return registerUser;
        }
    }
}
