using VContainer;
using VContainer.Unity;
using DenisKim.Core.Application;

namespace DenisKim.Core
{
    public sealed class MainMenuPanelLifetimeScope : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<MainMenuViewModel>(Lifetime.Scoped);
        }
    }
}