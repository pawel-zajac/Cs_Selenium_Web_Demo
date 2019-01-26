using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class PlaceOrderNoLoginSearchQuickAddCheque : BaseClass
    {

        private HomePage homePage;
        private ProductListPage productListPage;
        private CheckoutPage checkoutPage;

        private static readonly string searchQuery = "dress";

        [Test]
        public void PlaceOrderNoLoginSearchQuickAddCheque1()
        {
            homePage = new HomePage(driver);

            productListPage = homePage
                .EnterSearchQuery(searchQuery)
                .ClickSearchButton();

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





