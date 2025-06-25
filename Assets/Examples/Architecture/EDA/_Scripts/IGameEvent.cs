using System.Collections.Generic;

public interface IGameEvent<T>
{
    public void Raise(T value);

    public void RegisterListener(GameEventListener<T> gameEventListener);

    public void UnregisterListener(GameEventListener<T> listener);
}
