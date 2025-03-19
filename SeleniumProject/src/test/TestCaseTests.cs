using NUnit.Framework;

namespace SeleniumProject.src.test
{
    [TestFixture]
    class TestCaseTests : BaseTest
    {
        [Test]
    public void test0001_testCasePageShouldBeOpened()
        {
            homePage.ClickMenuOption("Test Cases");
            Assert.That(testCasesPage.IsTestCasesHeaderVisible(), Is.True, "Test cases header should be visible, but was not.");
            Assert.That(testCasesPage.GetTestCasesHeaderText(), Is.EqualTo("TEST CASES"), "Test cases header should be 'TEST CASES' but was: " + testCasesPage.GetTestCasesHeaderText());
        }
    }
}
