using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform playerBody;
    public float sensitivity = 150f;

    private float xRotation = 0f;

    public void Look(Vector2 input)
    {
        float mouseX = input.x * sensitivity * Time.deltaTime;
        float mouseY = input.y * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}