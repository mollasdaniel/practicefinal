using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumSpecflowFrameworkfinal.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
      
        public static void NavigateToPage(string pageURL)
        {
            bool isUriValid = Uri.IsWellFormedUriString(pageURL, UriKind.RelativeOrAbsolute);
            if (isUriValid) Browser.driver.Navigate().GoToUrl(pageURL);
            else Console.WriteLine($"The URL the supplied not a valid URL");
        }

       
        public static IWebElement LocateElement(string elementXpath)
        {
            return Browser.driver.FindElement(By.XPath(elementXpath));
        }

        
        public static void ClickOnElement(IWebElement elementToCLickOn)
        {
            if (elementToCLickOn.Enabled) elementToCLickOn.Click();
            else Console.WriteLine("The web element you intend to click on is not enabled");
        }

        public static void ClickOnElementUsingJS(string xpathOfElementtoClickOn)
        {
            ((IJavaScriptExecutor)Browser.driver).ExecuteScript("Arguments[0].Click()", Browser.driver.FindElement(By.XPath(xpathOfElementtoClickOn)));
        }

       
        public static void ClickOnLinkText(string linkText)
        {
            IWebElement link = Browser.driver.FindElement(By.LinkText(linkText));
            ClickOnElement(link);
            WaitForPageToLoad();
        }

        
        //public static void ClickOnButton(string buttonText)
        //{
        //    ButtonText = buttonText;
        //    IWebElement genericButton = Browser.driver.FindElement(By.XPath(GenericButtonLabel));
        //    ClickOnElement(genericButton);
        //    WaitForPageToLoad();
        //}

        
        public static void SetCheckbox(bool shouldCheckboxBeChecked, string labelNameForCheckboxToInteractWith)
        {
            IWebElement checkboxLabel = Browser.driver.FindElement(By.XPath($"//label[contains(text(),'{labelNameForCheckboxToInteractWith}')]"));
            var checkboxId = checkboxLabel.GetAttribute("for");
            IWebElement checkbox = Browser.driver.FindElement(By.Id(checkboxId));

            // Found to be more reliable to click the label rather than the checkbox element -
            // this is acceptable as it is valid user behaviour.
            if (shouldCheckboxBeChecked == true && !checkbox.Selected)
            {
                ClickOnElement(checkboxLabel);
            }

            if (shouldCheckboxBeChecked == false && checkbox.Selected)
            {
                ClickOnElement(checkboxLabel);
            }
        }

        
        public static void SelectFromDropdown(IWebElement dropdownElement, string itemToSelect)
        {
            //Selenium.Select selecter = new Select()
            SelectElement selector = new SelectElement(dropdownElement);
            selector.SelectByText(itemToSelect);
        }

        
        public static void EnterText(IWebElement textField, string textValue)
        {
            textField.SendKeys(textValue);
        }

        
        public static void EnterInputText(string inputTextToEnter, string textFieldlabel)
        {
            IWebElement inputLabel = Browser.driver.FindElement(By.XPath($"//label[contains(text(),'{textFieldlabel}')]"));
            var inputId = inputLabel.GetAttribute("for");
            IWebElement inputField = Browser.driver.FindElement(By.Id(inputId));
            EnterText(inputField, inputTextToEnter);
        }

       
        public static void MoveToElement(IWebElement elementToMoveTo)
        {
            Actions action = new Actions(Browser.driver);
            action.MoveToElement(elementToMoveTo).Perform();
        }

        
        public static void MoveToElementAndClick(IWebElement elementToMoveToAndClick)
        {
            Actions action = new Actions(Browser.driver);
            action.MoveToElement(elementToMoveToAndClick).Click();
        }

        
        public static void WaitForPageToLoad(int timeout = 30)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Browser.driver, TimeSpan.FromSeconds(timeout));

            wait.Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }

        
        public static void CheckIfLinksAreActive()
        {
            HttpWebRequest request = null;

            IList<IWebElement> links = Browser.driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in links)
            {
                if (!(link.Text.Contains(".co.uk") || link.Text == ""))
                {
                    var url = link.GetAttribute("href");
                    request = (HttpWebRequest)WebRequest.Create(url);
                    try
                    {
                        var respond = (HttpWebResponse)request.GetResponse();
                        Console.WriteLine($"\t\n{url} statusCode is: {respond.StatusCode}");
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("An error occure while trying to verify link + {0}", e.Message);
                    }
                }
            }
        }

        
        public static void SwitchToWindow()
        {
            IList<string> handles = Browser.driver.WindowHandles;
            string ParentWindowHandle = Browser.driver.CurrentWindowHandle;
            foreach (string handle in handles)
            {
                if (!handle.Equals(ParentWindowHandle))
                {
                    Browser.driver.SwitchTo().Window(handle);
                }
            }
        }

       
        public static void SwitchToFrame(IWebElement frameElement)
        {
            try
            {
                Browser.driver.SwitchTo().Frame(frameElement);
            }
            catch (NoSuchFrameException ex)
            {
                Console.WriteLine($"THERE IS NO FRAME TO SWITCH TO {ex.Message}");
            }
        }

        
        public static void DragAndDropElement(IWebElement sourceElement, IWebElement targetElement)
        {
            Actions action = new Actions(Browser.driver);
            action.DragAndDrop(sourceElement, targetElement).Perform();
        }

       
        public static void DragAndDropElementToOffset(IWebElement elementToDragAndDrop, int x, int y)
        {
            Actions action = new Actions(Browser.driver);
            action.DragAndDropToOffset(elementToDragAndDrop, x, y).Perform();
        }

        
        public static void ClickAndHoldElement(IWebElement elementToHold)
        {
            Actions action = new Actions(Browser.driver);
            action.ClickAndHold(elementToHold).Perform();
        }

        
        public static void ReleaseElement(IWebElement elementToRelease)
        {
            Actions action = new Actions(Browser.driver);
            action.Release(elementToRelease).Perform();
        }

        
        public static void SwitchWindow()
        {
            IList<string> handles = Browser.driver.WindowHandles;
            string parent = Browser.driver.CurrentWindowHandle;
            foreach (string handle in handles)
            {
                if (handle != parent)
                {
                    try
                    {
                        Browser.driver.SwitchTo().Window(handle);
                    }
                    catch (NoSuchWindowException e)
                    {
                        Console.WriteLine($"NO OTHER WINDOW TO SWITCH TO OTHER THAN THE PARENT WINDOW {Environment.NewLine} {e.Message}");
                    }
                }
            }
        }

       
        public static void SwitchToParentWindow()
        {
            Browser.driver.SwitchTo().Window(Browser.driver.WindowHandles[0]);
        }

        
        public static string GetElementText(IWebElement elementToGetTextFrom)
        {
            var elementText = elementToGetTextFrom.Text;
            if (elementText.Equals(null))
            {
                Console.WriteLine("THE ELEMENT DOES NOT RETURN ANY TEXT");
                return "";
            }
            else return elementText;
        }

        
        public static  IWebElement LocateElementByClassName(string classNameToFind)
        {
            return Browser.driver.FindElement(By.ClassName(classNameToFind));
        }

        
        public static IWebElement LocateElementByCssSelector(string cssSelctorToFind)
        {
            return Browser.driver.FindElement(By.CssSelector(cssSelctorToFind));
        }

        
        public static IList<IWebElement> LocateElementsByCssSelector(string cssSelctorToFind)
        {
            return Browser.driver.FindElements(By.CssSelector(cssSelctorToFind));
        }

        
        public static IWebElement LocateElementByXPath(string xPathToFind)
        {
            IWebElement ele = null;
            try
            {
                ele = Browser.driver.FindElement(By.XPath(xPathToFind));
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"ENSURE THE CORRECT XPATH FOR THE ELEMENT INTENDED IS SUPPLIED {Environment.NewLine}{ex.Message}");
            }
            return ele;
        }

        
        public static IList<IWebElement> LocateElementsByXPath(string xpathToFind)
        {
            return Browser.driver.FindElements(By.XPath(xpathToFind));
        }

        
        public static IWebElement LocateElementById(string idToFind)
        {
            return Browser.driver.FindElement(By.Id(idToFind));
        }

       
        public static IWebElement LocateElementByLinkText(string linkTextToFind)
        {
            return Browser.driver.FindElement(By.LinkText(linkTextToFind));
        }

        
        public static IWebElement LocateElementByName(string nameToFind)
        {
            return Browser.driver.FindElement(By.Name(nameToFind));
        }

        
        public static IWebElement LocateElementByPartialLinkText(string partialLinkTextToFind)
        {
            return Browser.driver.FindElement(By.PartialLinkText(partialLinkTextToFind));
        }

       
        public static IWebElement LocateElementByTagName(string tagNameToFind)
        {
            return Browser.driver.FindElement(By.TagName(tagNameToFind));
        }


        
        public static bool IsElementPresent(By by)
        {
            try
            {
                Browser.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

       
        public static void ScrollToElement(IWebElement elementToScrollTo)
        {
            ((IJavaScriptExecutor)Browser.driver).ExecuteScript("arguments[0].scrollIntoView(true);", elementToScrollTo);
        }

        
        public static void SelectRandomOption(IList<IWebElement> webElements)
        {
            if (webElements.Count >= 1)
            {
                var random = new Random();
                int index = random.Next(webElements.Count);
                ClickOnElement(webElements[index]);
            }
        }
    }
}
