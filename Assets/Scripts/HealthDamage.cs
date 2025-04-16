using UnityEngine;

public class HealthDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 50f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage) // Required by IDamageable
    {
        currentHealth -= damage;
        Debug.Log($"{name} took {damage} damage! Health: {currentHealth}");

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}