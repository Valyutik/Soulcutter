using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Soulcutter.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthLine;
        private float _fullHealth;

        public void Initialize()
        {
            
        }

        public void GetFullHealth(float fullHealth)
        {
            _fullHealth = fullHealth;
        }
        
        public void ChangeHealthLine(float health)
        {
            healthLine.fillAmount = health / _fullHealth;
        }
    }
}