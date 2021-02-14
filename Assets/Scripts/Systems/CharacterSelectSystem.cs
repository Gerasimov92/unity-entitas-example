using Entitas;

public class CharacterSelectSystem : IExecuteSystem
{
    IGroup<GameEntity> entities;

    public CharacterSelectSystem(Contexts contexts)
    {
        entities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Character, GameMatcher.TargetIndicator));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            e.targetIndicator.view.SetActive(e.character.selected);
        }
    }
}
