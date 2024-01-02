using Microsoft.AspNetCore.DiagnosticsViewPage.Views;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumSpecflowFrameworkfinal.SetUp;
using SeleniumSpecflowFrameworkfinal.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowFrameworkfinal.Pages
{
 
    public  class IframePage
    {
        [FindsBy(How = How.Id, Using = "firstFr")]
        private IWebElement Iframe;

        [FindsBy(How = How.Name, Using = "fname")]
        private IWebElement firstName;

        [FindsBy(How = How.Name, Using = "lname")]
        private IWebElement lastName;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement email;



       
        public IframePage() 
        {  

        } 
        public void CompleteUserForm(string fname, string lname, string emailaddress)
        {
            TestHelpers.SwitchToFrame(Iframe);
            firstName.SendKeys(fname);
            lastName.SendKeys(lname);
            Browser.driver.SwitchTo().Frame(1);
            email.SendKeys(emailaddress);  

        }

    }
}
