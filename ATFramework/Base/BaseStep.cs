using ATFramework.Config;
using ATFramework.Helpers;

namespace ATFramework.Base
{
    public abstract class BaseStep : Base
    {
        protected BaseStep(ParallelConfig parellelConfig) : base(parellelConfig)
        {
        }
    }
}