using DenisKim.MVVM.Education.Model; // Пространство имен для ваших Model-хендлеров
using DenisKim.MVVM.Education.ViewModel; // Пространство имен для ваших ViewModel
using VContainer; // Основное пространство имен VContainer
using VContainer.Unity; // Пространство имен VContainer для интеграции с Unity

namespace DenisKim.MVVM.Education // Ваше корневое пространство имен
{
    sealed public class GameLifetimeScope : LifetimeScope // Класс, который определяет жизненный цикл и конфигурацию контейнера VContainer
    {
        protected override void Configure(IContainerBuilder builder) // Метод, в котором регистрируются зависимости для данного LifetimeScope
        {
            builder.Register<CharacterHealthHandler>(Lifetime.Singleton); // Регистрация CharacterHealthHandler как синглтона (один экземпляр на весь Scope). VContainer вызовет Dispose() для него.
            builder.Register<CharacterEnergyHandler>(Lifetime.Singleton); // Регистрация CharacterEnergyHandler как синглтона.
            builder.Register<CharacterHUDViewModel>(Lifetime.Singleton); // Регистрация CharacterHUDViewModel как синглтона. VContainer вызовет Dispose() для него.
        }
    }
}