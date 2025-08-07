using VContainer;
using VContainer.Unity;

namespace DenisKim.MVVM.Education
{
    public class PausePanelLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // ������������ PauseViewModel ��� Scoped ��� Transient
            // Scoped: ���� ��������� �� �������� LifetimeScope.
            // Transient: ����� ��������� ������ ���, ����� �������������.
            // ��� ViewModel UI-������ ������ �������� Scoped.
            builder.Register<CharacterHUDViewModel>(Lifetime.Scoped).AsImplementedInterfaces();
            // VContainer ������������� ������ PauseView �� ���� �� GameObject � ����������� PauseViewModel � ����.
        }
    }
}