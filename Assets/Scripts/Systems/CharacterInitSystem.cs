using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInitSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;

    public CharacterInitSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Character);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && !entity.hasHealthBar && !entity.hasTargetIndicator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.character.animator = e.view.gameObject.GetComponentInChildren<Animator>();
            e.AddHealthBar(e.view.gameObject.GetComponent<HealthBar>(), -1);
            e.AddTargetIndicator(e.view.gameObject.GetComponent<TargetIndicator>());
        }
    }
}
