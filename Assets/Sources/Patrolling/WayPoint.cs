using UnityEngine;

namespace Assets.Sources.Patrolling
{
    public class WayPoint : MonoBehaviour, IPositionProvider
    {
        public Vector3 Position => transform.position;
    }
}