public class EnemyEntity : CharacterEntity
{
    protected override void Start()
    {
        base.Start();
        entity.isEnemy = true;
    }
}
