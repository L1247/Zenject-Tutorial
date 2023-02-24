#region

using Zenject;

#endregion

namespace Game.Pool.Scripts
{
    public class PoolInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameController>().AsSingle();
            Container.Bind<MonsterNameProvider>().AsSingle();
            Container.BindFactory<MonsterData , Monster , Monster.Factory>()
                     .FromPoolableMemoryPool<MonsterData , Monster , MonsterPool>(
                              poolBinder => poolBinder
                                           .WithInitialSize(2)
                                           .FromSubContainerResolve()
                                           .ByNewPrefabResourceInstaller<MonsterInstaller>("Monster")
                                           .UnderTransformGroup("Monsters"));
        }

    #endregion
    }

    internal class MonsterPool : MonoPoolableMemoryPool<MonsterData , IMemoryPool , Monster> { }
}