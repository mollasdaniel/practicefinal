using OpenQA.Selenium;
using SeleniumSpecflowFrameworkfinal.SetUp;
using SeleniumSpecflowFrameworkfinal.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumSpecflowFrameworkfinal.Pages
{
    public class HomePage
    {

        public HomePage()
        {

        }

        private IWebElement discoverMenu = Browser.driver.FindElement(By.XPath("//a[@class='c-main-nav__link ng-binding'][normalize-space()='Discover']"));
        private IWebElement albumSubmenu = Browser.driver.FindElement(By.XPath("//a[normalize-space()='Albums']"));

        public void NavigateToAlbumsPage()
        {
            TestHelpers.MoveToElement(discoverMenu);
            albumSubmenu.Click();


        }
    }
}
