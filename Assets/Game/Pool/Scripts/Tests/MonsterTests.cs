#region

using NUnit.Framework;
using UnityEngine;

#endregion

namespace Game.Pool.Scripts.Tests
{
    public class MonsterTests
    {
    #region Test Methods

        [Test]
        public void CreateMonsterType1()
        {
            var monster = new GameObject().AddComponent<Monster>();
            monster.Construct(new MonsterNameProvider() , new StateMachineProviderFactory() , new MonsterData());
            monster.Init(1);
        }

    #endregion
    }
}