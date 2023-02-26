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
            var monsterType   = 1;
            var monster       = new GameObject().AddComponent<Monster>();
            var fsmProvider   = Substitute.For<IFSMProvider>();
            var state1        = new State1(new MonsterData());
            var stateMachine1 = new StateMachine1(state1);
            fsmProvider.GetFsm(monsterType).Returns(stateMachine1);
            monster.Construct(new MonsterNameProvider() , fsmProvider , new MonsterData());
            monster.Init(monsterType);
            Assert.AreEqual(true , monster.HasState(nameof(state1)));
        }

        [Test]
        public void CreateMonsterType2()
        {
            var monsterType   = 2;
            var fsmProvider   = Substitute.For<IFSMProvider>();
            var monster       = new GameObject().AddComponent<Monster>();
            var state1        = new State1(new MonsterData());
            var state2        = new State2(new MonsterData());
            var stateMachine2 = new StateMachine2(state1 , state2);
            fsmProvider.GetFsm(monsterType).Returns(stateMachine2);
            monster.Construct(new MonsterNameProvider() , fsmProvider , new MonsterData());
            monster.Init(monsterType);
            Assert.AreEqual(true , monster.HasState(nameof(state1) + nameof(state2)));
        }

    #endregion
    }
}