using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Utilities
{
    public abstract class ButtonsPage : BasePage
    {
        public ButtonsPage(BrowserBase browser) : base(browser){}
        
        
       // [FindsBy(How = How.XPath, Using = "//a[@title = 'Proceed to checkout']")]
       [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/p[2]/a[1]")]
        public IWebElement ProceedToCheckOutBtn { get; set; }
        
        
        [FindsBy(How = How.XPath, Using = "//*[@title = 'Continue shopping']")]
        public IWebElement ContinueShoppingBtn { get; set; }
        
        internal void ClickOn(string elementName)
        {
            string trimmedElementName = elementName.Replace(" ", string.Empty).Trim();
            switch (elementName.ToUpper())
            {
                case "PROCEEDTOCHECKOUT":
                    ProceedToCheckOutBtn.ClickOnElement();
                    break;
                case "CONTINUESHOPPING":
                    ContinueShoppingBtn.ClickOnElement();
                    break;
            }
        }
    }
}