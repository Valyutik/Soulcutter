using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Detectors;

namespace Soulcutter.Scripts.Combat
{
    public class Attacker
    {
        private readonly int _damage;
        private readonly CharacterActionActivator _characterActionActivator;
        private readonly EnemyDetector _detector;

        public Attacker(EnemyDetector detector, CharacterActionActivator characterActionActivator, int damage)
        {
            _characterActionActivator = characterActionActivator;
            _detector = detector;
            _damage = damage;
            
            _characterActionActivator.OnActivatedCombatAttackEvent += Attack;
        }

        public void Deconstruct()
        {
            _characterActionActivator.OnActivatedCombatAttackEvent -= Attack;
        }
        
        private void Attack()
        {
            if (_detector.CurrentEnemy != null) _detector.CurrentEnemy.TakeDamage(_damage);
        }
    }
}