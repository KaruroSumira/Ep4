using UnityEngine;

public class FlyEnemy : Enemy
{
    public int livesToDecrease = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Movimiento playerMovement = collision.gameObject.GetComponent<Movimiento>();
            if (playerMovement != null)
            {
                playerMovement.DecreaseLives(livesToDecrease);
            }

            Destroy(gameObject);
        }
    }
}
