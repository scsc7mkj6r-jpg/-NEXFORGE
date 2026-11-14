using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    [Range(0.05f, 1f)]
    public float sensitivity = 0.15f;

    public void SetSensitivity(float value)
    {
        sensitivity = Mathf.Clamp(value, 0.05f, 1f);
    }
} 