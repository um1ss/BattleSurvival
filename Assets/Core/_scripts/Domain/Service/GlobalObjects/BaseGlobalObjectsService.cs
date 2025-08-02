using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DenisKim.Core.Domain
{
    public abstract class BaseGlobalObjectsService : IGlobalObjectsService
    {
        protected GameObject _instance;
        public virtual async UniTask CreateInstance(string address)
        {
            var handle = Addressables.InstantiateAsync(address);
            await handle.ToUniTask();
            _instance = handle.Result;
            GameObject.DontDestroyOnLoad(_instance);
        }
    }
}
