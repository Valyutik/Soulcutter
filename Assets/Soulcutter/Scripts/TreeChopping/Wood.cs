using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class Wood : MonoBehaviour
    {
        private int _numberHits;

        public void TakeHit(int numberHits)
        {
            _numberHits -= numberHits;
            if (_numberHits <= 0)
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