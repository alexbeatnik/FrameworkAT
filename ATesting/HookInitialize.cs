using ATFramework.Base;
using ATFramework.Config;
using ATFramework.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ATesting
{
    [Binding]
    public class HookInitialize : TestInitializeHooks
    {
        private readonly ParallelConfig _parallelConfig;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _scenarioContext;
        private ExtentTest _currentScenarioName;

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext,
            ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }


        private static ExtentTest featureName;
        private static ExtentReports extent;
        private static KlovReporter klov;


        [AfterStep]
        public void AfterEachStep()
        {
            var stepName = _scenarioContext.StepContext.StepInfo.Text;
            var featureName = _featureContext.FeatureInfo.Title;
            var scenarioName = _scenarioContext.ScenarioInfo.Title;


            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message);
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message);
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text)
                        .Fail(_scenarioContext.TestError.Message);
            }
            else if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    _currentScenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
                else if (stepType == "When")
                    _currentScenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
                else if (stepType == "Then")
                    _currentScenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
                else if (stepType == "And")
                    _currentScenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Skip("Step Definition Pending");
            }
        }


        [Parallelizable(ParallelScope.Fixtures)]
        [BeforeScenario]
        public void TestStart()
        {
            InitializeSettings();
            Settings.ApplicationConnection = Settings.ApplicationConnection.DbConnection(Settings.AppConnectionString);
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            _currentScenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void TestInitalize()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\FrameworkAT\ATFrameworkReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            klov = new KlovReporter();
            extent.AttachReporter(htmlReporter);
        }

        [AfterScenario]
        public void TestStop()
        {
            _parallelConfig.Driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
    }
}