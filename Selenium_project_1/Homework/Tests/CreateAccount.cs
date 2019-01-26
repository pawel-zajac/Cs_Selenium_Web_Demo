using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class CreateAccount : BaseClass
    {

        private HomePage homePage;
        private AuthenticationPage authenticationPage;
        private CreateAccountPage createAccountPage;
        private MyAccountPage myAccountPage;

        private static readonly string expectedHeader = "MY ACCOUNT";
        private static readonly string expectedAccountName = UserData.fistName + " " + UserData.lastName;

        [Test]
        public void CreateAccount1()
        {
            homePage = new HomePage(driver);
            authenticationPage = homePage.ClickSignInButton();
            authenticationPage.EnterEmailCreateAccount(UserData.randomEmailAddress);
            createAccountPage = authenticationPage.ClickCreateAccountButton();

            Assert.AreEqual(UserData.randomEmailAddress, createAccountPage.GetEmailValue());

            myAccountPage = createAccountPage
                .ClickMaleRadiobutton()
                .EnterFirstName(UserData.fistName)
                .EnterLastName(UserData.lastName)
                .EnterPassword(UserData.randomPassword)
                .SelectDayOfBirth(4)
                .SelectMonthOfBirth(8)
                .SelectYearOfBirth(32)
                .ClickNewsletterCheckbox()
                .ClickOffersCheckbox()
                .EnterFirstNameAddress(UserData.fistName)
                .EnterLastNameAddress(UserData.lastName)
                .EnterCompanyAddress("Nice company")
                .EnterAddressLine1Address("Nice street")
                .EnterAddressLine2Address("21/37")
                .EnterCityAddress("Nice Town")
                .SelectStateAddress(4)
                .EnterZipcodeAddress("00000")
                .SelectCountryAddress(1)
                .EnterAdditionalInfoAddress("Nice place")
                .EnterHomePhoneAddress("555555555")
                .EnterMobilePhoneAddress("666666666")
                .EnterAliasAddress("Nice address")
                .ClickRegisterButton();

            Assert.AreEqual(expectedHeader, myAccountPage.GetpageHeader());
            Assert.AreEqual(expectedAccountName, myAccountPage.GetAccountName());

            //Optional: if account was created successfuly user can override existing account credentials
            createAccountPage.OverwriteCredentials(true);
        }
    }
}
