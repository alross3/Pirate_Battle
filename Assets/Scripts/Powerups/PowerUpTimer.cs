using UnityEngine;
using System;
using System.Collections;

public class PowerUpTimer : MonoBehaviour
{
    public void StartTimer(float duration, Action onComplete)
    {
        StartCoroutine(TimerRoutine(duration, onComplete));
    }

    private IEnumerator TimerRoutine(float duration, Action onComplete)
    {
        yield return new WaitForSeconds(duration);
        onComplete?.Invoke();
        Destroy(gameObject);
    }
}
