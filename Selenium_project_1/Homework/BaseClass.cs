using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_project_1.PageObjectPattern
{
    class BaseClass
    {

        protected IWebDriver driver;

        [SetUp]
        public void Start()
        {
            this.driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
        }

    }


}
