using UnityEngine;
using System;

public class PowerUpTracker : MonoBehaviour
{
    public Action onCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            onCollected?.Invoke();
        }
    }
}
