using UnityEngine;

public enum PowerUpType
{
    SpeedBoost,
    JumpBoost
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Movimiento player = collision.GetComponent<Movimiento>();
            if (player != null)
            {
                player.ApplyPowerUp(powerUpType);
                Destroy(gameObject);
            }
        }
    }
}
