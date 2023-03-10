using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RetailApplication.Pages
{
    public class HomeAppliances : BasePage
    {
        private readonly BrowserBase _browserBase;
        public HomeAppliances(BrowserBase browser) : base(browser)
        {
            _browserBase = browser;
        }
        
        #region WebElement Properties
        
        [FindsBy(How = How.XPath, Using = "//span[text() = 'Compare how much electrical appliances cost to use']")]
        private IWebElement PageName { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id = 'RootPlaceHolder_RootPlaceHolder_SubHeading']/span/a")]
        private IWebElement CountryLink { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id = 'dialog-1-main']/ul/li")]
        private IWebElement CountryList { get; set; }
        
        [FindsBy(How = How.Id, Using = "appliance")]
        private  IWebElement AddAnAppliances { get; set; }
        
        [FindsBy(How = How.Id, Using = "hours")]
        private  IWebElement Hours { get; set; }

        [FindsBy(How = How.Id, Using = "mins")]
        private  IWebElement Mins { get; set; }
        
        [FindsBy(How = How.Id, Using = "submit")]
        private  IWebElement AddAppliancesToListBtn { get; set; }
        
        [FindsBy(How = How.Id, Using = "kwhcost")]
        private  IWebElement Khw { get; set; } 
        #endregion
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(
                By.XPath("//span[text() = 'Compare how much electrical appliances cost to use']"));
        }

        public override void KeyPageData(Table table)
        {
            var appliancesList = table.CreateSet<ApplianceData>();
            int count = 1;
            foreach (var appliances in appliancesList)
            {
               // AddAnAppliances.SelectDropdownList(appliances.Appliance.ToString());
                SelectElement element = new SelectElement(AddAnAppliances);
                element.SelectByIndex(count);
                Hours.SetInput(appliances.Hours);
                Mins.SetInput(appliances.mins);
                if(Khw.Displayed)
                    Khw.SetInput(appliances.kwh);
                ClickOperation("AddAnAppliance");
                count++;
            }
        }

        public override void ClickOperation(string elementName)
        {
            switch (elementName)
            {
                case "AddAnAppliance":
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)_browserBase.Driver;
                    executor.ExecuteScript("arguments[0].click();", AddAppliancesToListBtn);
                    break;
                default:
                    SelectCountry(elementName);
                    break;
            }
        }

        public void SelectCountry(string value)
        {
            CountryLink.Click();
            IList<IWebElement> countryList = BrowserBase.GetListOfWebElements(By.XPath("//*[@id = 'dialog-1-main']/ul/li"));
            foreach (var country in countryList)
            {
                if (country.Text.Equals(value))
                {
                    country.Click();
                    break;
                }
            }
        }

        public bool CountNumberOfRowsIntable(string value)
        {
            bool rowCountMatch = false;
            IList<IWebElement> tableRows =
                BrowserBase.GetListOfWebElements(By.XPath("//*[@id='appliance_running']/table/tbody/tr"));
            if(tableRows.Count.Equals(int.Parse(value)))
           { 
               rowCountMatch = true;
           }
           return rowCountMatch;
        }
    }

    public class ApplianceData
    {
        public string Appliance { get; set; }
        public string Hours { get; set; }
        public string mins { get; set; }
        public string kwh { get; set; }
    }
}