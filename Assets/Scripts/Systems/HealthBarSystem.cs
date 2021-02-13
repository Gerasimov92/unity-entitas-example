using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class HealthBarSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public HealthBarSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Health, GameMatcher.HealthBar));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            var value = e.health.value;
            if (!Mathf.Approximately(e.healthBar.value, value))
            {
                e.healthBar.value = value;
                e.healthBar.view.SetValue(value);
            }
        }
    }
}
