using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class LogIn : BaseClass
    {

        private HomePage homePage;
        private AuthenticationPage authenticationPage;
        private MyAccountPage myAccountPage;

        private static readonly string expectedHeader = "MY ACCOUNT";

        [Test]
        public void LogIn1()
        {
            homePage = new HomePage(driver);
            authenticationPage = homePage.ClickSignInButton();
            myAccountPage = authenticationPage
                .EnterEmailSignIn(UserData.currentAccountEmail)
                .EnterPasswordSignIn(UserData.currentAccountPassword)
                .ClickSignInButton();

            Assert.AreEqual(expectedHeader, myAccountPage.GetpageHeader());
        }
    }
}
