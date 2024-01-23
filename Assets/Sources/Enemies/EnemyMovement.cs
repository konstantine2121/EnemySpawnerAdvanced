using UnityEngine;

namespace Assets.Sources.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyMovement : MonoBehaviour, IEnemy
    {
        [SerializeField][Range(0, 200)] private float _movementSpeed = 0.5f;

        private IEntity _target;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetTarget(IEntity target)
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
            if (_target != null)
            {
                var pathToTarget = _target.Position - transform.position;
                var direction = pathToTarget.normalized;
                var distance = Mathf.Min(pathToTarget.magnitude, _movementSpeed * Time.deltaTime);

                _rigidbody.AddForce(direction * distance, ForceMode.VelocityChange);
            }
        }
    }
}