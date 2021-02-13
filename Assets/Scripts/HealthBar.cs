using UnityEngine;

public sealed class HealthBar : MonoBehaviour, ILookAt
{
    public TextMesh textMesh;

    public void SetValue(float value)
    {
        textMesh.text = $"{value}";
    }

    public void LookAt(Transform t)
    {
        textMesh.transform.LookAt(t);
    }
}
