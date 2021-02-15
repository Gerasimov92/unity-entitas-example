using Entitas;
using UnityEngine;

public class TargetPositionComponent : IComponent
{
    public Vector3 value;
    public float speed;
    public float stopDistance;
    public bool reached;
}
