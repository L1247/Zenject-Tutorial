#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Decorate.Scripts
{
    public class DecorateExampleInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<IEnemyStats>().To<OrcStats>().AsSingle();
            Container.Decorate<IEnemyStats>().With<WeaponUpgradeEnemyDecorator>();
            Container.Bind<Player>().AsSingle().NonLazy();
        }

    #endregion
    }

    public class Player
    {
    #region Constructor

        public Player(IEnemyStats enemyStats)
        {
            Debug.Log($"{enemyStats.Damage}");
        }

    #endregion
    }

    public class WeaponUpgradeEnemyDecorator : IEnemyStats
    {
    #region Public Variables

        public float Damage => _stats.Damage + 2;

        public float Health => _stats.Health;

    #endregion

    #region Private Variables

        private readonly IEnemyStats _stats;

    #endregion

    #region Constructor

        public WeaponUpgradeEnemyDecorator(IEnemyStats stats)
        {
            _stats = stats;
        }

    #endregion
    }

    public interface IEnemyStats
    {
    #region Public Variables

        float Damage { get; }

        float Health { get; }

    #endregion
    }

    public class OrcStats : IEnemyStats
    {
    #region Public Variables

        public float Damage => 1;

        public float Health => 50;

    #endregion
    }

    public class DemonStats : IEnemyStats
    {
    #region Public Variables

        public float Damage => 7;

        public float Health => 20;

    #endregion
    }
}