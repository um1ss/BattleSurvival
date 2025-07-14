using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using DenisKim.Core.Application;

sealed public class MainMenuEntryPoint : IStartable
{
    readonly IViewModel _mainMenuViewModel;
    public MainMenuEntryPoint(MainMenuViewModel mainMenuViewModel)
    {
        _mainMenuViewModel = mainMenuViewModel;
    }

    public void Start()
    {
    }
}
