using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class ShoppingCartSummary : BasePage
    {
        #region Constructor
        public ShoppingCartSummary(BrowserBase browser) : base(browser){}
        #endregion

        #region WebElement Properties
        
        [FindsBy(How = How.Id, Using = "cart_title")]
        private IWebElement ShoppingCartSummaryLbl { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/p[2]/a[1]")]
        private IWebElement ProceedToCheckOutBtn { get; set; }
        
        #endregion

        #region Methods
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.Id("cart_title"));
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
                case "PROCEEDTOCHECKOUT":
                    ProceedToCheckOutBtn.ClickOnElement();
                    break;
            }
        }
        
        #endregion
    }
}