using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public class GameLoopComponent : IComponent
{
    public GameState state;
    public GameEntity currentPlayer;
    public GameEntity currentEnemy;
}
