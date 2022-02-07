using ATFramework.Base;
using TechTalk.SpecFlow;

namespace ATesting
{
    [Binding]
    public class HookInitialize : TestInitializeHooks
    {
        public HookInitialize() : base(BrowserType.Firefox)
        {
            InitializeSettings();
            NavigateSite();
        }

        [BeforeFeature]
        public static void TestStart()
        {
            HookInitialize init = new HookInitialize();
        }
    }
}
