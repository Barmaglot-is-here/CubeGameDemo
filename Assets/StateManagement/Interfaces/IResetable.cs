namespace StateManagement
{
    public interface IResetable : IGameStateProvider
    {
        void Reset();
    }
}