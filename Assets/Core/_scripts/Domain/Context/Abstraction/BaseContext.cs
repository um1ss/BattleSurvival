using DenisKim.Core.Insfrastructure;

namespace DenisKim.Core.Domain
{
    public abstract class BaseContext : IContext
    {
        public abstract void ChangeBehavior(IBehavior newBehavior);
    }
}
