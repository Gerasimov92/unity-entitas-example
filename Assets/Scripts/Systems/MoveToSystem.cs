using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MoveToSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public MoveToSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Position,
            GameMatcher.Rotation,
            GameMatcher.TargetPosition));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            e.targetPosition.reached = MoveTo(e);
        }
    }

    private bool MoveTo(GameEntity e)
    {
        Vector3 distance = e.targetPosition.value - e.position.value;
        if (distance.magnitude < 0.00001f)
        {
            e.ReplacePosition(e.targetPosition.value);
            return true;
        }

        Vector3 direction = distance.normalized;
        e.ReplaceRotation(Quaternion.LookRotation(direction).eulerAngles.y);

        Vector3 targetPosition = e.targetPosition.value;
        targetPosition -= direction * e.targetPosition.stopDistance;
        distance = (targetPosition - e.position.value);

        Vector3 step = direction * e.targetPosition.speed * Time.deltaTime;
        if (step.magnitude < distance.magnitude)
        {
            e.ReplacePosition(e.position.value + step);
            return false;
        }

        e.ReplacePosition(targetPosition);
        return true;
    }
}
