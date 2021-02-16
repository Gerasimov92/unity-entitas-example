using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
    private Contexts contexts;

    void Start()
    {
        contexts = Contexts.sharedInstance;
    }

    void ShootEnd()
    {
        CreateEvent(AnimationEvent.ShootEnd);
    }

    void AttackEnd()
    {
        CreateEvent(AnimationEvent.AttackEnd);
    }

    void PunchEnd()
    {
        CreateEvent(AnimationEvent.PunchEnd);
    }

    void DoDamage()
    {
        CreateEvent(AnimationEvent.DoDamage);
    }

    void CreateEvent(AnimationEvent e)
    {
        var entity = contexts.game.CreateEntity();
        entity.AddAnimationEvent(e, transform.parent.gameObject);
    }
}
