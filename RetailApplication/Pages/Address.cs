using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class Address : BasePage
    {
        
        #region Constructor
        public Address(BrowserBase browser) : base(browser){}
        #endregion
        

        #region WebElement Properties
        
        [FindsBy(How = How.XPath, Using = "//div[@id='center_column']/h1")]
        private IWebElement AddressesLbl { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//button[@name='processAddress']")]
        private IWebElement ProceedToCheckOutBtn { get; set; }
        
        #endregion

        #region Methods
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//div[@id='center_column']/h1"));
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