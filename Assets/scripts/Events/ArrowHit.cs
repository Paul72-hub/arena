using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // You can use tag or layer — tag is simpler
        if (other.CompareTag("Player"))
        {
            PlayerEvents.OnPlayerHit?.Invoke();

            // Destroy arrow after hit
            Destroy(gameObject);
        }
    }
}
