namespace Soulcutter.Scripts.Bootstrap
{
    public interface IGameStateListener
    {
        void OnStartGame() { }

        void OnPauseGame() { }

        void OnResumeGame() { }

        void OnFinishGame() { }
    }
}