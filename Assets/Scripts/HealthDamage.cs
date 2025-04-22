using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 50f;
    private float currentHealth;
    private Renderer playerRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        playerRenderer = GetComponent<Renderer>(); 
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        Debug.Log($"{name} took {damage} damage! Health: {currentHealth}");

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {

        if (playerRenderer != null)
        {
            playerRenderer.enabled = false;
        }


        StartCoroutine(ResetSceneAfterDelay(3f));
    }

    private System.Collections.IEnumerator ResetSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

}