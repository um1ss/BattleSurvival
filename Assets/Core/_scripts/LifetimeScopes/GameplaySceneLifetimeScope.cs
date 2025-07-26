using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public sealed class GameplaySceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayEntryPoint>(Lifetime.Singleton);
        }
    }
}