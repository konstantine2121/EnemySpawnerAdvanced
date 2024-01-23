using UnityEngine;

namespace Assets.Sources.Patrolling
{
    public class WayPoint : MonoBehaviour, IEntity
    {
        public Vector3 Position => transform.position;
    }
}