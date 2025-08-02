using DenisKim.Core.Application;
using DenisKim.Core.Domain;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public sealed class MainMenuSceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuEntryPoint>();
        }
    }
}

