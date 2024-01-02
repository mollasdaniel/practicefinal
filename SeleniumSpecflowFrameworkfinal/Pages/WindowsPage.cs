using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumSpecflowFrameworkfinal.SetUp;
using SeleniumSpecflowFrameworkfinal.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowFrameworkfinal.Pages
{
    public  class WindowsPage
    {
        [FindsBy(How = How.CssSelector, Using = "#home")]
        private IWebElement homePageBtn;

        [FindsBy(How = How.CssSelector, Using = "#multi")]
        private IWebElement MultiBtn;

        public WindowsPage()
        { 

        }   
        public void clickOnHomePageBtn()
        {
            TestHelpers.ClickOnElement(homePageBtn);
            WebDriverWait wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(10));
            wait.Until(wd => wd.WindowHandles.Count == 2);
        }
        
    }
}
