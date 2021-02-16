using Entitas;
using System.Collections.Generic;

public class AnimationEventSystem : ReactiveSystem<GameEntity>
{
    Contexts contexts;
    IGroup<GameEntity> charcters;

    public AnimationEventSystem(Contexts contexts)
        : base(contexts.game)
    {
        this.contexts = contexts;
        charcters = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Character, GameMatcher.View));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AnimationEvent);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimationEvent;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            foreach (var character in charcters)
            {
                if (character.view.gameObject == e.animationEvent.sender)
                {
                    switch (e.animationEvent.value)
                    {
                    case AnimationEvent.ShootEnd:
                        character.character.state = CharacterState.Idle;
                        break;

                    case AnimationEvent.AttackEnd:
                        character.character.state = CharacterState.RunningFromEnemy;
                        break;

                    case AnimationEvent.PunchEnd:
                        character.character.state = CharacterState.RunningFromEnemy;
                        break;

                    case AnimationEvent.DoDamage:
                        character.character.target.health.value--;
                        break;

                    default:
                        break;
                    }

                    e.Destroy();
                    break;
                }
            }
        }
    }
}
