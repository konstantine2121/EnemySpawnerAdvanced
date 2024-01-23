using UnityEngine;

namespace Assets.Sources.Enemies
{
    public interface IEnemy
    {
        void SetTarget(IEntity direction);
    }
}
