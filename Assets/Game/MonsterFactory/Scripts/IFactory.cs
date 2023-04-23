#region

using Zenject;

#endregion

namespace Game.MonsterFactory.Scripts
{
    public interface IEnemyFactory : IFactory<IEnemy> { }

    public interface IDogFactory : IFactory<Dog> { }
}