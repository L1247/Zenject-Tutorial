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
            Debug.Log($"DecorateExampleInstaller");
            Container.Bind<IEnemyStats>().To<OrcStats>().AsSingle();
            Container.Decorate<IEnemyStats>().With<WeaponUpgradeEnemyDecorator>();
            // Container.Bind<Player>().AsSingle().NonLazy();
            // Container.Bind<A>().AsSingle().Lazy();
            // Container.Bind<B>().AsSingle().NonLazy();
            // Container.BindInterfacesAndSelfTo<A>().AsSingle();
            // Container.BindInterfacesAndSelfTo<B>().AsSingle();
            // Container.BindExecutionOrder<B>(-1);
        }

    #endregion
    }

    public class B : IInitializable
    {
    #region Private Variables

        [Inject]
        private A a;

    #endregion

    #region Constructor

        public B( /*A a*/)
        {
            Debug.Log("我是誰:B");
            // a.Log();
        }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            a.Log();
        }

        public void Log()
        {
            Debug.Log("Log:B");
        }

    #endregion
    }

    public class A : IInitializable
    {
    #region Private Variables

        [Inject]
        private B b;

    #endregion

    #region Constructor

        public A( /*B b*/)
        {
            Debug.Log("我是誰:A");
            // b.Log();
        }

    #endregion

    #region Public Methods

        public void Initialize()
        {
            b.Log();
        }

        public void Log()
        {
            Debug.Log("Log: A");
        }

    #endregion
    }

    public class Player
    {
    #region Constructor

        public Player(IEnemyStats enemyStats)
        {
            Debug.Log($"Damage: {enemyStats.Damage}");
        }

    #endregion
    }

    public class OrcStats : IEnemyStats
    {
    #region Public Variables

        public float Damage => 1;

        public float Health => 50;

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

    public class DemonStats : IEnemyStats
    {
    #region Public Variables

        public float Damage => 7;

        public float Health => 20;

    #endregion
    }
}