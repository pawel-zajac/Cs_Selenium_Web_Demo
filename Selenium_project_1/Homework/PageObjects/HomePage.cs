using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Selenium_project_1.Homework.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        private IWebElement SignInButton => driver.FindElement(By.CssSelector("a[class='login']"));
        private IWebElement SearchTextfield => driver.FindElement(By.Id("search_query_top"));
        private IWebElement SubmitSearchButton => driver.FindElement(By.CssSelector("button[name='submit_search']"));
        private IList<IWebElement> CategoryButtons => driver.FindElements(By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a"));
        private IWebElement ContactUsLink => driver.FindElement(By.CssSelector("a[href='http://automationpractice.com/index.php?controller=contact']"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public AuthenticationPage ClickSignInButton()
        {
            SignInButton.Click();
            return new AuthenticationPage(driver);
        }

        public HomePage EnterSearchQuery(string searchQuery)
        {
            SearchTextfield.SendKeys(searchQuery);
            return this;
        }

        public ProductListPage ClickSearchButton()
        {
            SubmitSearchButton.Click();
            return new ProductListPage(driver);
        }

        public ProductListPage ClickRandomCategoryButton()
        {
            Random random = new Random();
            int indexToClick = random.Next(CategoryButtons.Count);
            CategoryButtons[indexToClick].Click();
            return new ProductListPage(driver);
        }

        public ContactUsPage ClickContactUsLink()
        {
            ContactUsLink.Click();
            return new ContactUsPage(driver);
        }
    }
}
