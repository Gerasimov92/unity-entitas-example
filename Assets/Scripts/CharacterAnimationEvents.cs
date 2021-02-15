using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    //Character character;

    void Start()
    {
        //character = GetComponentInParent<Character>();
    }

    void ShootEnd()
    {
        Debug.Log("ShootEnd");
        //character.SetState(Character.State.Idle);
    }

    void AttackEnd()
    {
        Debug.Log("AttackEnd");
        //character.SetState(Character.State.RunningFromEnemy);
    }

    void PunchEnd()
    {
        Debug.Log("PunchEnd");
        //character.SetState(Character.State.RunningFromEnemy);
    }

    void DoDamage()
    {
        Debug.Log("DoDamage");
        /*Character targetCharacter = character.target.GetComponent<Character>();
        targetCharacter.DoDamage();*/
    }
}
