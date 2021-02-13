using UnityEngine;

public sealed class TargetIndicator : MonoBehaviour, ILookAt
{
    public GameObject pointer;

    public void SetActive(bool value)
    {
        pointer.SetActive(value);
    }

    public void LookAt(Transform t)
    {
        pointer.transform.LookAt(t);
    }

    void Start()
    {
        SetActive(false);
    }
}
