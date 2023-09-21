using UnityEngine;
using Zenject;

namespace Game.Decorate.Scripts
{
    public class PlayerCharacterInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log($"PlayerCharacterInstaller");
            Container.Decorate<IEnemyStats>().With<WeaponUpgradeEnemyDecorator>();

        }
    }
}