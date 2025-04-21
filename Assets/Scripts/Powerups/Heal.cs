using UnityEngine;

public class Heal : PowerUp
{
    [SerializeField] private float healAmount = 20f;

    protected override void ApplyEffect(GameObject player)
    {
        HealthDamage health = player.GetComponent<HealthDamage>();
        if (health == null) return;

        health.TakeDamage(-healAmount);
    }

    protected override void RemoveEffect(GameObject player)
    {

    }
}
