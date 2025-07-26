using VContainer;
using VContainer.Unity;
using DenisKim.Core.Application;
using DenisKim.Core.Domain;

namespace DenisKim.Core
{
    public sealed class MainMenuSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IUIService, UIService>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MainMenuEntryPoint>();
        }
    }
}

