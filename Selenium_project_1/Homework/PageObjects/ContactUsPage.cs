using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_project_1.Homework.PageObjects
{
    class ContactUsPage
    {
        private IWebDriver driver;

        
        private SelectElement SubjectHeadingDropdown => new SelectElement(driver.FindElement(By.Id("id_contact")));
        private IWebElement EmailTextfield => driver.FindElement(By.Id("email"));
        private IWebElement OrderReferenceTextfield => driver.FindElement(By.Id("id_order"));
        private IWebElement ChooseFileField => driver.FindElement(By.CssSelector("input[type=file]"));
        private IWebElement MessageTextfield => driver.FindElement(By.Id("message"));
        private IWebElement SendButton => driver.FindElement(By.Id("submitMessage"));
        private IWebElement SuccessMessage => driver.FindElement(By.CssSelector("p[class='alert alert-success']")); 

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public ContactUsPage SelectSubjectHeading(int index)
        {
            SubjectHeadingDropdown.SelectByIndex(index);
            return this;
        }

        public ContactUsPage SelectSubjectHeading(string heading)
        {
            SubjectHeadingDropdown.SelectByText(heading);
            return this;
        }

        public ContactUsPage EnterEmail(string email)
        {
            EmailTextfield.Clear();
            EmailTextfield.SendKeys(email);
            return this;
        }

        public ContactUsPage EnterOrderReference(string reference)
        {
            OrderReferenceTextfield.SendKeys(reference);
            return this;
        }

        public ContactUsPage AttachFile(string filePath)
        {
            ChooseFileField.SendKeys(filePath);
            return this;
        }

        public ContactUsPage EnterMessage(string message)
        {
            MessageTextfield.SendKeys(message);
            return this;
        }

        public ContactUsPage ClickSendButton()
        {
            SendButton.Click();
            return this;
        }

        public bool IsMessageSent()
        {
            if (SuccessMessage.Text.Equals("Your message has been successfully sent to our team."))
            {
                return true;
            }
            return false;
        }

    }


}

