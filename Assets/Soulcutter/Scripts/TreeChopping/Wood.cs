using Soulcutter.Scripts.TreeChopping.Animators;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] private int health;
        public bool isFallen { get; private set; }
        public WoodAnimator WoodAnimator { get; private set; }

        public void Start()
        {
            isFallen = false;
            var animator = GetComponent<Animator>();
            WoodAnimator = new WoodAnimator(animator);
        }

        public void TakeDamage(int damage)
        {
            if (isFallen) return;
            
            health -= damage;
                
            if (health <= 0)
            {
                ChopDown();
            }
        }

        private void ChopDown()
        {
            isFallen = true;
            
            WoodAnimator.SetFallingAnimation();
        }
    }
}