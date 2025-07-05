using VContainer;
using VContainer.Unity;
using DenisKim.Application;
using DenisKim.Presentation;
using UnityEngine;

sealed public class MainMenuLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        //builder.Register<MainMenuViewModel>(Lifetime.Singleton);
        //builder.RegisterEntryPoint<MainMenuEntryPoint>(Lifetime.Singleton);
    }
}
