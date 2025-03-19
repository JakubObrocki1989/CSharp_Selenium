using System;

namespace SeleniumProject.src.main.app.models
{
    public class RegisterUser
    {
        public string username;
        public string email;
        public string gender;
        public string password;
        public string day;
        public string month;
        public string year;
        public bool signUpForNewsletter;
        public bool receiveSpecialOffers;
        public string firstName;
        public string lastName;
        public string company;
        public string address;
        public string address2;
        public string country;
        public string state;
        public string city;
        public string zipcode;
        public string mobile;
    }

    public class RegisterUserBuilder
    {
        private RegisterUser _RegisterUser = new RegisterUser();

        public RegisterUserBuilder SetUsername(string username)
        {
            _RegisterUser.username = username;
            return this;
        }

        public RegisterUserBuilder SetEmail(string email)
        {
            _RegisterUser.email = email;
            return this;
        }

        public RegisterUserBuilder SetGender(string gender)
        {
            _RegisterUser.gender = gender;
            return this;
        }

        public RegisterUserBuilder SetPassword(string password)
        {
            _RegisterUser.password = password;
            return this;
        }

        public RegisterUserBuilder SetDay(string day)
        {
            _RegisterUser.day = day;
            return this;
        }

        public RegisterUserBuilder SetMonth(string month)
        {
            _RegisterUser.month = month;
            return this;
        }

        public RegisterUserBuilder SetYear(string year)
        {
            _RegisterUser.year = year;
            return this;
        }

        public RegisterUserBuilder SetSignUpForNewsletter(bool signUpForNewsletter)
        {
            _RegisterUser.signUpForNewsletter = signUpForNewsletter;
            return this;
        }

        public RegisterUserBuilder SetReceiveSpecialOffers(bool receiveSpecialOffers)
        {
            _RegisterUser.receiveSpecialOffers = receiveSpecialOffers;
            return this;
        }

        public RegisterUserBuilder SetFirstName(string firstName)
        {
            _RegisterUser.firstName = firstName;
            return this;
        }

        public RegisterUserBuilder SetLastName(string lastName)
        {
            _RegisterUser.lastName = lastName;
            return this;
        }

        public RegisterUserBuilder SetCompany(string company)
        {
            _RegisterUser.company = company;
            return this;
        }

        public RegisterUserBuilder SetAddress(string address)
        {
            _RegisterUser.address = address;
            return this;
        }

        public RegisterUserBuilder SetAddress2(string address2)
        {
            _RegisterUser.address2 = address2;
            return this;
        }

        public RegisterUserBuilder SetCountry(string country)
        {
            _RegisterUser.country = country;
            return this;
        }

        public RegisterUserBuilder SetState(string state)
        {
            _RegisterUser.state = state;
            return this;
        }

        public RegisterUserBuilder SetCity(string city)
        {
            _RegisterUser.city = city;
            return this;
        }

        public RegisterUserBuilder SetZipcode(string zipcode)
        {
            _RegisterUser.zipcode = zipcode;
            return this;
        }

        public RegisterUserBuilder SetMobile(string mobile)
        {
            _RegisterUser.mobile = mobile;
            return this;
        }

        public RegisterUser Build()
        {
            return _RegisterUser;
        }

    }
}
