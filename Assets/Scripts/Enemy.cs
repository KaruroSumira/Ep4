using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Movimiento playerMovement = collision.gameObject.GetComponent<Movimiento>();
            if (playerMovement != null)
            {
                playerMovement.DecreaseLives(1);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.Instance.IncrementarPuntos(1);
        }
    }
}
