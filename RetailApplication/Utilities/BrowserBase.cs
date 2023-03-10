using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ExpectedCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace RetailApplication.Utilities
{
    public class BrowserBase
    {
        /// <summary>
        /// WebDriver instance Variable
        /// </summary>
        public IWebDriver Driver { get; set; }
        
        /// <summary>
        /// Order reference details
        /// </summary>
        public string OrderNumber { get; set; } 
        
        /// <summary>
        /// Method to launch Browser based on the input passed from feature file
        /// </summary>
        /// <param name="browserName"></param>
        public void LaunchBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "IE":
                    LaunchIE();
                    break;
                case "CHROME":
                    LaunchChrome();
                    break;
            }
        }
        
        /// <summary>
        /// Method to launch Chrome Browser
        /// </summary>
        private void LaunchChrome()
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("--dns-prefetch-disable");
            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            Driver = new ChromeDriver(options);
            Driver.Manage().Window.Maximize();
        }
        
        private void LaunchIE()
        {
            // implement for IE driver instance
        }
        
        /// <summary>
        /// Abstract method for Launching URL/URI 
        /// </summary>
        /// <param name="url"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void LaunchUrl(string url)
        {
            if (null == Driver)
            {
                throw new InvalidOperationException("WebDriver has not been initialized");
            }
            else
            {
                /* Launch URL */
                Driver.Navigate().GoToUrl(url);
            }
        }
        
        
        /// <summary>
        /// Wrapper Method to wait for specified time for the element to be visible
        /// </summary>
        /// <param name="byElement"></param>
        /// <param name="waitTimeInSec"></param>
        /// <returns> bool </returns>
        public bool WaitForElementToBeVisible(By byElement, int waitTimeInSec = 30)
        {
            bool isVisible = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSec));
                wait.Until(ExpectedCondition.ElementIsVisible(byElement));
                if (Driver.FindElement(byElement).Displayed)
                {
                    isVisible = true;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Exception Occured on Page Load : {ex.Message}");
                throw;
            }
            return isVisible;
        }
        
        /// <summary>
        ///  Wrapper Method to wait for specified time for the element to be clickable
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="waitTimeInSec"></param>
        /// <returns></returns>
        public bool WaitForElementToBeClickable(IWebElement elementName, int waitTimeInSec = 30)
        {
            bool isClickable = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitTimeInSec));
                wait.Until(ExpectedCondition.ElementToBeClickable(elementName));
                if (elementName.IsDisplayed() && elementName.IsEnabled())
                {
                    isClickable = true;
                }
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Exception Occured on Page Load : {ex.Message}");
                throw;
            }
            return isClickable;
        }
        
        /// <summary>
        /// Method to get the List of IWebElements using "FindElements"
        /// </summary>
        /// <param name="elementBy"></param>
        /// <returns></returns>
        public IList<IWebElement> GetListOfWebElements(By elementBy)
        {
            IList<IWebElement> listOfElements = null;
            if(null != elementBy)
            {
                listOfElements = Driver.FindElements(elementBy);
            }
            return listOfElements;
        }
        
        private void WaitForPageToLoad(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            try
            {
                wait.Until(driver => ExpectedConditions.StalenessOf(element)(Driver) &&
                                     ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception pageLoadWaitError)
            {
                throw new TimeoutException("Timeout during page load", pageLoadWaitError);
            }
        }
        
        /// <summary>
        /// Method to Capture (On Failure) Screenshot when its called from Hook.cs
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MediaEntityModelProvider CaptureScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot) Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }
    }
}