using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSens = 100f;

    [SerializeField] private Transform playerModel;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;


    private void Update()
    {
        if (Time.timeScale != 0)
        {
            CursorInput();
        }
    }

    void CursorInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerModel.Rotate(Vector3.up * mouseX);
    }
}
