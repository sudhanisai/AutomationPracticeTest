using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class Shipping : BasePage
    {
        #region Constructor
        public Shipping(BrowserBase browser) : base(browser){}
        #endregion

        #region WebElement Properties
        
        [FindsBy(How = How.XPath,Using = "//h1[text() = 'Shipping']")]
        private IWebElement ShippingPageLbl { get; set; }
        
        /// <summary>
        /// Terms Of Service Check box
        /// </summary>
        [FindsBy(How = How.Id, Using = "cgv")]
        private IWebElement TermsOfServiceChk { get; set; }
        
        [FindsBy(How = How.Name, Using = "processCarrier")]
        private IWebElement ProceedToCheckOutBtn { get; set; }
        
        #endregion

        #region Methods
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//h1[text() = 'Shipping']"));
        }

        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }

        public override void ClickOperation(string elementName)
        {
            string trimmedElementName = elementName.Replace(" ", string.Empty).Trim();
            switch (trimmedElementName.ToUpper())
            {
                case "TERMSOFSERVICES":
                    TermsOfServiceChk.ClickOnElement();
                    break;
                case "PROCEEDTOCHECKOUT":
                    ProceedToCheckOutBtn.ClickOnElement();
                    break;
            }
        }
        #endregion
        
    }
}