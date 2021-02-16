using Entitas;
using UnityEngine;

public class PlayerInputSystem : IExecuteSystem
{
    Contexts contexts;

    public PlayerInputSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        if (contexts.game.gameLoop.state != GameState.Idle)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            contexts.game.gameLoop.state = GameState.Attack;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            contexts.game.gameLoop.state = GameState.SwitchTarget;
            return;
        }
    }
}
