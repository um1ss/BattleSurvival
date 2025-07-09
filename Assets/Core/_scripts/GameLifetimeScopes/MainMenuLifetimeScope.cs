using VContainer;
using VContainer.Unity;
using DenisKim.Core.Application;
using DenisKim.Core.Presentation;
using UnityEngine;

sealed public class MainMenuLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //builder.Register<MainMenuViewModel>(Lifetime.Singleton);
        //builder.RegisterEntryPoint<MainMenuEntryPoint>(Lifetime.Singleton);
    }
}
