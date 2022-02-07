using ATFramework.Config;
using ATFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATFramework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the page");
        }
    }
}
