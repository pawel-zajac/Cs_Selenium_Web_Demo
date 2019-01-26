using OpenQA.Selenium;
using System;

namespace Selenium_project_1.Homework.PageObjects
{
    class AuthenticationPage
    {
        private IWebDriver driver;

        private IWebElement CreateAccountEmailTextfield => driver.FindElement(By.Id("email_create"));
        private IWebElement CreateAccountButton => driver.FindElement(By.Id("SubmitCreate"));
        private IWebElement SignInEmailTextfield => driver.FindElement(By.Id("email"));
        private IWebElement SignInPasswordTextfield => driver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => driver.FindElement(By.Id("SubmitLogin"));

        public AuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public AuthenticationPage EnterEmailCreateAccount(string email)
        {
            CreateAccountEmailTextfield.SendKeys(email);
            return this;
        }

        public CreateAccountPage ClickCreateAccountButton()
        {
            CreateAccountButton.Click();
            return new CreateAccountPage(driver);
        }

        public AuthenticationPage EnterEmailSignIn(string email)
        {
            SignInEmailTextfield.SendKeys(email);
            Console.WriteLine("Entered email: " + email);
            return this;
        }

        public AuthenticationPage EnterPasswordSignIn(string password)
        {
            SignInPasswordTextfield.SendKeys(password);
            Console.WriteLine("Entered password: " + password);
            return this;
        }

        public MyAccountPage ClickSignInButton()
        {
            SignInButton.Click();
            return new MyAccountPage(driver);
        }


    }
}
