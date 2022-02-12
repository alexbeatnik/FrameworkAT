using ATFramework.Base;
using ATFramework.Config;
using ATFramework.Helpers;
using TechTalk.SpecFlow;

namespace ATesting
{
    [Binding]
    public class HookInitialize : TestInitializeHooks
    {
        public HookInitialize() : base(BrowserType.Firefox)
        {
            InitializeSettings();
            Settings.ApplicationConnection = Settings.ApplicationConnection.DbConnection(Settings.AppConnectionString);
            NavigateSite();
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}