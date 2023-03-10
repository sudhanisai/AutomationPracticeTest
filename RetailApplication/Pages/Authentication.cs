using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RetailApplication.Pages
{
    public class Authentication : BasePage
    {
        #region Constructor
        public Authentication(BrowserBase browserBase) : base(browserBase){}
        #endregion

        #region WebElement Properties

        /// <summary>
        /// Authentication Label 
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//*[text() = 'Authentication']")]
        private IWebElement AuthenticationLbl { get; set; }
        
        /// <summary>
        /// Email Address Text Box 
        /// </summary>
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailAddressTxb { get; set; }
        
        /// <summary>
        /// Password Text Box 
        /// </summary>
        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement PasswordTxb { get; set; }
        
        /// <summary>
        /// Sign In Button
        /// </summary>
        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement SignInBtn { get; set; }
        
        /// <summary>
        /// Create An Account Button
        /// </summary>
        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement CreateAnAccountBtn { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Method to check for PageLoad / Sync
        /// </summary>
        /// <returns> bool </returns>
        public override bool CheckForPageLoad()
        {
            return BrowserBase.WaitForElementToBeVisible(By.XPath("//*[text() = 'Authentication']"), 20);
        }
        
        /// <summary>
        /// Method to input the data on to the screen
        /// </summary>
        /// <param name="table"></param>
        public override void KeyPageData(Table table)
        {
            var oAuthenticationData = table.CreateInstance<AuthenticationData>();
            EmailAddressTxb.SetInput(oAuthenticationData.EmailAddress);
            PasswordTxb.SetInput(oAuthenticationData.Password);
        }
        
        /// <summary>
        /// Method to perform Click Operations on the screen
        /// </summary>
        /// <param name="elementName"></param>
        public override void ClickOperation(string elementName)
        {
            switch (elementName.ToUpper())
            {
                case"SIGN IN":
                    SignInBtn.ClickOnElement();
                    break;
                case"CREATE AN ACCOUNT":
                    CreateAnAccountBtn.ClickOnElement();
                    break;
            }
        }
        #endregion
    }

    public class AuthenticationData
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}