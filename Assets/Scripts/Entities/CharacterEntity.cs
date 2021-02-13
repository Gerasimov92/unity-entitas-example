using UnityEngine;

public class CharacterEntity : AbstractEntity
{
    public GameObject prefab;
    public float health;
    public Weapon weapon;

    protected override void Start()
    {
        base.Start();
        entity.AddCharacter(health > 0, weapon);
        entity.AddPrefab(prefab);
        entity.AddHealth(health);
    }
}
