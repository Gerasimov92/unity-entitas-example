using Entitas;
using UnityEngine;

public class DeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;
    private static readonly int Death = Animator.StringToHash("Death");

    public DeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Character);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (e.character.state != CharacterState.Dead && e.health.value <= 0)
            {
                e.character.state = CharacterState.Dead;
                var animator = e.view.gameObject.GetComponentInChildren<Animator>();
                animator.SetTrigger(Death);
            }
        }
    }
}
