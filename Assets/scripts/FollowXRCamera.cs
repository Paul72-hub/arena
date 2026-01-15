using UnityEngine;

public class FollowXRCamera : MonoBehaviour
{
    public Transform xrCamera;
    public bool followY = false; // usually false so the body doesn't bob with head
    public Vector3 offset;

    void Awake()
    {
        if (xrCamera == null && Camera.main != null)
            xrCamera = Camera.main.transform;
    }

    void LateUpdate()
    {
        if (!xrCamera) return;

        Vector3 pos = xrCamera.position + offset;

        if (!followY)
            pos.y = transform.position.y;

        transform.position = pos;
    }
}
