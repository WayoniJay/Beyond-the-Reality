using UnityEngine;

public class FloatMotion : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
}
