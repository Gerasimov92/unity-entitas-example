using Entitas;

public class CharacterComponent : IComponent
{
    public CharacterState state;
    public Weapon weapon;
    public bool selected;
}
