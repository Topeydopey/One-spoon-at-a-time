using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class SpoonDragDynamic2D : MonoBehaviour
{
    [Header("Drag Settings")]
    public float dragFrequency = 5f;           // For a SpringJoint2D, how stiff/springy it is
    public float dragDampingRatio = 0.7f;      // For a SpringJoint2D, how quickly it stops oscillating
    public bool useSpringJoint = false;        // Toggle between SpringJoint2D vs DistanceJoint2D

    [Header("Rotation Settings")]
    public float torqueForce = 20f;            // How much torque to apply when pressing A or D

    private Rigidbody2D rb;
    private AnchoredJoint2D dragJoint;         // The joint we'll create at runtime
    private Camera mainCam;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    void Update()
    {
        HandleRotationInput();
        HandleMouseInput();
    }

    /// <summary>
    /// Handles rotating the spoon using A and D keys
    /// </summary>
    private void HandleRotationInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Apply a positive torque (counter-clockwise)
            rb.AddTorque(torqueForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Apply a negative torque (clockwise)
            rb.AddTorque(-torqueForce);
        }
    }

    /// <summary>
    /// Handles mouse clicking, dragging, and releasing logic.
    /// </summary>
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if we clicked on this spoon with a 2D raycast
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // If we hit this exact object, create a joint
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                CreateDragJoint(mousePos);
            }
        }
        else if (Input.GetMouseButton(0))
        {
            // If we're still holding the left mouse, update the joint anchor to follow the mouse
            if (dragJoint != null)
            {
                Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
                dragJoint.connectedAnchor = mousePos;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Destroy the joint when we release the mouse
            DestroyDragJoint();
        }
    }

    /// <summary>
    /// Creates a joint at runtime and attaches it to the spoon's rigidbody,
    /// using the mouse position as the connected anchor.
    /// </summary>
    private void CreateDragJoint(Vector2 mouseWorldPos)
    {
        // If a joint somehow exists, destroy it first
        DestroyDragJoint();

        if (useSpringJoint)
        {
            // Create a SpringJoint2D
            var springJoint = gameObject.AddComponent<SpringJoint2D>();
            springJoint.autoConfigureDistance = false;
            springJoint.frequency = dragFrequency;
            springJoint.dampingRatio = dragDampingRatio;
            springJoint.distance = 0f;   // We'll keep the spring at zero distance from the anchor
            dragJoint = springJoint;
        }
        else
        {
            // Create a DistanceJoint2D
            var distanceJoint = gameObject.AddComponent<DistanceJoint2D>();
            distanceJoint.autoConfigureDistance = false;
            distanceJoint.distance = 0.01f;
            dragJoint = distanceJoint; // Works fine because DistanceJoint2D inherits from AnchoredJoint2D
        }

        // Common settings for both types of joint
        // (Use the mouseWorldPos passed as parameter, not mousePos)
        dragJoint.connectedAnchor = mouseWorldPos;
        dragJoint.enableCollision = false;
        dragJoint.autoConfigureConnectedAnchor = false;
    }

    /// <summary>
    /// Cleans up the joint when the mouse is released or before creating a new one.
    /// </summary>
    private void DestroyDragJoint()
    {
        if (dragJoint != null)
        {
            Destroy(dragJoint);
            dragJoint = null;
        }
    }
}
