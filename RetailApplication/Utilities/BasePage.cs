using System;
using System.Reflection;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RetailApplication.Utilities
{
    public abstract class BasePage
    {
        protected BrowserBase BrowserBase { get; private set; }
        protected BasePage(BrowserBase browser)
        {
            if (browser?.Driver != null)
            { 
                PageFactory.InitElements(browser.Driver, this);
            }
            BrowserBase = browser;
        }
        
        /* Abstract method for Page Load Assertion */ 
        public abstract bool CheckForPageLoad();
        
        /* Abstract method for Business Logic Execution */ 
        public abstract void KeyPageData(Table table);
        
        /* Abstract method for Click Operation */ 
        public abstract void ClickOperation(string elementName);
        
        public virtual void KeyPageData(){}
    }
    
    public static class PropertyManager
    {
        /// <summary>
        /// Hold the current Page instance until new page instance is created
        /// </summary>
        public static BasePage GetCurrentInstance { get; set; }
        
        /// <summary>
        /// Method to Create a Page Instance using Reflection
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="browserBase"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static BasePage CreatePageInstance(string pageName, BrowserBase browserBase)
        {
            string trimmedPageName = pageName.Replace(" ", string.Empty).Trim();

            string assemblyName = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
            string fullPageName = $"{assemblyName}.Pages.{trimmedPageName},{assemblyName}";

            GetCurrentInstance = Activator.CreateInstance(Type.GetType(fullPageName), browserBase) as BasePage;
            if (!GetCurrentInstance.GetType().IsSubclassOf(typeof(BasePage)))
            {
                throw new InvalidOperationException(
                    $"Exception Occured while create page instance for : {trimmedPageName}. Which is not a BasePage derived class");
            }
            return GetCurrentInstance;
        }
            
    }
}