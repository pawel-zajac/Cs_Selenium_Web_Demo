using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class PlaceOrderLoginSearchQuickAddWire : BaseClass
    {

        private HomePage homePage;
        private AuthenticationPage authenticationPage;
        private MyAccountPage myAccountPage;
        private ProductListPage productListPage;
        private CheckoutPage checkoutPage;

        private static readonly string searchQuery = "dress";

        [Test]
        public void PlaceOrderLoginSearchQuickAddWire1()
        {
            homePage = new HomePage(driver);
            authenticationPage = homePage.ClickSignInButton();
            myAccountPage = authenticationPage
                .EnterEmailSignIn(UserData.currentAccountEmail)
                .EnterPasswordSignIn(UserData.currentAccountPassword)
                .ClickSignInButton();

            productListPage = myAccountPage
                .EnterSearchQuery(searchQuery)
                .ClickSearchButton();

            checkoutPage = productListPage
                .AddRandomProductToCart()
                .HandlePopupGoToCheckout();

            checkoutPage
                .ProceedToPayment()
                .ClickPayByBankWireButton();
                checkoutPage.ClickConfirmOrderButton();

            Assert.IsTrue(checkoutPage.IsOrderComplete());

            checkoutPage.PrintOrderConfirmation();

        }
    }
}
