using NUnit.Framework;
using SeleniumSpecflowFrameworkfinal.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowFrameworkfinal.Support
{
    public static class TestHelpers
    {
        public static string GetWebUrl(TestParameters parameters)
        {
            string url = parameters.Get("EnvUrl");
            return url;
        }
        public static void GoToUrl(string url)
        {
            Browser.driver.Navigate().GoToUrl(url); 
        }
    }
}
