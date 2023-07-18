using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] private int health;

        public void TakeDamage(int number)
        {
            health -= number;
            if (health <= 0)
            {
                ChopDown();
            }
        }

        private void ChopDown()
        {
            gameObject.SetActive(false);
        }
    }
}