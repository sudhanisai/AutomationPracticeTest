using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RetailApplication.Pages;
using TechTalk.SpecFlow;
using RetailApplication.Utilities;
using TechTalk.SpecFlow.Assist;

namespace RetailApplication.Steps
{
    [Binding]
    public sealed class StepDefinition
    {
        private readonly BrowserBase _browserBase;

        public StepDefinition(BrowserBase browserBase) => _browserBase = browserBase;
        
        [Given(@"I am resident from England")]
        public void GivenIAmResidentFromEngland(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _browserBase.LaunchBrowser((string)data.BrowserName);
            _browserBase.LaunchUrl((string)data.Url);
        }
        [Given(@"I launch the Retails application using below details")]
        public void GivenILaunchTheRetailsApplicationUsingBelowDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _browserBase.LaunchBrowser((string)data.BrowserName);
            _browserBase.LaunchUrl((string)data.Url);   
        }

        [Then(@"I should be displayed with ""(.*)"" screen")]
        public void ThenIShouldBeDisplayedWithScreen(string pageName)
        {
            BasePage page = PropertyManager.CreatePageInstance(pageName, _browserBase);
            Assert.That(page.CheckForPageLoad(), Is.True);
        }

        [When(@"I login using below details")]
        public void WhenILoginUsingBelowDetails(Table table)
        {
            var page = PropertyManager.GetCurrentInstance;
            page.KeyPageData(table);
        }

        [When(@"I click on ""(.*)"" button")]
        [When(@"I click on ""(.*)"" link")]
        [When(@"I move the cursor on to Tshirt image and click on ""(.*)"" button")]
        [When(@"I click on Agree ""(.*)"" checkbox")]
        public void WhenIClickOnButton(string elementName)
        {
            var page = PropertyManager.GetCurrentInstance;
            page.ClickOperation(elementName);
        }

        [Then(@"I should be dispalyed with Order Confirmation details")]
        public void ThenIShouldBeDispalyedWithOrderConfirmationDetails()
        {
            OrderConfirmation page = new OrderConfirmation(_browserBase);
            page.GetOrderReference();
        }

        [When(@"I update the below details")]
        public void WhenIUpdateTheBelowDetails(Table table)
        {
            var page = PropertyManager.GetCurrentInstance;
            page.KeyPageData(table);
        }

        [Then(@"I should be displayed with message ""(.*)""")]
        public void ThenIShouldBeDisplayedWithMessage(string message)
        {
            if (_browserBase.Driver.PageSource.Contains(message))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(true);
            }
        }

        [When(@"I verify the Order Reference generated and click on the same")]
        public void ThenIVerifyTheOrderReferenceGenerated()
        {
            OrderHistory page = new OrderHistory(_browserBase);
            Assert.That(page.CheckForOrderReference(), Is.True);
        }


        [Then(@"I should be displayed with Order Status Step by Step")]
        public void ThenIShouldBeDisplayedWithOrderStatusStepByStep()
        {
            OrderHistory page = new OrderHistory(_browserBase);
            Assert.That(page.IsStatusDisplayed(), Is.True);
        }


        [Given(@"user is on TFL home page")]
        public void GivenUserIsOnTflHomePage()
        {
            _browserBase.LaunchBrowser("Chrome");
            _browserBase.LaunchUrl("https://tfl.gov.uk/");  
        }

        [Given(@"user plans a jouney from London Victoria to London Bridge")]
        [When(@"user plans a jouney from London Victoria to London Bridge")]
        public void WhenUserPlansAJouneyFromLondonVictoriaToLondonBridge()
        {
            BasePage page = PropertyManager.CreatePageInstance("TFLHomePage", _browserBase);
            Assert.That(page.CheckForPageLoad(), Is.True);
            page.KeyPageData();
        }


        [Then(@"user should be presented with the Journey results page with the correct summary")]
        public void ThenUserShouldBePresentedWithTheJourneyResultsPageWithTheCorrectSummary()
        {
            BasePage page = PropertyManager.CreatePageInstance("JourneyResults", _browserBase);
            Assert.That(page.CheckForPageLoad(), Is.True);
        }

        [Then(@"user can see the fastest route")]
        public void ThenUserCanSeeTheFastestRoute()
        {
            var page = PropertyManager.GetCurrentInstance;
            page.KeyPageData();
        }

        /// <summary>
        /// 
        /// </summary>
        [Given(@"I am on Compare how much electrical appliances cost to use screen")]
        public void GivenIAmOnCompareHowMuchElectricalAppliancesCostToUseScreen()
        {
            BasePage page = PropertyManager.CreatePageInstance("HomeAppliances", _browserBase);
            Assert.That(page.CheckForPageLoad(), Is.True);
        }

        [When(@"I select country as ""(.*)""")]
        public void WhenISelectCountryAs(string value)
        {
            var page = PropertyManager.GetCurrentInstance;
            page.ClickOperation(value);
        }

        [When(@"I enter the below list of appliances and click on Add appliance to your list")]
        public void WhenIEnterTheBelowListOfAppliancesAndClickOnAddApplianceToYourList(Table table)
        {
            var page = PropertyManager.GetCurrentInstance;
            page.KeyPageData(table);
        }
        
        [Then(@"all the ""(.*)"" appliances list should be displayed in the table below\.")]
        public void ThenAllTheAppliancesListShouldBeDisplayedInTheTableBelow(string value)
        {
            var page = new HomeAppliances(_browserBase);
            Assert.IsTrue(page.CountNumberOfRowsIntable(value));
        }
    }
}