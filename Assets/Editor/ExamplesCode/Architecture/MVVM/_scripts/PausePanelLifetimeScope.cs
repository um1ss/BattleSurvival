using VContainer;
using VContainer.Unity;

namespace DenisKim.MVVM.Education
{
    public class PausePanelLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // –егистрируем PauseViewModel как Scoped или Transient
            // Scoped: один экземпл€р на дочерний LifetimeScope.
            // Transient: новый экземпл€р каждый раз, когда запрашиваетс€.
            // ƒл€ ViewModel UI-панели обычно подходит Scoped.
            builder.Register<CharacterHUDViewModel>(Lifetime.Scoped).AsImplementedInterfaces();
            // VContainer автоматически найдет PauseView на этом же GameObject и инжектирует PauseViewModel в него.
        }
    }
}