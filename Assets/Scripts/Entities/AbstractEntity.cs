using UnityEngine;

public abstract class AbstractEntity : MonoBehaviour
{
    protected Contexts contexts { get; private set; }
    protected GameEntity entity { get; private set; }

    protected virtual void Start()
    {
        contexts = Contexts.sharedInstance;
        entity = contexts.game.CreateEntity();
        entity.AddPosition(transform.position);
        entity.AddRotation(transform.rotation.eulerAngles.y);
        Destroy(gameObject);
    }
}
