using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        [SerializeField] private int numberHits;

        public void TakeHit(int number)
        {
            numberHits -= number;
            if (numberHits <= 0)
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