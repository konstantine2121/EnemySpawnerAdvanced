using Assets.Sources.Extensions;
using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        #region Fields

        [SerializeField, Range(0, 200)] private float _movementSpeed = 0.5f;

        private IPositionProvider _target;
        private Rigidbody _rigidbody;

        #endregion Fields

        #region Unity Events

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            ResetSpeed();
            UpdateSpeed();
        }

        #endregion Unity Events

        #region IEnemy Implementation

        public void SetTarget(IPositionProvider target)
        {
            _target = target;
        }

        #endregion IEnemy Implementation

        #region Movement

        private void ResetSpeed()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        private void UpdateSpeed()
        {
            if (_target == null)
            {
                return;
            }

            var position = transform.position;
            var targetPosition = _target.Position;
            var direction = position.GetDirection(targetPosition);
            var distance = _movementSpeed * Time.deltaTime;

            _rigidbody.AddForce(direction * distance, ForceMode.VelocityChange);
        }

        #endregion Movement
    }
}