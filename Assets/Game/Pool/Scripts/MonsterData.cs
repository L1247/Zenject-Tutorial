namespace Game.Pool.Scripts
{
    public class MonsterData
    {
    #region Public Variables

        public int Type { get; private set; }

    #endregion

    #region Constructor

        public MonsterData() { }

        public MonsterData(int type)
        {
            Type = type;
        }

    #endregion

    #region Public Methods

        public void CloneFromThis(MonsterData monsterData)
        {
            Type = monsterData.Type;
        }

    #endregion
    }
}