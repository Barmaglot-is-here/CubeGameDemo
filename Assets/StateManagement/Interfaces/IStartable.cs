namespace StateManagement
{
    public interface IStartable : IGameStateProvider
    {
        void Start();
    }
}