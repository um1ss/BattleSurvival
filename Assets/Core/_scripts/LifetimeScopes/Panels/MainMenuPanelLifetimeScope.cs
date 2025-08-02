using DenisKim.Core.Application;
using DenisKim.Core.Domain;
using VContainer;
using VContainer.Unity;

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