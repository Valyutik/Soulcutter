using System;
using System.Threading.Tasks;

namespace Soulcutter.Scripts.Combat
{
    public class Combo
    {
        public event Action OnActivatedSpecialAttackEvent;
        
        private readonly int _pointComboThreshold;
        private readonly float _comboResetTime;
        private int _currentComboPoint;
        private bool _isTimerEnabled;

        public Combo(int pointComboThreshold, float comboResetTime)
        {
            _pointComboThreshold = pointComboThreshold;
            _comboResetTime = comboResetTime;
        }

        public void AddComboPoint()
        {
            _currentComboPoint++;
            CheckComboPointThreshold();
            ComboResetTimer();
        }

        private void CheckComboPointThreshold()
        {
            if (_currentComboPoint < _pointComboThreshold) return;
            OnActivatedSpecialAttackEvent?.Invoke();
            _currentComboPoint = 0;
        }

        private async void ComboResetTimer()
        {
            if (_isTimerEnabled) return;
            _isTimerEnabled = true;
            await Task.Delay(Convert.ToInt32(_comboResetTime * 1000));
            _currentComboPoint = 0;
            _isTimerEnabled = false;
        }
    }
}