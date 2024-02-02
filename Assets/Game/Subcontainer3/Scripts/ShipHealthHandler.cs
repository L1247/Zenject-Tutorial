#region

using UnityEngine;

#endregion

namespace Game.Subcontainer3.Scripts
{
    public class ShipHealthHandler : MonoBehaviour
    {
    #region Private Variables

        private float _health = 100;

    #endregion

    #region Public Methods

        public void OnGUI()
        {
            GUI.Label(new Rect(Screen.width / 2 , Screen.height / 2 , 200 , 100) , "Health: " + _health);
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
        }

    #endregion
    }
}