using Cysharp.Threading.Tasks;
using DenisKim.Core.Domain;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace DenisKim.Core.Domain
{
    public sealed class SceneTransitionService : ISceneTransitionService
    {
        LifetimeScope _rootLifetimeScope;

        public SceneTransitionService(LifetimeScope rootLifetimeScope)
        {
            _rootLifetimeScope = rootLifetimeScope;
            if (_rootLifetimeScope != null)
            {
                Debug.Log($"SceneTransitionService: _rootLifetimeScope is NOT NULL. Its GameObject name is: {_rootLifetimeScope.name}");
            }
            else
            {
                Debug.LogError("SceneTransitionService: _rootLifetimeScope is NULL! This indicates a VContainer registration issue.");
            }
        }

        public async UniTask LoadSceneAsync(SceneIndex sceneID)
        {
            Debug.Log($"SceneTransitionService: Attempting to load scene with ID: {sceneID.ToString()}");
            if (_rootLifetimeScope == null)
            {
                Debug.LogError("SceneTransitionService: Cannot load scene, _rootLifetimeScope is NULL!");
                return;
            }
            using (LifetimeScope.EnqueueParent(_rootLifetimeScope))
            {
                await SceneManager.LoadSceneAsync((int)sceneID, LoadSceneMode.Single);
                Debug.Log($"SceneTransitionService: Scene {sceneID.ToString()} loaded successfully.");
            }
        }
    }
}
