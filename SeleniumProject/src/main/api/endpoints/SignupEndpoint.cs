using NUnit.Framework;
using RestSharp;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.api.endpoints
{
    class SignupEndpoint
    {
        RestClient client = new RestClient("https://automationexercise.com/api/");
        RestRequest request = new RestRequest("createAccount");

        public void postSignUp()
        {
            request
                .AddParameter("name", "test")
                    .AddParameter("email", "automation-ui@sampledomain.com")
                    .AddParameter("password", "pass1723788968")
                    .AddParameter("title", "Mr")
                    .AddParameter("birth_date", "1")
                    .AddParameter("birth_month", "1")
                    .AddParameter("birth_year", "2000")
                    .AddParameter("firstname", "test")
                    .AddParameter("lastname", "last")
                    .AddParameter("company", "ocmp")
                    .AddParameter("address1", "1134 Columbia Road")
                    .AddParameter("address2", "most")
                    .AddParameter("country", "United States")
                    .AddParameter("zipcode", "23452")
                    .AddParameter("state", "texas")
                    .AddParameter("city", "dalas")
                    .AddParameter("mobile_number", "123123123");

            var response = client.Post(request);
            Assert.That(response.StatusDescription, Is.EqualTo("OK"));

        }

        public void postSignUp(RegisterUser registerUser)
        {
            request
                .AddParameter("name", registerUser.firstName + " " + registerUser.lastName)
                .AddParameter("email", registerUser.email)
                .AddParameter("password", registerUser.password)
                .AddParameter("title", registerUser.gender)
                .AddParameter("birth_date", registerUser.day)
                .AddParameter("birth_month", registerUser.month)
                .AddParameter("birth_year", registerUser.year)
                .AddParameter("firstname", registerUser.firstName)
                .AddParameter("lastname", registerUser.lastName)
                .AddParameter("company", registerUser.company)
                .AddParameter("address1", registerUser.address)
                .AddParameter("address2", registerUser.address2)
                .AddParameter("country", registerUser.country)
                .AddParameter("zipcode", registerUser.zipcode)
                .AddParameter("state", registerUser.state)
                .AddParameter("city", registerUser.city)
                .AddParameter("mobile_number", registerUser.mobile);

            var response = client.Post(request);
            Assert.That(response.StatusDescription, Is.EqualTo("OK"));

        }
    }
}
