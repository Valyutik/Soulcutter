using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.InteractionObjectDetectors;
using UnityEngine;

namespace Soulcutter.Scripts.Combat
{
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        private CharacterActionActivator _characterActionActivator;

        public void Initialize(InteractionObjectDetector detector, CharacterActionActivator characterActionActivator)
        {
            _characterActionActivator = characterActionActivator;
            
            _characterActionActivator.OnActivatedCombatAttackEvent += OnAttack;
        }

        private void OnDisable()
        {
            _characterActionActivator.OnActivatedCombatAttackEvent -= OnAttack;
        }

        private void OnAttack()
        {
            
        }
    }
}