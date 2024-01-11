using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumSpecflowFrameworkfinal.SetUp
{
    public class Browser
    {
        public static IWebDriver driver { get; set; }
        public static void GetDrivers()
        {
            var type = "ChromeDriver";
            switch (type)
            {
                case "ChromeDriver":
                    //new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions options = new ChromeOptions();

                    // Add the headless option
                    options.AddArgument("headless");
                    driver = new ChromeDriver(options);
                    driver.Manage().Window.Maximize();  
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    break;
                case "Firefox":
                    var config = new FirefoxConfig();
                    var version = config.GetLatestVersion().StartsWith(".") ? "0" + config.GetLatestVersion() : config.GetLatestVersion();
                    new DriverManager().SetUpDriver(new FirefoxConfig(), version);
                    driver = new FirefoxDriver();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
           // return driver;

        }
        //public static void GetDriver(TestParameters parameters)
        //{
        //    string browserType = parameters.Get("Testing.Default.Driver");
        //     GetDrivers(browserType);
        //}
        //public static string GetUrl(TestParameters parameters)
        //{
        //    string url = parameters.Get("EnvUrl");
        //    return url;
        //}

    }
}
