using NUnit.Framework;
using Selenium_project_1.Homework.PageObjects;
using Selenium_project_1.PageObjectPattern;
using System;
using System.IO;

namespace Selenium_project_1.Homework.Tests
{
    [TestFixture]
    class SendContactForm : BaseClass
    {

        private HomePage homePage;
        private ContactUsPage contactUsPage;

        private static readonly string FileRelativePath = @"Homework\Files\SampleFile.txt";

        [Test]
        public void SendContactForm1()
        {
            homePage = new HomePage(driver);
            contactUsPage = homePage.ClickContactUsLink();

            contactUsPage
                .SelectSubjectHeading(1)
                .EnterEmail(UserData.currentAccountEmail)
                .EnterOrderReference("abc")
                .AttachFile(Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, FileRelativePath))
                .EnterMessage(StringGenerator.GenerateAlphanumericString(255, true))
                .ClickSendButton();

            Assert.IsTrue(contactUsPage.IsMessageSent());
        }
    }
}
