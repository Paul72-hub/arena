using UnityEngine;

public class MascotBreathing : MonoBehaviour
{
    public float scaleAmount = 0.02f;
    public float speed = 1.5f;

    Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        float s = 1f + Mathf.Sin(Time.time * speed) * scaleAmount;
        transform.localScale = baseScale * s;
    }
}
