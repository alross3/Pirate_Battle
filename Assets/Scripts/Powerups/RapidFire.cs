using UnityEngine;

public class RapidFire : PowerUp
{
    [SerializeField] private float fireRateMultiplier = 0.2f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerController4 controller = player.GetComponent<PlayerController4>();
        if (controller == null) return;

        controller.cannonCooldown *= fireRateMultiplier;
    }

    protected override void RemoveEffect(GameObject player)
    {
        PlayerController4 controller = player.GetComponent<PlayerController4>();
        if (controller == null) return;

        controller.cannonCooldown /= fireRateMultiplier;
    }
}
