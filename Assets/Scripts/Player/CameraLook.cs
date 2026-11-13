using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;
    public CameraTouchInput touchInput;
    public CameraSettings cameraSettings;

    private float xRotation = 0f;

    private void Update()
    {
        if (touchInput == null || playerBody == null)
            return;

        float sensitivity = cameraSettings != null
            ? cameraSettings.sensitivity
            : 0.15f;

        Vector2 input = touchInput.GetLookDelta();

        float mouseX = input.x * sensitivity;
        float mouseY = input.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}