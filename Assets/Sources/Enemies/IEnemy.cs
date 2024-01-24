namespace Assets.Sources.Enemies
{
    public interface IEnemy
    {
        void SetTarget(IPositionProvider direction);
    }
}
