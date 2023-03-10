using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RetailApplication.Pages
{
    public class YourPersonalInformation : BasePage
    {
        #region Constructor

        public YourPersonalInformation(BrowserBase browser) : base(browser){}

        #endregion

        #region WebElement Properties

        /// <summary>
        /// My Personal InformationLabel
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/div/h1")]
        private IWebElement MyPersonalInfoLbl { get; set; }
        
        /// <summary>
        /// First Name Text Box
        /// </summary>
        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement FirstName { get; set; }
        
        /// <summary>
        /// Save Button
        /// </summary>
        [FindsBy(How = How.Name, Using = "submitIdentity")]
        private IWebElement SaveBtn { get; set; }
        
        /// <summary>
        /// Current Password Text Box
        /// </summary>
        [FindsBy(How = How.Id, Using = "old_passwd")]
        private IWebElement CurrentPasswordTxb { get; set; }
        
        #endregion

        #region Methods
        
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//*[@id='center_column']/div/h1"));
        }

        public override void KeyPageData(Table table)
        {
            var oYourPersonalInfo = table.CreateInstance<YourPersonalInfoData>();
            FirstName.SetInput(oYourPersonalInfo.FirstName);
            CurrentPasswordTxb.SetInput(oYourPersonalInfo.CurrentPassword);
        }

        public override void ClickOperation(string elementName)
        {
            string trimmedElementName = elementName.Replace(" ", string.Empty).Trim();
            switch (trimmedElementName.ToUpper())
            {
                case "SAVE":
                    SaveBtn.ClickOnElement();
                    break;
            }
        }
        
        #endregion
    }

    public class YourPersonalInfoData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentPassword { get; set; }
        /* Add other fields details if required for others scenarios */
    }
}