using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Bootstrap
{
    public sealed class GameMachine : MonoBehaviour
    {
        public GameState GameState => _gameState;

        private List<IStartGameListener> _listeners;
        private GameState _gameState = GameState.Off;

        [Inject]
        public void Initialize(IStartGameListener[] startGameListeners)
        {
            _listeners = startGameListeners.ToList();
            Debug.Log(_listeners.Count);
        }

        private void Start()
        {
            StartGame();
        }

        private void OnDisable()
        {
            FinishGame();
        }

        [ContextMenu("Start Game")]
        private void StartGame()
        {
            if (_gameState != GameState.Off)
            {
                Debug.LogWarning($"You can start game only from {GameState.Off} state!");
                return;
            }

            _gameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                if (listener is IStartGameListener startGameListener)
                {
                    startGameListener.OnStartGame();
                }
            }
        }
        
        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            if (_gameState != GameState.Play)
            {
                Debug.LogWarning($"You can pause game only from {GameState.Play} state!");
                return;
            }

            _gameState = GameState.Pause;
            
            foreach (var listener in _listeners)
            {
                if (listener is IPauseGameListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (_gameState != GameState.Pause)
            {
                Debug.LogWarning($"You can resume game only from {GameState.Pause} state!");
                return;
            }

            _gameState = GameState.Play;
            
            foreach (var listener in _listeners)
            {
                if (listener is IResumeGameListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (_gameState != GameState.Play)
            {
                Debug.LogWarning($"You can finish game only from {GameState.Play} state!");
                return;
            }

            _gameState = GameState.Finish;
            
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
            //_listeners.Add(listener);
        }

        public void RemoveListener(object listener)
        {
            //_listeners.Remove(listener);
        }
    }
}