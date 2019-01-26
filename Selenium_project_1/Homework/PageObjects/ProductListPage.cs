using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Selenium_project_1.Homework.PageObjects
{
    class ProductListPage
    {
        private IWebDriver driver;

        private IList<IWebElement> ProductContainers => driver.FindElements(By.CssSelector("div[class='product-container']"));
        private IList<IWebElement> AddToCartButtons => driver.FindElements(By.XPath("//div[@class='product-container']//a[@class='button ajax_add_to_cart_button btn btn-default']"));
        
        //On Add Pop-up
        private IWebElement CheckoutPopupButton => driver.FindElement(By.CssSelector("a[class='btn btn-default button button-medium']"));
        
        public ProductListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ProductListPage AddRandomProductToCart()
        {
            Random random = new Random();
            int indexToClick = random.Next(ProductContainers.Count);
            Actions action = new Actions(driver);
            action.MoveToElement(ProductContainers[indexToClick]).MoveToElement(AddToCartButtons[indexToClick]).Click().Perform();
            return this;
        }

        public CheckoutPage HandlePopupGoToCheckout()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(drv => CheckoutPopupButton.Displayed);
            CheckoutPopupButton.Click();
            return new CheckoutPage(driver);
        }

    }


}