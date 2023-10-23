using Soulcutter.Scripts.Characters;
using Soulcutter.Scripts.Detectors;
using Soulcutter.Scripts.UI;
using Soulcutter.Scripts.UI.Buttons;
using Soulcutter.Scripts.UI.Joysticks;
using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Bootstrap.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Character character;
        [SerializeField] private UISystem uiSystem;
        [Header("Detectors")]
        [SerializeField] private WoodDetector woodDetector;
        [SerializeField] private EnemyDetector enemyDetector;
        
        public override void InstallBindings()
        {
            BindUI();
            BindDetectors();
            BindCharacter();
        }

        private void BindCharacter()
        {
            Container.BindInterfacesAndSelfTo<Character>().FromInstance(character).AsSingle();
            Container.BindInterfacesAndSelfTo<MoveController>().FromNew().AsSingle();
        }

        private void BindUI()
        {
            Container.Bind<UISystem>().FromInstance(uiSystem).AsSingle();
            Container.Bind<Camera>().FromInstance(uiSystem.UICamera).AsSingle();
            Container.Bind<Joystick>().FromInstance(uiSystem.Joystick).AsSingle();
            Container.Bind<IMoveInput>().To<Joystick>().FromInstance(uiSystem.Joystick);
            Container.Bind<ActionButton>().FromInstance(uiSystem.ActionButton).AsSingle();
            Container.Bind<DeathScreen>().FromInstance(uiSystem.DeathScreen).AsSingle();
            Container.Bind<HealthBar>().FromInstance(uiSystem.HealthBar).AsSingle();
        }

        private void BindDetectors()
        {
            Container.Bind<WoodDetector>().FromInstance(woodDetector).AsSingle();
            Container.Bind<EnemyDetector>().FromInstance(enemyDetector).AsSingle();
        }
    }
}
