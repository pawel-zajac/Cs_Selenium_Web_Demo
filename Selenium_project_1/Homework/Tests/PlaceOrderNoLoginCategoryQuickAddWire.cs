using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class PlaceOrderNoLoginCategoryQuickAddWire : BaseClass
    {

        private HomePage homePage;
        private ProductListPage productListPage;
        private CheckoutPage checkoutPage;

        [Test]
        public void PlaceOrderNoLoginCategoryQuickAddWire1()
        {
            homePage = new HomePage(driver);

            productListPage = homePage.ClickRandomCategoryButton();
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