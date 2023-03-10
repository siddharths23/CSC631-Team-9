using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public GameObject thirdPersonCamera;
    public GameObject topDownCamera;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isTopDownView = false;

    private Vector2 lastMousePos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thirdPersonCamera.SetActive(true);
        topDownCamera.SetActive(false);
        thirdPersonCamera.transform.position = transform.position - transform.forward * 10f + Vector3.up * 3f;
        thirdPersonCamera.transform.LookAt(transform.position);
        topDownCamera.transform.position = transform.position + Vector3.up * 30f;
        topDownCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

        // Set the last mouse position to the center of the screen
        lastMousePos = new Vector2(Screen.width / 2f, Screen.height / 2f);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Add left/right movement
        if (moveHorizontal != 0f)
        {
            movement += transform.right * moveHorizontal;
        }

        // Add forward/backward movement
        if (moveVertical != 0f)
        {
            movement += transform.forward * moveVertical;
        }

        rb.AddForce(movement.normalized * speed);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTopDownView = !isTopDownView;
            thirdPersonCamera.SetActive(!isTopDownView);
            topDownCamera.SetActive(isTopDownView);
        }

        // Get the mouse movement since last frame
        Vector2 mouseDelta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - lastMousePos;

        // Rotate the camera based on the mouse movement
        if (isTopDownView)
        {
            topDownCamera.transform.rotation *= Quaternion.Euler(-mouseDelta.y, mouseDelta.x, 0f);
        }
        else
        {
            transform.rotation *= Quaternion.Euler(0f, mouseDelta.x, 0f);
            thirdPersonCamera.transform.RotateAround(transform.position, Vector3.right, -mouseDelta.y);
        }

        // Set the last mouse position to the current position
        lastMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    void LateUpdate()
    {
        if (isTopDownView)
        {
            topDownCamera.transform.position = transform.position + Vector3.up * 30f;
            topDownCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
        else
        {
            thirdPersonCamera.transform.position = transform.position - transform.forward * 10f + Vector3.up * 3f;
            thirdPersonCamera.transform.LookAt(transform.position);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
