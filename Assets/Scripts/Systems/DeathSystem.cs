using Entitas;
using UnityEngine;

public class DeathSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public DeathSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.Character);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (e.character.state != CharacterState.BeginDying &&
                e.character.state != CharacterState.Dead &&
                e.health.value <= 0)
            {
                e.character.state = CharacterState.BeginDying;
            }
        }
    }
}
