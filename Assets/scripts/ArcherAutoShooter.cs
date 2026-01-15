using UnityEngine;
using System.Collections;

public class ArcherAutoShooter : MonoBehaviour
{
    [Header("References")]
    public Transform anchorPoint;
    public Transform target;
    public GameObject arrowPrefab;

    [Header("Fire settings")]
    public float minInterval = 1f;
    public float maxInterval = 2.5f;
    public Vector3 aimOffset;

    [Header("Arrow orientation fix")]
    [Tooltip("If your arrow prefab is rotated wrong, set this to (0,90,0) or (0,-90,0).")]
    public Vector3 arrowRotationOffsetEuler = Vector3.zero;

    [Header("Aim deviation (spread)")]
    public float maxDeviationDegrees = 12f;
    [Range(0f, 1f)] public float deviationChance = 1f;

    private Coroutine loop;

    void Awake()
    {
        // For VR: default to headset camera if not assigned
        if (target == null && Camera.main != null)
            target = Camera.main.transform;
    }

    void OnEnable() => loop = StartCoroutine(ShootLoop());

    void OnDisable()
    {
        if (loop != null) StopCoroutine(loop);
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        }
    }

    void Shoot()
{
    if (!anchorPoint || !arrowPrefab) return;

    Transform t = target != null ? target : (Camera.main != null ? Camera.main.transform : null);
    if (t == null) return;

    Vector3 targetPos = t.position + aimOffset;
    Vector3 dir = (targetPos - anchorPoint.position).normalized;

    // deviation (optional)
    if (Random.value < deviationChance && maxDeviationDegrees > 0f)
    {
        float yaw = Random.Range(-maxDeviationDegrees, maxDeviationDegrees);
        float pitch = Random.Range(-maxDeviationDegrees, maxDeviationDegrees);

        Quaternion spreadRot =
            Quaternion.AngleAxis(yaw, transform.up) *
            Quaternion.AngleAxis(pitch, transform.right);

        dir = (spreadRot * dir).normalized;
    }

    Quaternion rot = Quaternion.LookRotation(dir, Vector3.up) * Quaternion.Euler(arrowRotationOffsetEuler);
    Instantiate(arrowPrefab, anchorPoint.position, rot);
}

}
