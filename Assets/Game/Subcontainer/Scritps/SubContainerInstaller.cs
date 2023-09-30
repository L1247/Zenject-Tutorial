#region

using Zenject;

#endregion

namespace Game.Subcontainer.Scritps
{
    public class SubContainerInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameController>().AsSingle();
            Container.BindFactory<EnemyFacade , EnemyFacade.Factory>()
                     .FromSubContainerResolve()
                     .ByNewPrefabResourceInstaller<EnemyInstaller>("Enemy");
        }

    #endregion
    }
}