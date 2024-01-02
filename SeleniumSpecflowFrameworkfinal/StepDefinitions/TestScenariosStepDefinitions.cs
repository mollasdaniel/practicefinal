using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using SeleniumSpecflowFrameworkfinal.Pages;
using SeleniumSpecflowFrameworkfinal.SetUp;
using SeleniumSpecflowFrameworkfinal.Support;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflowFrameworkfinal.StepDefinitions
{
    [Binding]
    public class TestScenariosStepDefinitions
    {
        [Given(@"I navigate to the page")]
        public void GivenINavigateToThePage()

        {

            TestHelpers.NavigateToPage("https://www.universalproductionmusic.com/en-gb");

        }

        [When(@"I complete the form in frame and submit")]
        public void WhenICompleteTheFormInFrameAndSubmit()
        {
            Site.Page<HomePage>().NavigateToAlbumsPage();   
            Site.Page<IframePage>().CompleteUserForm("daniel", "njie", "diony@yahoo.com");
        }

        [Then(@"I shuld see a successful message")]
        public void ThenIShuldSeeASuccessfulMessage()
        {
            Browser.driver.SwitchTo().ParentFrame();
            var text = TestHelpers.GetElementText(TestHelpers.LocateElementByCssSelector(".title.has-text-info"));
            Assert.IsTrue(text.Equals("You have entered daniel njie"));
           // throw new PendingStepException();
        }
        [Given(@"I navigate to the  window page")]
        public void GivenINavigateToTheWindowPage()
        {
            TestHelpers.NavigateToPage("https://letcode.in/windows"); ;
        }

        [When(@"I click on the newPage Button")]
        public void WhenIClickOnTheNewPageButton()
        {
           Site.Page<WindowsPage>().clickOnHomePageBtn();
        }

        [Then(@"a new page window should open with Title ""([^""]*)""")]
        public void ThenANewPageWindowShouldOpenWithTitle(string title)
        {
            TestHelpers.SwitchToWindow();
            Assert.IsTrue(Browser.driver.Title.Equals(title));  
        }
        [Then(@"I switch back to parent window with title ""([^""]*)"" and closed window")]
        public void ThenISwitchBackToParentWindowWithTitleAndClosedWindow(string ttile)
        {
            TestHelpers.SwitchToParentWindow();
            Browser.driver.Close();    
        }


    }
}
