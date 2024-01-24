using UnityEngine;

namespace Assets.Sources.Targets
{
    public class Target : MonoBehaviour, IPositionProvider
    {
        public Vector3 Position => transform.position;
    }
}