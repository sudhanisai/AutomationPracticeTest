using OpenQA.Selenium;
using RetailApplication.Utilities;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Pages
{
    public class Tshirts : BasePage
    {
        #region Constructor
        public Tshirts(BrowserBase browserBase) : base(browserBase){}
        #endregion

        #region WebElement Properties
        /// <summary>
        /// TShirt Label
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//span[@class = 'cat-name']")]
        public IWebElement TshirtsLbl { get; set; }
        
        /// <summary>
        /// Tshirt Image
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//img[@title = 'Faded Short Sleeve T-shirts']")]
        private IWebElement TshirtImg { get; set; }
        
        /// <summary>
        /// Add To Cart Button
        /// </summary>
        [FindsBy(How = How.XPath,Using = "//span[text() = 'Add to cart']")]
        private IWebElement AddToCartBtn { get; set; }
        
        /// <summary>
        /// Proceed To Check out Button
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//a[@title = 'Proceed to checkout']")]
        private IWebElement ProceedToCheckOutBtn { get; set; }

        #endregion

        #region Methods
        public override bool CheckForPageLoad()
        {
            return BrowserBase != null && BrowserBase.WaitForElementToBeVisible(By.XPath("//span[@class = 'cat-name']"), 20);
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
                case "ADDTOCART":
                    TshirtImg.MoveToElementByAction(BrowserBase);
                    AddToCartBtn.ClickOnElement();
                    break;
                case "PROCEEDTOCHECKOUT":
                    BrowserBase.WaitForElementToBeClickable(ProceedToCheckOutBtn, 20);
                    ProceedToCheckOutBtn.ClickOnElement();
                    break;
            }
        }
        #endregion
    }
}