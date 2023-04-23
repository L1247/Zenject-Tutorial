#region

using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public class EnemyFactory : PlaceholderFactory<IEnemy> , IEnemyFactory { }
}