using Soulcutter.Scripts.Character;
using Soulcutter.Scripts.Detectors;

namespace Soulcutter.Scripts.TreeChopping
{
    public class WoodChopper
    {
        private readonly int _impactForce;
        private readonly WoodDetector _detector;
        private readonly CharacterActionActivator _characterActionActivator;

        public WoodChopper(WoodDetector detector, CharacterActionActivator characterActionActivator, int impactForce)
        {
            _detector = detector;
            _characterActionActivator = characterActionActivator;
            _impactForce = impactForce;
            _characterActionActivator.OnActivatedChopEvent += ChopWood;
        }

        public void Deconstruct()
        {
            _characterActionActivator.OnActivatedChopEvent -= ChopWood;
        }

        private void ChopWood()
        {
            _detector.CurrentWood.TakeDamage(_impactForce);
        }
    }
}