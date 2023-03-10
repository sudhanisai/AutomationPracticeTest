using NUnit.Framework;
using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class JourneyResults : BasePage
    {
        public JourneyResults(BrowserBase browser) : base(browser)
        {
        }

        #region Properties

        
        /// <summary>
        /// Journey Results Label 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//span[@class = 'jp-results-headline' and text() = 'Journey results']")]
        private IWebElement JourneyResultsLabel { get; set; }
        
        /// <summary>
        /// Fastest By Public Transport Label 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//*[@class = 'jp-result-transport publictransport clearfix' and text() = 'Fastest by public transport']")]
        private IWebElement FastestByPublicTransportLabel { get; set; }
        
        
        /// <summary>
        /// Fastest By Public Transport Label 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//a[text() = 'View details']")]
        private IWebElement ViewDetailsButton { get; set; }
        
        
        /// <summary>
        /// London Bridge Station Link 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//span[text() = 'London Bridge, London Bridge Station']")]
        private IWebElement LondonBridgeStationLink { get; set; }
        
        
        /// <summary>
        /// Edit Journey Link 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//span[text() = 'Edit journey']")]
        private IWebElement EditJourneyLink { get; set; }
        
        //span[text() = 'Waterloo (London), London Waterloo']
        
        #endregion
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//span[@class = 'jp-results-headline' and text() = 'Journey results']"));
        }

        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }

        public override void ClickOperation(string elementName)
        {
            throw new System.NotImplementedException();
        }

        public override void KeyPageData()
        {
            BrowserBase.WaitForElementToBeClickable(LondonBridgeStationLink);
            LondonBridgeStationLink.ClickOnElement();
            BrowserBase.WaitForElementToBeVisible(By.XPath(
                "//*[@class = 'jp-result-transport publictransport clearfix' and text() = 'Fastest by public transport']"));
            if (FastestByPublicTransportLabel.IsDisplayed())
            {
                ViewDetailsButton.ClickOnElement();
            }
            else
            {
                Assert.Fail("Expected Section is not displayed");
            }
            
        }
    }
}