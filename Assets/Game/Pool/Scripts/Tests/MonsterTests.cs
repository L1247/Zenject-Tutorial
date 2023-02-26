#region

using NSubstitute;
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
            var monster     = new GameObject().AddComponent<Monster>();
            var fsmProvider = Substitute.For<IFSMProvider>();
            monster.Construct(new MonsterNameProvider() , fsmProvider , new MonsterData());
            monster.Init(1);
        }

    #endregion
    }
}