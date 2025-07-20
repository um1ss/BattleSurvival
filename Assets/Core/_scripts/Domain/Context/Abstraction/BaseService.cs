using DenisKim.Core.Infrastructure;

namespace DenisKim.Core.Domain
{
    public abstract class BaseService : IService
    {
        protected BaseService(IStrategy newStrategy)
        {
            ChangeBehavior(newStrategy);
        }
        public abstract void ChangeBehavior(IStrategy newStrategy);
    }
}