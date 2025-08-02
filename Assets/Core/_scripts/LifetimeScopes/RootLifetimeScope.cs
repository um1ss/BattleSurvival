using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core.LifetimScope
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ShowPersistentPanelStrategy>(Lifetime.Singleton);
            builder.Register<ShowOnDemandLoadingPanelStrategy>(Lifetime.Singleton);

            builder.Register<HardCurrencyService>(Lifetime.Singleton).WithParameter(99);
            builder.Register<SoftCurrencyService>(Lifetime.Singleton).WithParameter(472398476);

            builder.Register<IEventSystemService, EventSystemService>(Lifetime.Singleton);
            builder.Register<ICanvasService, CanvasService>(Lifetime.Singleton);
            builder.Register<ICameraService, CameraService>(Lifetime.Singleton);
            builder.Register<IUIService, UIService>(Lifetime.Singleton);
            builder.Register<ISceneTransitionService, SceneTransitionService>(Lifetime.Singleton);

            builder.RegisterEntryPoint<BootstrapEntryPoint>(Lifetime.Singleton);
        }
    }
}
