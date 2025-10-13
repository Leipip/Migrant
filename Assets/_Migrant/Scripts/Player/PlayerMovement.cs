using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    
    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    
    private Rigidbody rb;
    private Vector3 currentVelocity;
    private float cameraPitch = 0f;
    private float cameraYaw = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // Get initial camera rotation
        if (cameraTransform != null)
        {
            Vector3 rot = cameraTransform.eulerAngles;
            cameraYaw = rot.y;
            cameraPitch = rot.x;
        }
    }
    
    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        cameraYaw += mouseX;
        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -80f, 80f); // Limit looking up/down
        
        // Get movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Calculate movement direction RELATIVE TO CAMERA
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        
        // Flatten directions (no vertical component)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        
        // Calculate target velocity based on camera direction
        Vector3 targetVelocity = (forward * vertical + right * horizontal) * moveSpeed;
        
        // Smoothly accelerate
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        
        // Rotate character to face movement direction (optional - can remove if you want to face camera direction)
        if (currentVelocity.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(currentVelocity.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }
        
        // Unlock cursor when ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector3(currentVelocity.x, rb.velocity.y, currentVelocity.z);
    }
    
    void LateUpdate()
    {
        // Apply camera rotation
        if (cameraTransform != null)
        {
            cameraTransform.rotation = Quaternion.Euler(cameraPitch, cameraYaw, 0f);
        }
    }
}