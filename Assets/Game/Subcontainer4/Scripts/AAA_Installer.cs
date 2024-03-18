#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Subcontainer4.Scripts
{
    public class AAA_Installer : Installer<AAA_Installer>
    {
    #region Private Variables

        private class AAA : ITickable
        {
        #region Public Methods

            public void Tick()
            {
                Debug.Log("aaa Tick");
            }

        #endregion
        }

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AAA>().AsSingle();
        }

    #endregion
    }
}