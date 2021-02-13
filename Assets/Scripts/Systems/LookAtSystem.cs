using Entitas;

public class LookAtSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> entities;

    public LookAtSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.HealthBar, GameMatcher.TargetIndicator));
    }

    public void Execute()
    {
        var mainCameraTransform = contexts.game.globals.mainCameraTransform;

        foreach (var e in entities)
        {
            if(e.hasHealthBar)
                e.healthBar.view.LookAt(mainCameraTransform);

            if(e.hasTargetIndicator)
                e.targetIndicator.view.LookAt(mainCameraTransform);
        }
    }
}
