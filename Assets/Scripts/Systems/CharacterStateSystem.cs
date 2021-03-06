﻿using Entitas;
using UnityEngine;

public class CharacterStateSystem : IExecuteSystem
{
    Contexts contexts;
    IGroup<GameEntity> entities;
    float runSpeed = 5.0f;
    float distanceFromEnemy = 0.5f;

    public CharacterStateSystem(Contexts contexts)
    {
        this.contexts = contexts;
        entities = contexts.game.GetGroup(GameMatcher.Character);
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            switch (e.character.state) 
            {
            case CharacterState.Idle:
                e.ReplaceRotation(e.originTransform.rotation);
                e.character.animator.SetFloat(CharacterAnimator.Speed, 0.0f);
                break;

            case CharacterState.RunningToEnemy:
                if (!e.hasTargetPosition)
                {
                    e.character.animator.SetFloat(CharacterAnimator.Speed, runSpeed);
                    e.AddTargetPosition(e.character.target.position.value, runSpeed, distanceFromEnemy, false);
                }
                else if (e.targetPosition.reached)
                {
                    e.RemoveTargetPosition();
                    switch (e.character.weapon)
                    {
                    case Weapon.Bat:
                        e.character.state = CharacterState.BeginAttack;
                        break;

                    case Weapon.Fist:
                        e.character.state = CharacterState.BeginPunch;
                        break;
                    }
                }
                break;

            case CharacterState.BeginAttack:
                e.character.animator.SetTrigger(CharacterAnimator.MeleeAttack);
                e.character.state = CharacterState.Attack;
                break;

            case CharacterState.Attack:
                break;

            case CharacterState.BeginShoot:
                LookAtTarget(e);
                e.character.animator.SetTrigger(CharacterAnimator.Shoot);
                e.character.state = CharacterState.Shoot;
                break;

            case CharacterState.Shoot:
                break;

            case CharacterState.BeginPunch:
                e.character.animator.SetTrigger(CharacterAnimator.Punch);
                e.character.state = CharacterState.Punch;
                break;

            case CharacterState.Punch:
                break;

            case CharacterState.RunningFromEnemy:
                if (!e.hasTargetPosition)
                {
                    e.character.animator.SetFloat(CharacterAnimator.Speed, runSpeed);
                    e.AddTargetPosition(e.originTransform.position, runSpeed, 0, false);
                }
                else if (e.targetPosition.reached)
                {
                    e.RemoveTargetPosition();
                    e.character.state = CharacterState.Idle;
                }
                break;

            case CharacterState.BeginDying:
                e.character.animator.SetTrigger(CharacterAnimator.Death);
                e.character.state = CharacterState.Dead;
                break;

            case CharacterState.Dead:
                e.character.selected = false;
                break;

            default:
                break;
            }
        }
    }

    private void LookAtTarget(GameEntity e)
    {
        Vector3 distance = e.character.target.position.value - e.position.value;
        Vector3 direction = distance.normalized;
        e.ReplaceRotation(Quaternion.LookRotation(direction).eulerAngles.y);
    }
}
