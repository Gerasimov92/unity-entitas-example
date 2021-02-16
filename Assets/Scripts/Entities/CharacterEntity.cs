using UnityEngine;

public class CharacterEntity : AbstractEntity
{
    public GameObject prefab;
    public float health;
    public Weapon weapon;

    protected override void Start()
    {
        base.Start();
        entity.AddCharacter(CharacterState.Idle, weapon, false, null, null);
        entity.AddPrefab(prefab);
        entity.AddHealth(health);
        entity.AddOriginTransform(entity.position.value, entity.rotation.angle);
    }
}
