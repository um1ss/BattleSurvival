using DenisKim.Core.Application;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public sealed class SettingsPanelLifetimeScope : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<SettingsViewModel>(Lifetime.Scoped);
        }
    }
}
