namespace StateManagement
{
    public interface IPlayable : IGameStateProvider
    {
        void Play();
    }
}