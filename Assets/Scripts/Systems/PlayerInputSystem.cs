using System;
using Entitas;
using UnityEngine;

public class PlayerInputSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> enemies;
    bool selectFirstEnemy = true;

    public PlayerInputSystem(Contexts contexts)
    {
        this.contexts = contexts;
        enemies = contexts.game.GetGroup(GameMatcher.Enemy);
    }

    public void Execute()
    {
        if (selectFirstEnemy)
        {
            NextTarget();
            selectFirstEnemy = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            NextTarget();
        }
    }

    private void NextTarget()
    {
        var enemiesArray = enemies.GetEntities();

        int currentTarget = Array.FindIndex(enemiesArray, (e) => e.character.selected);
        if (currentTarget == -1 && enemiesArray.Length != 0)
        {
            enemiesArray[0].character.selected = true;
            return;
        }

        for (int i = 1; i < enemiesArray.Length; i++)
        {
            int next = (currentTarget + i) % enemiesArray.Length;
            if (enemiesArray[next].character.state != CharacterState.Dead)
            {
                enemiesArray[currentTarget].character.selected = false;
                enemiesArray[next].character.selected = true;
                return;
            }
        }
    }
}
