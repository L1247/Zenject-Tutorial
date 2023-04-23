#region

using UnityEngine;

#endregion

namespace Zenject.SpaceFighter
{
    public class Player
    {
    #region Public Variables

        public bool IsDead { get; set; }

        public float Health => _health;

        public MeshRenderer Renderer => _renderer;

        public Quaternion Rotation
        {
            get => _rigidBody.rotation;
            set => _rigidBody.rotation = value;
        }

        public Vector3 LookDir => -_rigidBody.transform.right;

        public Vector3 Position
        {
            get => _rigidBody.position;
            set => _rigidBody.position = value;
        }

        public Vector3 Velocity => _rigidBody.velocity;

    #endregion

    #region Private Variables

        private readonly Rigidbody    _rigidBody;
        readonly         MeshRenderer _renderer;

        float _health = 100.0f;

    #endregion

    #region Constructor

        public Player(
                Rigidbody    rigidBody ,
                MeshRenderer renderer)
        {
            _rigidBody = rigidBody;
            _renderer  = renderer;
        }

    #endregion

    #region Public Methods

        public void AddForce(Vector3 force)
        {
            _rigidBody.AddForce(force);
        }

        public void TakeDamage(float healthLoss)
        {
            _health = Mathf.Max(0.0f , _health - healthLoss);
        }

    #endregion
    }
}