using UnityEngine;
using System.Collections;

public class ArrowSpawner : MonoBehaviour
{
    public Transform shootPoint;        // AnchorPoint
    public GameObject arrowPrefab;      // Arrow_Projectile (avec HumanArcherArrow)
    public float interval = 2f;
    public Transform target;            // ta mascotte (optionnel pour l’instant)

    void Start()
    {
        if (!shootPoint || !arrowPrefab)
        {
            Debug.LogError($"{name}: shootPoint ou arrowPrefab manquant", this);
            enabled = false;
            return;
        }
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(interval);
        }
    }

    void Fire()
    {
        // Si pas de target, tire tout droit
        Vector3 dir = shootPoint.forward;

        // Si target assignée, vise la target
        if (target)
            dir = (target.position - shootPoint.position).normalized;

        // Rotation propre vers la direction choisie
        Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);

        Instantiate(arrowPrefab, shootPoint.position, rot);
    }
}
