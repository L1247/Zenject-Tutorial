namespace Game.Pool.Scripts
{
    public class MonsterNameProvider
    {
    #region Public Methods

        public string GetName(int monsterType)
        {
            var name = monsterType switch
            {
                1 => "Monster_1" , 2 => "Monster_2" , 3 => "Monster_3" , _ => "NoName"
            };

            return name;
        }

    #endregion
    }
}