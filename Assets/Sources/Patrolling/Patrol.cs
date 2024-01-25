using System;
using Assets.Sources.Extensions;
using UnityEngine;

namespace Assets.Sources.Patrolling
{
    [RequireComponent(typeof(Rigidbody))]
    public class Patrol : MonoBehaviour
    {
        #region Constants

        private const double WaypointChangeDistance = 0.01;

        #endregion Constants

        #region Fields

        [SerializeField] private WayPoint[] _wayPoints;
        [SerializeField, Range(0, 50)] private float _movementSpeed = 1;

        private Rigidbody _rigidbody;
        private int _wayPointIndex = 0;

        #endregion Fields

        #region Properties

        private bool HasPatrolWay => _wayPoints.Length > 0;

        #endregion Properties

        #region Unity Events
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            UpdatePath();
            ResetSpeed();
            UpdateSpeed();
        }

        #endregion Unity Events

        #region Movement

        private void UpdatePath()
        {
            var destinationPoint = GetDestinationPoint();

            if (!destinationPoint.HasValue)
            {
                return;
            }

            if (transform.position.Distance(destinationPoint.Value) < WaypointChangeDistance)
            {
                IncrementWayPointIndex();
            }
        }

        private void ResetSpeed()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        private void UpdateSpeed()
        {
            var destinationPoint = GetDestinationPoint();
            if (!destinationPoint.HasValue)
            {
                return;
            }

            var position = transform.position;
            var direction = position.GetDirection(destinationPoint.Value);
            var distance = _movementSpeed * Time.deltaTime;

            _rigidbody.AddForce(direction * distance, ForceMode.VelocityChange);
        }

        private Vector3? GetDestinationPoint()
        {
            return HasPatrolWay ?
                _wayPoints[_wayPointIndex].Position :
                null;
        }

        private void IncrementWayPointIndex()
        {
            _wayPointIndex++;

            if (_wayPointIndex >= _wayPoints.Length)
            {
                _wayPointIndex = 0;
            }
        }

        #endregion Movement
    }
}
