using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Detectors;

namespace Soulcutter.Scripts.Combat
{
    public class CharacterAttacker
    {
        private readonly int _damage;
        private readonly CharacterActionActivator _characterActionActivator;
        private readonly EnemyDetector _detector;

        public CharacterAttacker(EnemyDetector detector, CharacterActionActivator characterActionActivator, int damage)
        {
            _characterActionActivator = characterActionActivator;
            _detector = detector;
            _damage = damage;
            
            _characterActionActivator.OnActivatedCombatAttackEvent += OnAttack;
        }

        public void Deconstruct()
        {
            _characterActionActivator.OnActivatedCombatAttackEvent -= OnAttack;
        }
        
        private void OnAttack()
        {
            if (_detector.CurrentEnemy != null) _detector.CurrentEnemy.TakeDamage(_damage);
        }
    }
}