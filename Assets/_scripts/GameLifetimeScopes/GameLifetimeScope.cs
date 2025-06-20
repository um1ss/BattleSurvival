using VContainer;
using VContainer.Unity;

sealed public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<MainMenuEntryPoint>();
    }
}
