using SeleniumProject.src.main.api.endpoints;
using SeleniumProject.src.main.app.models;

namespace SeleniumProject.src.main.api.factories
{
    class DataFactory
    {
        static SignupEndpoint signupEndpoint = new SignupEndpoint();

        public static void createAutomationTestsUser()
        {
            signupEndpoint.postSignUp();
        }

        public static void createAutomationTestsUser(RegisterUser registerUser)
        {
            signupEndpoint.postSignUp(registerUser);
        }
    }
}
