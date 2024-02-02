#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class GameInstaller_Subcontainer3 : MonoInstaller
    {
    #region Private Variables

        [SerializeField]
        private GameObject ShipPrefab;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameRunner>().AsSingle();

            Container.BindFactory<float , ShipFacade , ShipFacade.Factory>()
                     .FromSubContainerResolve()
                      // .ByNewPrefabInstaller<ShipInstaller>(ShipPrefab);
                      // .ByNewPrefabResourceInstaller<ShipInstaller>("ShipPrefab");
                     .ByNewGameObjectInstaller<ShipInstaller>();
        }

    #endregion
    }
}