using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public static Movimiento Instance;
    public float runSpeed = 2f;
    public float jumpSpeed = 3f;
    private float originalRunSpeed;
    private float originalJumpSpeed;

    [SerializeField]
    private int lives = 5;

    private Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Text vidasText;
    public Text powerUpText;
    public Transform puntoDisparo;

    public bool mirandoDerecha = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        originalRunSpeed = runSpeed;
        originalJumpSpeed = jumpSpeed;
        Instance = this;

        if (vidasText == null)
        {
            Debug.LogError("Falta asignar el objeto de texto para mostrar las vidas en el Inspector.");
        }

        if (powerUpText == null)
        {
            Debug.LogError("Falta asignar el objeto de texto para mostrar el power-up en el Inspector.");
        }

        UpdateVidasText();
        UpdatePowerUpText("");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("run", true);
            mirandoDerecha = true;
        }
        else if (horizontal < 0)
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("run", true);
            mirandoDerecha = false;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("run", false);
        }

        if (Input.GetKey("space") && Checkground.IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        Voltear();
    }

    void Voltear()
    {
        if (mirandoDerecha)
        {
            puntoDisparo.localPosition = new Vector3(Mathf.Abs(puntoDisparo.localPosition.x), puntoDisparo.localPosition.y, puntoDisparo.localPosition.z);
        }
        else
        {
            puntoDisparo.localPosition = new Vector3(-Mathf.Abs(puntoDisparo.localPosition.x), puntoDisparo.localPosition.y, puntoDisparo.localPosition.z);
        }
    }

    public void ApplyPowerUp(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.SpeedBoost:
                StartCoroutine(SpeedBoost());
                break;
            case PowerUpType.JumpBoost:
                StartCoroutine(JumpBoost());
                break;
        }
        UpdatePowerUpText(powerUp.ToString());
    }

    IEnumerator SpeedBoost()
    {
        runSpeed *= 1.2f;
        yield return new WaitForSeconds(5);
        runSpeed = originalRunSpeed;
        UpdatePowerUpText("");
    }

    IEnumerator JumpBoost()
    {
        jumpSpeed *= 1.2f;
        yield return new WaitForSeconds(8);
        jumpSpeed = originalJumpSpeed;
        UpdatePowerUpText("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            PowerUp powerUp = collision.GetComponent<PowerUp>();
            if (powerUp != null)
            {
                ApplyPowerUp(powerUp.powerUpType);
                Destroy(collision.gameObject);
            }
        }
    }

    public void DecreaseLives(int amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            UpdateVidasText();
        }
    }

    void UpdateVidasText()
    {
        vidasText.text = "Vidas: " + lives.ToString();
    }

    void UpdatePowerUpText(string powerUp)
    {
        powerUpText.text = "Power-Up: " + powerUp;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
