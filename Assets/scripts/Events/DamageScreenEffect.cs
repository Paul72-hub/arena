using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageScreenEffect : MonoBehaviour
{
    public Image overlay;
    public float flashDuration = 0.25f;
    public float maxAlpha = 0.4f;

    void Awake()
    {
        if (overlay == null)
            overlay = GetComponentInChildren<Image>(true); // finds DamageOverlay under this object
    }

    void OnEnable()
    {
        PlayerEvents.OnPlayerHit += PlayEffect;
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerHit -= PlayEffect;
    }

    void PlayEffect()
    {
        if (overlay == null)
        {
            Debug.LogError("DamageScreenEffect: overlay Image is not assigned/found.");
            return;
        }

        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        overlay.color = new Color(1f, 0f, 0f, maxAlpha);
        yield return new WaitForSeconds(flashDuration);
        overlay.color = new Color(1f, 0f, 0f, 0f);
    }
}
