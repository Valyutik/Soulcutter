using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Detectors;

namespace Soulcutter.Scripts.Combat
{
    public class CharacterAttacker
    {
        private readonly int _damage;
        private readonly int _specialDamage;
        private readonly CharacterActionActivator _characterActionActivator;
        private readonly EnemyDetector _detector;
        private readonly Combo _combo;

        public CharacterAttacker(EnemyDetector detector, CharacterActionActivator characterActionActivator,
            int damage, int specialDamage, int pointComboThreshold, float comboResetTime)
        {
            _characterActionActivator = characterActionActivator;
            _detector = detector;
            _damage = damage;
            _specialDamage = specialDamage;

            _combo = new Combo(pointComboThreshold, comboResetTime);
            
            _characterActionActivator.OnActivatedAttackEvent += OnAttack;
            _characterActionActivator.OnActivatedSpecialAttackEvent += OnSpecialAttack;
            _combo.OnActivatedSpecialAttackEvent += _characterActionActivator.OnActivatedSpecialAttack;
        }

        public void Deconstruct()
        {
            _combo.Deconstruct();
            
            _characterActionActivator.OnActivatedAttackEvent -= OnAttack;
            _characterActionActivator.OnActivatedSpecialAttackEvent -= OnSpecialAttack;
            _combo.OnActivatedSpecialAttackEvent -= _characterActionActivator.OnActivatedSpecialAttack;
        }
        
        private void OnAttack()
        {
            if (_detector.CurrentEnemy == null) return;
            _detector.CurrentEnemy.TakeDamage(_damage);
            _combo.AddComboPoint();
        }
        
        private void OnSpecialAttack()
        {
            if (_detector.CurrentEnemy != null) _detector.CurrentEnemy.TakeDamage(_specialDamage);
        }
    }
}