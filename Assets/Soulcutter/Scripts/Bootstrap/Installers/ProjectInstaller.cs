using UnityEngine;
using Zenject;

namespace Soulcutter.Scripts.Bootstrap.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
    }
}
