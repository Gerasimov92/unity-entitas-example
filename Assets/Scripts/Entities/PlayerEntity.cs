public class PlayerEntity : CharacterEntity
{
    protected override void Start()
    {
        base.Start();
        entity.isPlayer = true;
    }
}
