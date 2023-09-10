using System.Collections.Generic;
using EditorAttributes;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Bootstrap
{
    public sealed class GameMachine : MonoBehaviour
    {
        public GameState GameState { get; private set; } = GameState.Off;

        private readonly List<object> _listeners = new();

        [Inject]
        public void Initialize(IStartGameListener[] startGameListeners,
            IResumeGameListener[] resumeGameListener,
            IPauseGameListener[] pauseGameListener,
            IFinishGameListener[] finishGameListener)
        {
            
            foreach (var gameListener in startGameListeners)
            {
                _listeners.Add(gameListener);
            }
            foreach (var gameListener in resumeGameListener)
            {
                _listeners.Add(gameListener);
            }
            foreach (var gameListener in pauseGameListener)
            {
                _listeners.Add(gameListener);
            }
            foreach (var gameListener in finishGameListener)
            {
                _listeners.Add(gameListener);
            }
        }

        private void Start()
        {
            StartGame();
        }

        private void OnDisable()
        {
            FinishGame();
        }
        
        [EditorButton("Start Game")]
        public void StartGame()
        {
            if (GameState != GameState.Off)
            {
                Debug.LogWarning($"You can start game only from {GameState.Off} state!");
                return;
            }

            GameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startGameListener)
                {
                    startGameListener.OnStartGame();
                }
            }
        }
        
        [EditorButton("Pause Game")]
        public void PauseGame()
        {
            if (GameState != GameState.Play)
            {
                Debug.LogWarning($"You can pause game only from {GameState.Play} state!");
                return;
            }

            GameState = GameState.Pause;
            
            foreach (var listener in _listeners)
            {
                if (listener is IPauseGameListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
        }

        [EditorButton("Resume Game")]
        public void ResumeGame()
        {
            if (GameState != GameState.Pause)
            {
                Debug.LogWarning($"You can resume game only from {GameState.Pause} state!");
                return;
            }

            GameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                if (listener is IResumeGameListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
        }

        [EditorButton("Finish Game")]
        public void FinishGame()
        {
            if (GameState != GameState.Play)
            {
                Debug.LogWarning($"You can finish game only from {GameState.Play} state!");
                return;
            }

            GameState = GameState.Finish;
            
            foreach (var listener in _listeners)
            {
                if (listener is IFinishGameListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
        }

        public void AddListener(object listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            _listeners.Remove(listener);
        }
    }
}