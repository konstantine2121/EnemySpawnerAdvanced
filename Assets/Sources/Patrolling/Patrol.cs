using System;
using UnityEngine;

namespace Assets.Sources.Patrolling
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField] private WayPoint[] _wayPoints;
        [SerializeField, Range(0, 50)] private float _movementSpeed = 1;
        private int _wayPointIndex = 0;

        private bool HasPatrolWay => _wayPoints.Length > 0;

        private void Awake()
        {

        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (! HasPatrolWay)
            {
                return;
            }

            var pathToPoint = 0;
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
    }
}
