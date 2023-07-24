using Soulcutter.Scripts.TreeChopping.Animators;
using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] private int health;
        public WoodAnimator WoodAnimator { get; private set; }

        public void Start()
        {
            var animator = GetComponent<Animator>();
            WoodAnimator = new WoodAnimator(animator);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                ChopDown();
            }
        }

        private void ChopDown()
        {
            WoodAnimator.SetFallingAnimation();
        }
    }
}