#region

using UnityEngine;

#endregion

namespace Zenject.SpaceFighter
{
    public enum BulletTypes
    {
        FromEnemy ,
        FromPlayer
    }

    public class Bullet : MonoBehaviour , IPoolable<float , float , BulletTypes , IMemoryPool>
    {
    #region Public Variables

        public BulletTypes Type
        {
            get
            {
                return _type;
            }
        }

        public Vector3 MoveDirection
        {
            get
            {
                return transform.right;
            }
        }

    #endregion

    #region Private Variables

        float       _startTime;
        BulletTypes _type;
        float       _speed;
        float       _lifeTime;

        IMemoryPool _pool;

        [SerializeField]
        MeshRenderer _renderer = null;

        [SerializeField]
        Material _playerMaterial = null;

        [SerializeField]
        Material _enemyMaterial = null;

    #endregion

    #region Unity events

        public void Update()
        {
            transform.position -= transform.right * _speed * Time.deltaTime;

            if (Time.realtimeSinceStartup - _startTime > _lifeTime)
            {
                _pool.Despawn(this);
            }
        }

    #endregion

    #region Public Methods

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(float speed , float lifeTime , BulletTypes type , IMemoryPool pool)
        {
            _pool     = pool;
            _type     = type;
            _speed    = speed;
            _lifeTime = lifeTime;

            _renderer.material = type == BulletTypes.FromEnemy ? _enemyMaterial : _playerMaterial;

            _startTime = Time.realtimeSinceStartup;
        }

        public void OnTriggerEnter(Collider other)
        {
            var enemyView = other.GetComponent<EnemyView>();
            if (other.TryGetComponent(out EnemyView enemy))
            {
                // do something
            }

            if (enemyView != null && _type == BulletTypes.FromPlayer)
            {
                enemyView.Facade.Die();
                _pool.Despawn(this);
            }
            else
            {
                var player = other.GetComponent<PlayerFacade>();

                if (player != null && _type == BulletTypes.FromEnemy)
                {
                    player.TakeDamage(MoveDirection);
                    _pool.Despawn(this);
                }
            }
        }

    #endregion

    #region Nested Types

        public class Factory : PlaceholderFactory<float , float , BulletTypes , Bullet> { }

    #endregion
    }
}