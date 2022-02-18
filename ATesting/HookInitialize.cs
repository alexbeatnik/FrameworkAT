using ATFramework.Base;
using ATFramework.Config;
using ATFramework.Helpers;
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

        public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [Parallelizable(ParallelScope.Fixtures)]
        [BeforeScenario]
        public void TestStart()
        {
            InitializeSettings();
            Settings.ApplicationConnection = Settings.ApplicationConnection.DbConnection(Settings.AppConnectionString);
        }
        
        [AfterScenario]
        public void TestStop()
        {
            _parallelConfig.Driver.Quit();
        }
    }
}