#region

using Zenject;

#endregion

namespace Game.Subcontainer.Scritps
{
    public class GameController : IInitializable
    {
    #region Private Variables

        [Inject]
        private EnemyFacade.Factory factory;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            factory.Create();
            factory.Create();
        }

    #endregion
    }
}