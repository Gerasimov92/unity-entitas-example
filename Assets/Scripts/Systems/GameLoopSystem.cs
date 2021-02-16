using System;
using Entitas;
using UnityEngine;

public class GameLoopSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> players;
    IGroup<GameEntity> enemies;

    public GameLoopSystem(Contexts contexts)
    {
        this.contexts = contexts;
        players = contexts.game.GetGroup(GameMatcher.Player);
        enemies = contexts.game.GetGroup(GameMatcher.Enemy);
        contexts.game.gameLoop.state = GameState.SwitchTarget;
    }

    public void Execute()
    {
        switch (contexts.game.gameLoop.state)
        {
        case GameState.Idle:
            break;

        case GameState.Attack:
            SelectPlayer();
            Attack(contexts.game.gameLoop.currentPlayer, contexts.game.gameLoop.currentEnemy);
            contexts.game.gameLoop.state = GameState.PlayerTurn;
            break;

        case GameState.SwitchTarget:
            NextTarget();
            contexts.game.gameLoop.state = GameState.Idle;
            break;

        case GameState.PlayerTurn:
        {
            if (contexts.game.gameLoop.currentPlayer.character.state == CharacterState.Idle)
                contexts.game.gameLoop.state = GameState.PlayerTurnEnd;
            break;
        }

        case GameState.PlayerTurnEnd:
            if(contexts.game.gameLoop.currentEnemy.character.state == CharacterState.Dead)
                NextTarget();
            else
            {
                Attack(contexts.game.gameLoop.currentEnemy, contexts.game.gameLoop.currentPlayer);
                contexts.game.gameLoop.state = GameState.EnemyTurn;
            }
            break;

        case GameState.EnemyTurn:
        {
            if (contexts.game.gameLoop.currentEnemy.character.state == CharacterState.Idle)
                contexts.game.gameLoop.state = GameState.EnemyTurnEnd;
            break;
        }

        case GameState.EnemyTurnEnd:
        {
            contexts.game.gameLoop.state = GameState.Idle;
            break;
        }

        case GameState.EndGame:
            break;

        default:
            break;
        }
    }

    private void SelectPlayer()
    {
        foreach (var e in players)
        {
            if (e.character.state != CharacterState.Dead)
            {
                e.character.selected = true;
                contexts.game.gameLoop.currentPlayer = e;
                break;
            }
        }
    }

    private void NextTarget()
    {
        var enemiesArray = enemies.GetEntities();

        int currentTarget = Array.FindIndex(enemiesArray, (e) => e.character.selected);
        if (currentTarget == -1 && enemiesArray.Length != 0)
        {
            if (enemiesArray[0].character.state != CharacterState.Dead)
            {
                enemiesArray[0].character.selected = true;
                contexts.game.gameLoop.currentEnemy = enemiesArray[0];
                return;
            }
            else
            {
                currentTarget = 0;
            }
        }

        for (int i = 1; i < enemiesArray.Length; i++)
        {
            int next = (currentTarget + i) % enemiesArray.Length;
            if (enemiesArray[next].character.state != CharacterState.Dead)
            {
                enemiesArray[currentTarget].character.selected = false;
                enemiesArray[next].character.selected = true;
                contexts.game.gameLoop.currentEnemy = enemiesArray[next];
                return;
            }
        }
    }

    private void Attack(GameEntity attacker, GameEntity target)
    {
        attacker.character.target = target;
        switch (attacker.character.weapon)
        {
        case Weapon.Bat:
            attacker.character.state = CharacterState.RunningToEnemy;
            break;
        case Weapon.Pistol:
            attacker.character.state = CharacterState.BeginShoot;
            break;
        case Weapon.Fist:
            attacker.character.state = CharacterState.RunningToEnemy;
            break;
        default:
            break;
        }
    }
}
