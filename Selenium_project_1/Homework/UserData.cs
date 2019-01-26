using System;

namespace Selenium_project_1.Homework
{
    static class UserData
    {
        public static string fistName = "Pawel";
        public static string lastName = "Zajac";
        public static string currentAccountEmail = "asdf12a56fsd435234fffffdsdf@sdfsd.sd";
        public static string currentAccountPassword = "qwerty";

        public static string randomEmailAddress = StringGenerator.GenerateEmailAddress();
        public static string randomPassword = StringGenerator.GenerateAlphanumericString(new Random().Next(5, 32), false);
        
    }
}
