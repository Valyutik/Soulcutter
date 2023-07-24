using Soulcutter.Scripts.TreeChopping.Animators;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] private int health;
        public bool IsFallen { get; private set; }
        private WoodAnimator WoodAnimator { get; set; }

        public void Start()
        {
            IsFallen = false;
            var animator = GetComponent<Animator>();
            WoodAnimator = new WoodAnimator(animator);
        }

        public void TakeDamage(int damage)
        {
            if (IsFallen) return;
            health -= damage;
            WoodAnimator.SetHitAnimation();
            if (health <= 0)
                ChopDown();
        }

        private void ChopDown()
        {
            IsFallen = true;
            WoodAnimator.SetFallingAnimation();
        }
    }
}