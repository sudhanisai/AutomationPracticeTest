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
    }
}