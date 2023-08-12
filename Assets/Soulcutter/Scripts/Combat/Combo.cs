using System;
using Soulcutter.Scripts.Services;

namespace Soulcutter.Scripts.Combat
{
    public class Combo
    {
        public event Action OnActivatedSpecialAttackEvent;

        private readonly SyncedTimer _syncedTimer;
        private readonly int _pointComboThreshold;
        private readonly float _comboResetTime;
        private int _currentComboPoint;
        private bool _isTimerEnabled;

        public Combo(int pointComboThreshold, float comboResetTime)
        {
            _pointComboThreshold = pointComboThreshold;
            _comboResetTime = comboResetTime;
            _syncedTimer = new SyncedTimer(TimerType.UpdateTick, _comboResetTime);
            _syncedTimer.TimerFinished += ComboPointReset;
        }

        public void Deconstruct()
        {
            _syncedTimer.TimerFinished -= ComboPointReset;
        }

        public void AddComboPoint()
        {
            _currentComboPoint++;
            _syncedTimer.Start(_comboResetTime);
            CheckComboPointThreshold();
        }

        private void CheckComboPointThreshold()
        {
            if (_currentComboPoint < _pointComboThreshold) return;
            OnActivatedSpecialAttackEvent?.Invoke();
            _currentComboPoint = 0;
        }

        private void ComboPointReset()
        {
            _currentComboPoint = 0;
        }
    }
}