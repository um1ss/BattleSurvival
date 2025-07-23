using VContainer;
using VContainer.Unity;

sealed public class MainMenuLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<MainMenuEntryPoint>(Lifetime.Scoped);
    }
}
