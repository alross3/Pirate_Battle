using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private Vector2 spawnAreaMin;
    [SerializeField] private Vector2 spawnAreaMax;
    [SerializeField] private int maxActivePowerUps = 5;

    private int currentPowerUps = 0;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentPowerUps < maxActivePowerUps)
            {
                SpawnRandomPowerUp();
            }
        }
    }

    private void SpawnRandomPowerUp()
    {
    Vector3 spawnPos = new Vector3(
        Random.Range(spawnAreaMin.x, spawnAreaMax.x),
        1f, //Height of powerups
        Random.Range(spawnAreaMin.y, spawnAreaMax.y)
    );

    int randomIndex = Random.Range(0, powerUpPrefabs.Length);
    GameObject powerUp = Instantiate(powerUpPrefabs[randomIndex], spawnPos, Quaternion.identity);

    currentPowerUps++;

    // Safer: check if the prefab has PowerUpTracker
    PowerUpTracker tracker = powerUp.GetComponent<PowerUpTracker>();
    if (tracker == null)
    {
        tracker = powerUp.AddComponent<PowerUpTracker>();
    }

    tracker.onCollected += () => currentPowerUps--;
    }

}