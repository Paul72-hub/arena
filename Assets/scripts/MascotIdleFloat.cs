using UnityEngine;

public class MascotIdleFloat : MonoBehaviour
{
    [Header("Floating")]
    public float floatAmplitude = 0.15f;
    public float floatSpeed = 1.2f;

    [Header("Rotation")]
    public float rotationSpeed = 12f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Float up & down
        float y = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = startPos + new Vector3(0f, y, 0f);

        // Slow rotation
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
