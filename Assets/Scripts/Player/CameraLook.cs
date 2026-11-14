using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;
    public CameraTouchInput touchInput;
    public CameraSettings cameraSettings;

    [SerializeField] private float defaultSensitivity = 0.15f;
    [SerializeField] private float minVerticalAngle = -85f;
    [SerializeField] private float maxVerticalAngle = 85f;

    private float xRotation;

    private void Update()
    {
        if (playerBody == null || touchInput == null)
            return;

        float sensitivity = cameraSettings != null
            ? cameraSettings.sensitivity
            : defaultSensitivity;

        Vector2 input = touchInput.GetLookDelta();

        xRotation -= input.y * sensitivity;
        xRotation = Mathf.Clamp(
            xRotation,
            minVerticalAngle,
            maxVerticalAngle
        );

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * input.x * sensitivity);
    }
}