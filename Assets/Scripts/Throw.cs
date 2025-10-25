using UnityEngine;

public class Throw : MonoBehaviour
{
    public float throwForce = 20f;         // Power of the throw
    public Transform holdPoint;            // Where the orb is held
    private Rigidbody rb;
    private bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Update()
    {
        // Grab the orb when pressing G
        if (Input.GetKeyDown(KeyCode.G) && !isHeld)
        {
            GrabOrb();
        }
        // Release and throw when pressing T
        else if (Input.GetKeyDown(KeyCode.T) && isHeld)
        {
            ThrowOrb();
        }

        // Keep the orb in front of the camera while held
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;
            transform.rotation = holdPoint.rotation;
        }
    }

    void GrabOrb()
    {
        isHeld = true;
        rb.useGravity = false;
        rb.isKinematic = true;

        // Move the orb to the holding point instantly
        transform.position = holdPoint.position;
        transform.parent = holdPoint;
    }

    void ThrowOrb()
    {
        isHeld = false;
        transform.parent = null;
        rb.isKinematic = false;
        rb.useGravity = true;

        // Apply force forward from the hold point (camera)
        rb.AddForce(holdPoint.forward * throwForce, ForceMode.Impulse);
    }
}