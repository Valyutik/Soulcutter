using System;
using Soulcutter.Scripts.Detectors;
using Task = System.Threading.Tasks.Task;

namespace Soulcutter.Scripts.Combat.Enemies
{
    public class EnemyAttacker
    {
        private readonly int _damage;
        private readonly float _attackTime;
        private readonly float _attackDelay;
        private readonly CharacterDetector _characterDetector;
        private readonly EnemyAnimator _enemyAnimator;
        private readonly EnemyMovement _enemyMovement;
        private bool _isAttacking;

        public EnemyAttacker(float attackTime, float attackDelay, int damage,
            EnemyAnimator enemyAnimator, EnemyMovement enemyMovement, CharacterDetector characterDetector)
        {
            _damage = damage;
            _attackTime = attackTime;
            _attackDelay = attackDelay;
            _enemyAnimator = enemyAnimator;
            _enemyMovement = enemyMovement;
            _characterDetector = characterDetector;
        }

        public async void OnAttack()
        {
            if (_isAttacking) return;
            var attackTime = Convert.ToInt32(_attackTime * 1000);
            var attackDelay = Convert.ToInt32(_attackDelay * 1000);
            _isAttacking = true;
            
            _enemyAnimator.SetAttackAnimation(_attackTime);
            _enemyMovement.DisableMovement();
            
            await Task.Delay(attackTime / 2);
            if (_characterDetector.Character != null)
            {
                _characterDetector.Character.TakeDamage(_damage);
            }
            
            await Task.Delay(attackTime / 2);
            _enemyMovement.EnableMovement();
            
            await Task.Delay(attackDelay);
            _isAttacking = false;
        }
    }
}