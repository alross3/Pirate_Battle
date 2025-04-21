using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [SerializeField] protected float duration = 5f;
    [SerializeField] private GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            ApplyEffect(other.gameObject);

            
            GameObject timer = new GameObject("PowerUpTimer");
            timer.transform.parent = other.transform;

            PowerUpTimer powerUpTimer = timer.AddComponent<PowerUpTimer>();
            powerUpTimer.StartTimer(duration, () =>
            {
                RemoveEffect(other.gameObject);
            });

            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(GameObject player);
    protected abstract void RemoveEffect(GameObject player);
}
