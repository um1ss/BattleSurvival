using DenisKim.Core.Domain;
using DenisKim.Core.Infrastructure;
using VContainer;
using VContainer.Unity;

sealed public class MainMenuEntryPoint : IStartable
{
    #region Services
    readonly IUIService _uiService;
    #endregion

    [Inject]
    public MainMenuEntryPoint(DontDestroyAssetLoadingStrategy dontDestroyAssetLoadingStrategy, IUIService uiService)
    {
        _uiService = uiService;
    }

    public void Start()
    {

    }
}
