using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Selenium_project_1.Homework.PageObjects
{
    class MyAccountPage
    {
        private IWebDriver driver;

        private IWebElement PageHeader => driver.FindElement(By.CssSelector("h1[class='page-heading']"));
        private IWebElement AccountNameButton => driver.FindElement(By.CssSelector("a[class='account'] span:first-child"));
        private IWebElement SearchTextfield => driver.FindElement(By.Id("search_query_top"));
        private IWebElement SubmitSearchButton => driver.FindElement(By.CssSelector("button[name='submit_search']"));
        private IList<IWebElement> CategoryButtons => driver.FindElements(By.XPath("//ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li/a"));


        public MyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetpageHeader()
        {
            return PageHeader.Text;
        }

        public string GetAccountName()
        {
            return AccountNameButton.Text;
        }

        public MyAccountPage EnterSearchQuery(string searchQuery)
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
    }


}
