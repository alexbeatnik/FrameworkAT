using ATFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATesting
{
    public class HookInitialize : TestInitializeHooks
    {
        public HookInitialize() : base(BrowserType.Firefox)
        {
            InitializeSettings();
            NavigateSite();
        }
    }
}
