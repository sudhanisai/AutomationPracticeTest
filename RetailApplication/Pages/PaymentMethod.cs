using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class PaymentMethod : BasePage
    {
        #region Constructor
        
        public PaymentMethod(BrowserBase browser) : base(browser){}
        
        #endregion
        
        #region WebElement Properties
        
        [FindsBy(How = How.XPath,Using = "//h1[text() = 'Please choose your payment method']")]
        private IWebElement PaymentMethodLbl { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Pay by bank wire']")]
        private IWebElement PayByBankWireLnk { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Pay by check.']")]
        private IWebElement PayByCheckLnk { get; set; }
        #endregion

        #region  Methods
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(
                By.XPath("//h1[text() = 'Please choose your payment method']"));
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
                case "PAYBYBANKWIRE":
                    PayByBankWireLnk.ClickOnElement();
                    break;
                case "PAYBYCHECK":
                    PayByCheckLnk.ClickOnElement();
                    break;
            }
        }
        
        #endregion
    }
}