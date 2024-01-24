using Assets.Sources.Extensions;
using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        [SerializeField][Range(0, 200)] private float _movementSpeed = 0.5f;

        private IPositionProvider _target;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetTarget(IPositionProvider target)
        {
            _target = target;
        }

        private void FixedUpdate()
        {
            ResetSpeed();
            UpdateSpeed();
        }

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

            var distance = Mathf.Min(
                position.Distance(targetPosition),
                _movementSpeed * Time.deltaTime);

            _rigidbody.AddForce(direction * distance, ForceMode.VelocityChange);
        }
    }
}