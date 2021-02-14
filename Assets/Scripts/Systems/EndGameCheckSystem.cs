using Entitas;
using UnityEngine;

public class EndGameCheckSystem : IExecuteSystem
{
    private Contexts contexts;
    IGroup<GameEntity> players;
    IGroup<GameEntity> enemies;

    public EndGameCheckSystem(Contexts contexts)
    {
        this.contexts = contexts;
        players = contexts.game.GetGroup(GameMatcher.Player);
        enemies = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        if (CheckEndGame())
        {

        }
    }

    private bool HasAliveCharacter(IGroup<GameEntity> characters)
    {
        foreach (var e in characters)
        {
            if (e.character.state != CharacterState.Dead)
                return true;
        }

        return false;
    }

    private bool CheckEndGame()
    {
        if (!HasAliveCharacter(players))
        {
            PlayerLost();
            return true;
        }

        if (!HasAliveCharacter(enemies))
        {
            PlayerWon();
            return true;
        }

        return false;
    }

    private void PlayerWon()
    {
        Debug.Log("Player won");
    }

    private void PlayerLost()
    {
        Debug.Log("Player lost");
    }
}
