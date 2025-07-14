using DenisKim.Core.Insfrastructure;

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