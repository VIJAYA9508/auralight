using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;
    public float verticalLookLimit = 80f;

    private CharacterController controller;
    private float cameraPitch = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ----- Mouse Look -----
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player (left/right)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera (up/down)
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -verticalLookLimit, verticalLookLimit);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        // ----- Movement -----
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}







