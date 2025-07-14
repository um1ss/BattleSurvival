using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public abstract class BaseContext : IContext
    {
        protected BaseContext(IBehavior newBehavior)
        {
            ChangeBehavior(newBehavior);
        }
        public abstract void ChangeBehavior(IBehavior newBehavior);
    }
}