using DenisKim.Core.Application;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public sealed class LobbyPanelLifetimeScope : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<LobbyViewModel>(Lifetime.Scoped);
        }
    }
}
