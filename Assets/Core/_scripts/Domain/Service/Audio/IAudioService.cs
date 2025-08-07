using Cysharp.Threading.Tasks;

namespace DenisKim.Core.Domain
{
    public interface IAudioService
    {
        UniTask CreateAudioSource(string address);

        void SetVolume(int value);
    }
}
