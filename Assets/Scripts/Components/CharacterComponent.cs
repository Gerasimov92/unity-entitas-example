using Entitas;
using UnityEngine;

public class CharacterComponent : IComponent
{
    public CharacterState state;
    public Weapon weapon;
    public bool selected;
    public Animator animator;
}
