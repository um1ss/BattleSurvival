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
            _instance = await handle.ToUniTask();
            GameObject.DontDestroyOnLoad(_instance);
        }
    }
}
