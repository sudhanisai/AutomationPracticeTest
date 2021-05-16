using System;
using NUnit.Framework;
using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class MyAccount : BasePage
    {
        #region Constructor
        public MyAccount(BrowserBase browserBase) : base(browserBase){}
        #endregion

        #region WebElement Properties
        /// <summary>
        /// TShirt Link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[3]/a")]
        private IWebElement TshirtsLnk { get; set; }
        
        /// <summary>
        /// Order History And details Link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Order history and details']")]
        private IWebElement OrderHistoryAndDetailsLnk { get; set; }
        
        /// <summary>
        /// View Customer Account link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@title = 'View my customer account']")]
        private IWebElement ViewMyCustomerAccountLnk { get; set; }
                
        /// <summary>
        /// My Personal Information Link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[text() = 'My personal information']")]
        private IWebElement MyPersonalInfoLnk { get; set; }

        #endregion

        #region Methods
        public override bool CheckForPageLoad()
        {
            return BrowserBase != null && BrowserBase.WaitForElementToBeVisible(By.XPath("//*[@id='block_top_menu']/ul/li[3]/a"), 20);
        }

        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }

        public override void ClickOperation(string elementName)
        {
            string element = elementName.Replace(" ", String.Empty).Trim();
            switch (element.ToUpper())
            {
                case "TSHIRTS":
                    TshirtsLnk.ClickOnElement();
                    break;
                case "VIEWMYCUSTOMERACCOUNT":
                    ViewMyCustomerAccountLnk.ClickOnElement();
                    break;
                case "MYPERSONALINFORMATION":
                    MyPersonalInfoLnk.ClickOnElement();
                    break;
                case "ORDERHISTORYANDDETAILS":
                    OrderHistoryAndDetailsLnk.ClickOnElement();
                    break;
                /* Can implement other case if we need to click on any other links/button on the screen*/
            }
        }
        #endregion
        
    }
}