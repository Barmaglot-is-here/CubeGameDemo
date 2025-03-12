namespace StateManagement
{
    public interface IPausable : IGameStateProvider
    {
        void Pause();
        void Play();
    }
}