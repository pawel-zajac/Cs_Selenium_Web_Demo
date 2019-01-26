using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class PlaceOrderLoginCategoryQuickAddCheque : BaseClass
    {

        private HomePage homePage;
        private AuthenticationPage authenticationPage;
        private MyAccountPage myAccountPage;
        private ProductListPage productListPage;
        private CheckoutPage checkoutPage;

        [Test]
        public void PlaceOrderLoginCategoryQuickAddCheque1()
        {
            homePage = new HomePage(driver);
            authenticationPage = homePage.ClickSignInButton();
            myAccountPage = authenticationPage
                .EnterEmailSignIn(UserData.currentAccountEmail)
                .EnterPasswordSignIn(UserData.currentAccountPassword)
                .ClickSignInButton();

            productListPage = myAccountPage.ClickRandomCategoryButton();
            checkoutPage = productListPage
                .AddRandomProductToCart()
                .HandlePopupGoToCheckout();

            checkoutPage
                .ProceedToPayment()
                .ClickPayByChequeButton()
                .ClickConfirmOrderButton();

            Assert.IsTrue(checkoutPage.IsOrderComplete());

            checkoutPage.PrintOrderConfirmation();

        }
    }
}



