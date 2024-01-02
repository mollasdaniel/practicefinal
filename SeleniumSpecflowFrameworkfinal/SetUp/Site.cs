//using PageFactoryCore;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SeleniumExtras.PageObjects;

namespace SeleniumSpecflowFrameworkfinal.SetUp
{
    public class Site
    {
        public static T Page<T>()
        {
            var page  = Activator.CreateInstance<T>();
            PageFactory.InitElements(Browser.driver, page);
            
           return page;
        }
    }
}
