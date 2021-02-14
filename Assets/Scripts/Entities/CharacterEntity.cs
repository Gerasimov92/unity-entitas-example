using UnityEngine;

public class CharacterEntity : AbstractEntity
{
    public GameObject prefab;
    public float health;
    public Weapon weapon;

    protected override void Start()
    {
        base.Start();
        entity.AddCharacter(CharacterState.Idle, weapon, false);
        entity.AddPrefab(prefab);
        entity.AddHealth(health);
    }
}
