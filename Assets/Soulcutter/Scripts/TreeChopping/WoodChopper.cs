using UnityEngine;

namespace Soulcutter.Scripts.TreeChopping
{
    public class WoodChopper : MonoBehaviour
    {
        [SerializeField] private int impactForce;

        public void Initialize()
        {
        }

        private void ChopWood(Wood wood)
        {
            wood.TakeHit(impactForce);
        }
    }
}