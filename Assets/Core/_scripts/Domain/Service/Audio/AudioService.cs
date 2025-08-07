using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace DenisKim.Core.Domain
{
    public sealed class AudioService : IAudioService
    {
        GameObject _backgorundMusicAudioSource;

        public async UniTask CreateAudioSource(string address)
        {
            var handle = Addressables.InstantiateAsync(address);
            await handle.ToUniTask();
            _backgorundMusicAudioSource = handle.Result;
            GameObject.DontDestroyOnLoad(_backgorundMusicAudioSource);
        }

        public void SetVolume(int value)
        {

        }
    }
}
