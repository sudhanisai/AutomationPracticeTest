using System;
using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class Home : BasePage
    {
        

        #region Constructor
        public Home(BrowserBase browserBase):base(browserBase){}
        #endregion

        #region WebElement Properties
        
        /// <summary>
        /// Header Logo 
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//*[@src = 'http://automationpractice.com/img/logo.jpg']")]
        private IWebElement HeaderLogo { get; set; }
        
        /// <summary>
        /// Sign In Link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@class ='login']")]
        private IWebElement SignInLnk { get; set; }
        
        /// <summary>
        /// Contact us Link
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@title ='Contact Us']")]
        private IWebElement ContactUsLnk { get; set; }

        #endregion

        #region Methods
        
        /// <summary>
        /// Method to check for PageLoad / Sync
        /// </summary>
        /// <returns> bool </returns>
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(
                By.XPath("//*[@src = 'http://automationpractice.com/img/logo.jpg']"));
        }
        
        /// <summary>
        /// Method to input the data on to the screen
        /// </summary>
        /// <param name="table"></param>
        public override void KeyPageData(Table table)
        {
            throw new System.NotImplementedException();
        }
    
        /// <summary>
        /// Method to perform Click Operations on the screen
        /// </summary>
        /// <param name="elementName"></param>
        public override void ClickOperation(string elementName)
        {
            string trimmedElementName = elementName.Replace(" ", string.Empty).Trim();
            switch (trimmedElementName.ToUpper())
            {
                case "SIGNIN":
                    SignInLnk.ClickOnElement();
                    break;
                case "CONTACTUS":
                    ContactUsLnk.ClickOnElement();
                    break;
            }
            
        }
        
        #endregion
    }
}