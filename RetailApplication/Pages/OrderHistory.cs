using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class OrderHistory : BasePage
    {
        public OrderHistory(BrowserBase browser) : base(browser){}


        #region WebElement Properties
        
      
        //h1[text() = 'Order history']
        [FindsBy(How = How.XPath, Using = "//h1[text() = 'Order history']")]
        private IWebElement OrderHistoryLbl { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block-order-detail']/h1")]
        private IWebElement OrderStatusStepByStepLbl { get; set; }

        #endregion

        #region Methods

        
        /// <summary>
        /// Method to verify & click the Order Reference Number
        /// </summary>
        /// <returns></returns>
        public bool CheckForOrderReference()
        {
            bool orderMatched = false;
            IList<IWebElement> tableRows =
                BrowserBase.GetListOfWebElements(By.XPath("//*[@id = 'order-list']/tbody/tr/td[1]"));
            if (tableRows.Count > 0)
            {
                for (int i = 0; i < tableRows.Count; i++)
                {
                    string orderRef = tableRows[i].Text.Trim();
                    if (orderRef.Equals(BrowserBase.OrderNumber))
                    {
                        orderMatched = true;
                        tableRows[i].ClickOnElement();
                        break;
                    }
                }
            }
            return orderMatched;
        }
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//h1[text() = 'Order history']"));
        }

        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }

        public override void ClickOperation(string elementName)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        ///  Method to check for Order Status Step by Step Label displayed or not
        /// </summary>
        /// <returns></returns>
        public bool IsStatusDisplayed()
        {
            BrowserBase.WaitForElementToBeVisible(By.XPath("//*[@id='block-order-detail']/h1"));
            return OrderStatusStepByStepLbl.IsDisplayed();
        }
        
        #endregion
    }
}