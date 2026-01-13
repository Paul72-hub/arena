using UnityEngine;
using System.Collections;

public class ArcherLoopFireSimple : MonoBehaviour
{
    public GameObject arrowPrefab;   // Arrow_Projectile
    public Transform shootPoint;      // AnchorPoint
    public float interval = 2f;
    public float arrowSpeed = 30f;

    void Start()
    {
        StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(interval);
        }
    }

    void Fire()
    {
        GameObject arrow = Instantiate(
            arrowPrefab,
            shootPoint.position,
            shootPoint.rotation
        );

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = shootPoint.forward * arrowSpeed;
        }
    }
}
