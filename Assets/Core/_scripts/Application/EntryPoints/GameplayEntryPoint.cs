using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Core
{
    public sealed class GameplayEntryPoint : IStartable
    {
        #region Services
        readonly IUIService _uIService;
        #endregion

        [Inject]
        public GameplayEntryPoint(IUIService uIService)
        {
            _uIService = uIService;
        }

        public void Start()
        {
            //_uIService.ShowPersistentPanel(PanelsEnum.Lobby, "GameplayPanel");
        }
    }
}
