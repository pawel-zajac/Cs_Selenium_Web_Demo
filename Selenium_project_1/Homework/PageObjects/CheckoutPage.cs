using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium_project_1.Homework.PageObjects
{
    class CheckoutPage
    {
        private IWebDriver driver;

        //GENERAL
        private IWebElement CheckoutButton => driver.FindElement(By.XPath("//p[@class='cart_navigation clearfix']//*[text()[contains(.,'Proceed to checkout')]]"));
        private IWebElement CurrentTab => driver.FindElement(By.CssSelector("li[class^='step_current'"));
       
        //SIGN IN TAB
        private IWebElement SignInEmailTextfield => driver.FindElement(By.Id("email"));
        private IWebElement SignInPasswordTextfield => driver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => driver.FindElement(By.Id("SubmitLogin"));

        //SHIPPING TAB
        private IWebElement TermsCheckbox => driver.FindElement(By.Id("cgv"));

        //PAYMENT TAB
        private IWebElement BankWireButton => driver.FindElement(By.CssSelector("a[class='bankwire']"));
        private IWebElement ChequeButton => driver.FindElement(By.CssSelector("a[class='cheque']"));
        private IWebElement OrderSubmitButton => driver.FindElement(By.CssSelector("button[class='button btn btn-default button-medium']"));
        private IWebElement ConfirmationMessage => driver.FindElement(By.XPath("//*[text()[starts-with(.,'Your order on My Store')]]")); 
        private IWebElement ConfirmationSummary => driver.FindElement(By.CssSelector("div[class^='box']"));

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CheckoutPage ProceedToPayment()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(drv => CurrentTab.Displayed);
            if(CurrentTab.Text.Contains("Summary"))
            {
                wait.Until(drv => CheckoutButton.Displayed && CheckoutButton.Enabled);
                CheckoutButton.Click();
            }
            
            wait.Until(drv => CurrentTab.Displayed);
            if (CurrentTab.Text.Contains("Sign in"))
            {
                SignInEmailTextfield.SendKeys(UserData.currentAccountEmail);
                SignInPasswordTextfield.SendKeys(UserData.currentAccountPassword);
                SignInButton.Click();
            }

            wait.Until(drv => CurrentTab.Displayed);
            if (CurrentTab.Text.Contains("Address"))
            {
                wait.Until(drv => CheckoutButton.Displayed && CheckoutButton.Enabled);
                CheckoutButton.Click();
            }

            wait.Until(drv => CurrentTab.Displayed);
            if (CurrentTab.Text.Contains("Shipping"))
            {
                if (!TermsCheckbox.Selected)
                {
                    TermsCheckbox.Click();
                }
                wait.Until(drv => CheckoutButton.Displayed && CheckoutButton.Enabled);
                CheckoutButton.Click();
            }
            return this;
        }

        public CheckoutPage ClickPayByBankWireButton()
        {
            BankWireButton.Click();
            return this;
        }

        public CheckoutPage ClickPayByChequeButton()
        {
            ChequeButton.Click();
            return this;
        }

        public CheckoutPage ClickConfirmOrderButton()
        {
            OrderSubmitButton.Click();
            return this;
        }

        public bool IsOrderComplete()
        {
            if (ConfirmationMessage.Text.Equals("Your order on My Store is complete."))
            {
                return true;
            }
            return false;
        }

        public CheckoutPage PrintOrderConfirmation()
        {
            Console.WriteLine("Order confirmation summary:");
            Console.WriteLine(ConfirmationSummary.Text);
            return this;
        }



    }


}