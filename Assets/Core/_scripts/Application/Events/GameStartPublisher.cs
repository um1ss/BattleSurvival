using DenisKim.Core.Domain;

namespace DenisKim.Core.Application
{
    public class GameStartPublisher : BasePublisher
    {
        public GameStartPublisher()
        {
        }
        public override void NotifyListener()
        {
            foreach (IListener listener in _listeners)
            {
                listener.OnNotify();
            }
        }
    }
}