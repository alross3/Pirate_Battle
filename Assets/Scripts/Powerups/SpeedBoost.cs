using UnityEngine;

public class SpeedBoost : PowerUp
{
    [SerializeField] private float speedMultiplier = 2.5f;

    protected override void ApplyEffect(GameObject player)
    {
        PlayerController4 controller = player.GetComponent<PlayerController4>();
        if (controller == null) return;

        controller.playerSpeed *= speedMultiplier;
    }

    protected override void RemoveEffect(GameObject player)
    {
        PlayerController4 controller = player.GetComponent<PlayerController4>();
        if (controller == null) return;

        controller.playerSpeed /= speedMultiplier;
    }
}
