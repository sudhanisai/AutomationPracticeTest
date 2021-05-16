using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace RetailApplication.Utilities
{
    [Binding]
    public sealed class Hooks
    {
        private static FeatureContext _featureContext;
        private static ScenarioContext _scenarioContext;
        private readonly BrowserBase _browserBase;
        private static ExtentReports _extentReport;
        private static ExtentTest _featureName;
        private static ExtentTest _scenarioName;
        

        public Hooks(BrowserBase browserBase,ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
            _browserBase = browserBase;
        } 
        
        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"/Users/saikumarsudhani/Automation/RetailApplication/RetailApplication/Reports/TestResult.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            
            _extentReport = new ExtentReports();
            _extentReport.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extentReport.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            _featureContext = featureContext;
            if (null != _featureContext)
            {
                _featureName = _extentReport.CreateTest<Feature>(_featureContext.FeatureInfo.Title, 
                    _featureContext.FeatureInfo.Description);
            }
        }
        
            
        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            if (null != _scenarioContext && null !=_featureName)
            {
                _scenarioName = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title,
                   _scenarioContext.ScenarioInfo.Description);
            }
        }

        [AfterStep]
        public void AfterStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            var exception = _scenarioContext.TestError;
            if (null == exception)
            {
                switch (scenarioBlock)
                {
                    case ScenarioBlock.Given:
                        _scenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case ScenarioBlock.When:
                        _scenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    case ScenarioBlock.Then:
                        _scenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                    default:
                        _scenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                        break;
                }    
            }
            else if (null != exception)
            {
                var mediaEntity = _browserBase.CaptureScreenshot(_scenarioContext.ScenarioInfo.Title.Trim());
                switch (scenarioBlock)
                {
                    case ScenarioBlock.Given:
                        _scenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;
                    case ScenarioBlock.When:
                        _scenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;
                    case ScenarioBlock.Then:
                        _scenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;
                    default:
                        _scenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                        break;
                }
            }
            
        }
        
        [AfterScenario]
        public void AfterScenario()
        {
            _browserBase.Driver.Quit();
            _browserBase.Driver = null; // Reset the Driver instance to Null post each scenario
            _browserBase.OrderNumber = string.Empty; // Reset the Order Number to empty string post each scenario
        }
    }
}