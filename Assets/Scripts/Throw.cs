using UnityEngine;

public class Throw : MonoBehaviour
{
    public float throwForce = 20f;          // Power of the throw
    public Transform holdPoint;             // Where the orb is held
    private Rigidbody rb;
    private bool isHeld = false;
    private static bool isAnyHeld = false;  // Prevents multiple grabs
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        cam = Camera.main;
    }

    void Update()
    {
        // Try grabbing when G is held down
        if (Input.GetKey(KeyCode.G) && !isHeld && !isAnyHeld)
        {
            TryGrabOrb();
        }

        // When G is released, throw the orb
        if (Input.GetKeyUp(KeyCode.G) && isHeld)
        {
            ThrowOrb();
        }

        // Keep orb in front of camera when held
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;
            transform.rotation = holdPoint.rotation;
        }
    }

    void TryGrabOrb()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        // Raycast checks which orb is in front of camera
        if (Physics.Raycast(ray, out hit, 3f))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                GrabOrb();
            }
        }
    }

    void GrabOrb()
    {
        isHeld = true;
        isAnyHeld = true;
        rb.useGravity = false;
        rb.isKinematic = true;

        transform.position = holdPoint.position;
        transform.parent = holdPoint;
    }

    void ThrowOrb()
    {
        isHeld = false;
        isAnyHeld = false;
        transform.parent = null;
        rb.isKinematic = false;
        rb.useGravity = true;

        // Add forward impulse from the hold point (camera)
        rb.AddForce(holdPoint.forward * throwForce, ForceMode.Impulse);
    }
}