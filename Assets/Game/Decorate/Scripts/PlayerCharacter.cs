using UnityEngine;
using Zenject;

namespace Game.Decorate.Scripts
{
    public class PlayerCharacter : MonoBehaviour
    {
        [Inject]
        void Constructor(IEnemyStats enemyStats)
        {
            Debug.Log($"PlayerCharacter");
            Debug.Log($"{enemyStats.Damage}");
        }
    }
}