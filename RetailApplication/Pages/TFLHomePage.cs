using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace RetailApplication.Pages
{
    public class TFLHomePage : BasePage
    {
        public TFLHomePage(BrowserBase browser) : base(browser)
        {
        }

        #region Properties
        
        /// <summary>
        /// From Text Box 
        /// </summary>
        [FindsBy(How = How.Id,Using = "hp-journey-planner")]
        private IWebElement JourneyPlannerScreenLbl { get; set; }
        
        /// <summary>
        /// From Text Box 
        /// </summary>
        [FindsBy(How = How.Id,Using = "InputFrom")]
        private IWebElement FromTxtBox { get; set; }
        
        /// <summary>
        /// To Text Box 
        /// </summary>
        [FindsBy(How = How.Id,Using = "InputTo")]
        private IWebElement ToTxtBox { get; set; }

        /// <summary>
        /// Plan Journey Button 
        /// </summary>
        [FindsBy(How = How.Id,Using = "plan-journey-button")]
        private IWebElement PlanJourneyButton { get; set; }
        
        /// <summary>
        /// Error Msg Span 
        /// </summary>
        [FindsBy(How = How.Id,Using = "InputTo-error")]
        private IWebElement ErrorMsgSpan { get; set; }
        
        
        /// <summary>
        /// Accept Cookies Button 
        /// </summary>
        [FindsBy(How = How.Id,Using = "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")]
        private IWebElement AcceptCookiesButton { get; set; }
        
        
        /// <summary>
        /// Done Button 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//*[@id='cb-confirmedSettings']/div[2]/button")]
        private IWebElement CookiesDoneButton { get; set; }

        #endregion

        #region Method

        
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.Id("hp-journey-planner"));
        }

        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }

        public override void KeyPageData()
        {
            BrowserBase.WaitForElementToBeVisible(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
            AcceptCookiesButton.ClickOnElement();
            CookiesDoneButton.ClickOnElement();
            FromTxtBox.SetInput("London Victoria Rail Station");
            ToTxtBox.SetInput(("London Bridge"));
            PlanJourneyButton.ClickOnElement();
        }

        public override void ClickOperation(string elementName)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }
}