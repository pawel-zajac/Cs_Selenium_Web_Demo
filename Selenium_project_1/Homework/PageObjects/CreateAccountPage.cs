using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium_project_1.Homework.PageObjects
{
    class CreateAccountPage
    {
        private IWebDriver driver;

        //PERSONAL INFORMATION SECTION
        private IWebElement GenderMaleRadiobutton => new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.Id("uniform-id_gender1")));
        private IWebElement GenderFemaleRadiobutton => new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.Id("uniform-id_gender2")));
        private IWebElement FirstNameTextfield => driver.FindElement(By.Id("customer_firstname"));
        private IWebElement LastNameTextfield => driver.FindElement(By.Id("customer_lastname"));
        private IWebElement EmailTextfield => new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(drv => drv.FindElement(By.CssSelector("input[id='email']:not([value=''])")));
        private IWebElement PasswordTextfield => driver.FindElement(By.Id("passwd"));
        private SelectElement DayBirthDropdown => new SelectElement(driver.FindElement(By.Id("days")));
        private SelectElement MonthBirthDropdown => new SelectElement(driver.FindElement(By.Id("months")));
        private SelectElement YearBirthDropdown => new SelectElement(driver.FindElement(By.Id("years")));
        private IWebElement NewsletterCheckbox => driver.FindElement(By.Id("uniform-newsletter"));
        private IWebElement OffersCheckbox => driver.FindElement(By.Id("uniform-optin"));

        //ADDRESS SECTION
        private IWebElement FirstNameAddressTextfield => driver.FindElement(By.Id("firstname"));
        private IWebElement LastNameAddressTextfield => driver.FindElement(By.Id("lastname"));
        private IWebElement CompanyAddressTextfield => driver.FindElement(By.Id("company"));
        private IWebElement AddressLine1AddressTextfield => driver.FindElement(By.Id("address1"));
        private IWebElement AddressLine2AddressTextfield => driver.FindElement(By.Id("address2"));
        private IWebElement CityAddressTextfield => driver.FindElement(By.Id("city"));
        private SelectElement StateAddressDropdown => new SelectElement(driver.FindElement(By.Id("id_state")));
        private IWebElement ZipcodeAddressTextfield => driver.FindElement(By.Id("postcode"));
        private SelectElement CountryAddressDropdown => new SelectElement(driver.FindElement(By.Id("id_country")));
        private IWebElement OtherInfoAddressTextfield => driver.FindElement(By.Id("other"));
        private IWebElement HomePhoneAddressTextfield => driver.FindElement(By.Id("phone"));
        private IWebElement MobilePhoneAddressTextfield => driver.FindElement(By.Id("phone_mobile"));
        private IWebElement AliasAddressTextfield => driver.FindElement(By.Id("alias"));

        private IWebElement RegisterButton => driver.FindElement(By.Id("submitAccount"));

        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CreateAccountPage WaitForLoading()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            return this;
        }

        //PERSONAL INFORMATION SECTION
        public CreateAccountPage ClickMaleRadiobutton ()
        {
            GenderMaleRadiobutton.Click();
            return this;
        }

        public CreateAccountPage ClickFemaleRadiobutton()
        {
            GenderFemaleRadiobutton.Click();
            return this;
        }

        public CreateAccountPage EnterFirstName(string firstName)
        {
            FirstNameTextfield.SendKeys(firstName);
            return this;
        }

        public CreateAccountPage EnterLastName(string lastName)
        {
            LastNameTextfield.SendKeys(lastName);
            return this;
        }

        public CreateAccountPage EnterEmail(string email)
        {
            EmailTextfield.SendKeys(email);
            return this;
        }

        public string GetEmailValue()
        {
            return EmailTextfield.GetAttribute("value");
        }

        public CreateAccountPage EnterPassword(string password)
        {
            PasswordTextfield.SendKeys(password);
            return this;
        }

        public CreateAccountPage SelectDayOfBirth(string day)
        {
            DayBirthDropdown.SelectByText(day);
            return this;
        }

        public CreateAccountPage SelectDayOfBirth(int index)
        {
            DayBirthDropdown.SelectByIndex(index);
            return this;
        }

        public CreateAccountPage SelectMonthOfBirth(string month)
        {
            MonthBirthDropdown.SelectByText(month);
            return this;
        }

        public CreateAccountPage SelectMonthOfBirth(int index)
        {
            MonthBirthDropdown.SelectByIndex(index);
            return this;
        }

        public CreateAccountPage SelectYearOfBirth(string year)
        {
            YearBirthDropdown.SelectByText(year);
            return this;
        }

        public CreateAccountPage SelectYearOfBirth(int index)
        {
            YearBirthDropdown.SelectByIndex(index);
            return this;
        }

        public CreateAccountPage ClickNewsletterCheckbox()
        {
            NewsletterCheckbox.Click();
            return this;
        }

        public CreateAccountPage ClickOffersCheckbox()
        {
            OffersCheckbox.Click();
            return this;
        }

        //ADDRESS SECTION
        public CreateAccountPage EnterFirstNameAddress(string firstName)
        {
            FirstNameAddressTextfield.Clear();
            FirstNameAddressTextfield.SendKeys(firstName);
            return this;
        }

        public CreateAccountPage EnterLastNameAddress(string lastName)
        {
            LastNameAddressTextfield.Clear();
            LastNameAddressTextfield.SendKeys(lastName);
            return this;
        }

        public CreateAccountPage EnterCompanyAddress(string company)
        {
            CompanyAddressTextfield.SendKeys(company);
            return this;
        }

        public CreateAccountPage EnterAddressLine1Address(string address1)
        {
            AddressLine1AddressTextfield.SendKeys(address1);
            return this;
        }

        public CreateAccountPage EnterAddressLine2Address(string address2)
        {
            AddressLine2AddressTextfield.SendKeys(address2);
            return this;
        }

        public CreateAccountPage EnterCityAddress(string city)
        {
            CityAddressTextfield.SendKeys(city);
            return this;
        }

        public CreateAccountPage SelectStateAddress(string state)
        {
            StateAddressDropdown.SelectByText(state);
            return this;
        }

        public CreateAccountPage SelectStateAddress(int index)
        {
            StateAddressDropdown.SelectByIndex(index);
            return this;
        }

        public CreateAccountPage EnterZipcodeAddress(string zipcode)
        {
            ZipcodeAddressTextfield.SendKeys(zipcode);
            return this;
        }

        public CreateAccountPage SelectCountryAddress(string country)
        {
            CountryAddressDropdown.SelectByText(country);
            return this;
        }

        public CreateAccountPage SelectCountryAddress(int index)
        {
            CountryAddressDropdown.SelectByIndex(index);
            return this;
        }

        public CreateAccountPage EnterAdditionalInfoAddress(string additionalInfo)
        {
            OtherInfoAddressTextfield.SendKeys(additionalInfo);
            return this;
        }

        public CreateAccountPage EnterHomePhoneAddress(string homePhone)
        {
            HomePhoneAddressTextfield.SendKeys(homePhone);
            return this;
        }

        public CreateAccountPage EnterMobilePhoneAddress(string mobilePhone)
        {
            MobilePhoneAddressTextfield.SendKeys(mobilePhone);
            return this;
        }

        public CreateAccountPage EnterAliasAddress(string alias)
        {
            AliasAddressTextfield.Clear();
            AliasAddressTextfield.SendKeys(alias);
            return this;
        }


        public MyAccountPage ClickRegisterButton()
        {
            RegisterButton.Click();
            return new MyAccountPage(driver);
        }

        public CreateAccountPage OverwriteCredentials(bool overwrite)
        {
            if (overwrite)
            {
                UserData.currentAccountEmail = UserData.randomEmailAddress;
                UserData.currentAccountPassword = UserData.randomPassword;
            }
            return this;
        }


    }
}
