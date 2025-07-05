using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace DenisKim.Insfrastructure
{
    public class AbstractLSceneLoader : ISceneLoader
    {
        public virtual async UniTask LoadSceneAsync(LifetimeScope rootLifetimeScope, string sceneName)
        {
            using (LifetimeScope.EnqueueParent(rootLifetimeScope))
            {
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }
    }
}
