using System.Globalization;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class OrderSummary : BasePage
    {
        #region Constructor
        public OrderSummary(BrowserBase browser) : base(browser){}
        #endregion
        
        #region WebElement Properties

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/h1")]
        private IWebElement OrderSummaryLbl { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "//span[text() = 'I confirm my order']")]
        private IWebElement ConfirmMyOrderBtn { get; set; }
        

        #endregion

        #region  Methods
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//*[@id='center_column']/h1"));
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
                case "CONFIRMMYORDER":
                    ConfirmMyOrderBtn.ClickOnElement();
                    break;
                case "OTHERPAYMENTMETHODS":
                    break;
            }
        }
        
        #endregion
    }
}