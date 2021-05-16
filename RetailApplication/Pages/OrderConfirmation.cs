using System;
using MongoDB.Bson.IO;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using RetailApplication.Utilities;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class OrderConfirmation : BasePage
    {
        #region Constructor
        public OrderConfirmation(BrowserBase browser) : base(browser){}
        #endregion
        
        #region WebElement Properties
        [FindsBy(How = How.XPath,Using = "//*[text() = 'Your order on My Store is complete.']")]
        private IWebElement ConfirmationText { get; set; }
        
        
        [FindsBy(How = How.XPath,Using = "//a[@title = 'Return to Home']")]
        private IWebElement HomeBtn { get; set; }
        
        
        [FindsBy(How = How.XPath,Using = "//div[@class ='box']")]
        private IWebElement OrderConfirmationBox { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Back to orders']")]
        private IWebElement BackToOrderLnk { get; set; }
        
        
        #endregion

        #region Methods

         public override bool CheckForPageLoad()
         {
             return BrowserBase.WaitForElementToBeVisible(
                 By.XPath("//*[text() = 'Your order on My Store is complete.']"));
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
                case "BACKTOORDERS":
                    BackToOrderLnk.ClickOnElement();
                    break;
            }
        }
        
        /// <summary>
        /// Method To get the Order Reference number post Order Confirmation
        /// </summary>
        public void GetOrderReference()
        {
            string strStart = "reference";
            string strEnd = "in";
            string orderSummary = OrderConfirmationBox.Text;
            if (orderSummary.Contains(strStart) && orderSummary.Contains(strEnd))
            {
                int start, end;
                start = orderSummary.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
                end = orderSummary.IndexOf(strEnd, start, StringComparison.Ordinal);
                BrowserBase.OrderNumber = orderSummary.Substring(start, end - start).Trim();
                Console.WriteLine($"Order ref : {BrowserBase.OrderNumber}" );
            }
        }
        
        #endregion
    }
}