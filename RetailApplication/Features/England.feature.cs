﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.8.0.0
//      SpecFlow Generator Version:3.8.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace RetailApplication.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.8.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Add Appliances for England Country")]
    public partial class AddAppliancesForEnglandCountryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "England.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Add Appliances for England Country", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Url",
                        "BrowserName"});
            table1.AddRow(new string[] {
                        "https://www.citizensadvice.org.uk/consumer/energy/energy-supply/get-help-paying-y" +
                            "our-bills/check-how-much-your-electrical-appliances-cost-to-use/",
                        "Chrome"});
#line 4
 testRunner.Given("I am resident from England", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Home Appliances For England")]
        [NUnit.Framework.CategoryAttribute("England")]
        public virtual void HomeAppliancesForEngland()
        {
            string[] tagsOfScenario = new string[] {
                    "England"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Home Appliances For England", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 10
 testRunner.Given("I am on Compare how much electrical appliances cost to use screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 11
 testRunner.When("I select country as \"England\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Appliance",
                            "Hours",
                            "Minutes",
                            "KWH"});
                table2.AddRow(new string[] {
                            "Air Friyer",
                            "1",
                            "10",
                            "34"});
                table2.AddRow(new string[] {
                            "Dishwasher",
                            "0",
                            "30",
                            ""});
                table2.AddRow(new string[] {
                            "Fan heater",
                            "1",
                            "30",
                            ""});
                table2.AddRow(new string[] {
                            "Iron",
                            "1",
                            "00",
                            ""});
                table2.AddRow(new string[] {
                            "Oven",
                            "1",
                            "30",
                            ""});
                table2.AddRow(new string[] {
                            "TV",
                            "2",
                            "10",
                            ""});
                table2.AddRow(new string[] {
                            "Towel rail",
                            "1",
                            "10",
                            ""});
                table2.AddRow(new string[] {
                            "Toaster",
                            "1",
                            "10",
                            ""});
#line 12
    testRunner.And("I enter the below list of appliances and click on Add appliance to your list", ((string)(null)), table2, "And ");
#line hidden
#line 22
    testRunner.Then("all the \"8\" appliances list should be displayed in the table below.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Home Appliances For Scotland")]
        public virtual void HomeAppliancesForScotland()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Home Appliances For Scotland", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 25
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 26
  testRunner.Given("I am on Compare how much electrical appliances cost to use screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 27
  testRunner.When("I select country as \"Scotland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Appliance",
                            "Hours",
                            "Minutes",
                            "KWH"});
                table3.AddRow(new string[] {
                            "Air Friyer",
                            "1",
                            "10",
                            "34"});
                table3.AddRow(new string[] {
                            "Dishwasher",
                            "0",
                            "30",
                            ""});
                table3.AddRow(new string[] {
                            "Fan heater",
                            "1",
                            "30",
                            ""});
                table3.AddRow(new string[] {
                            "Iron",
                            "1",
                            "00",
                            ""});
                table3.AddRow(new string[] {
                            "Oven",
                            "1",
                            "30",
                            ""});
                table3.AddRow(new string[] {
                            "TV",
                            "2",
                            "10",
                            ""});
                table3.AddRow(new string[] {
                            "Towel rail",
                            "1",
                            "10",
                            ""});
                table3.AddRow(new string[] {
                            "Toaster",
                            "1",
                            "10",
                            ""});
#line 28
  testRunner.And("I enter the below list of appliances and click on Add appliance to your list", ((string)(null)), table3, "And ");
#line hidden
#line 38
  testRunner.Then("all the \"8\" appliances list should be displayed in the table below.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion