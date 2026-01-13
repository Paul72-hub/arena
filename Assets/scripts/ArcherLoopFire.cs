using UnityEngine;
using System.Collections;

public class ArcherLoopFire : MonoBehaviour
{
    [Header("Refs")]
    public KevinIglesias.HumanArcherController controller;

    [Header("Timing")]
    public float interval = 2f;      // temps entre deux tirs
    public float shootDelay = 0f;    // délai avant le tir (optionnel)
    public float shootDuration = 0.15f; // durée release (ok par défaut)

    private Coroutine loop;

    void OnEnable()
    {
        if (controller == null)
            controller = GetComponentInChildren<KevinIglesias.HumanArcherController>();

        loop = StartCoroutine(FireLoop());
    }

    void OnDisable()
    {
        if (loop != null) StopCoroutine(loop);
    }

    IEnumerator FireLoop()
    {
        // petit délai au start pour éviter soucis d'init
        yield return null;

        while (true)
        {
            if (controller != null)
                controller.ShootArrow(shootDelay, shootDuration);

            yield return new WaitForSeconds(interval);
        }
    }
}
