using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform puntoDisparo;
    public GameObject balaPrefab;
    public float velocidadBala = 30f;
    private Animator animator;
    private Movimiento movimientoScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoScript = GetComponent<Movimiento>();

        if (puntoDisparo == null)
        {
            Debug.LogError("Falta asignar el objeto puntoDisparo en el Inspector.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        animator.SetTrigger("disparar");

        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();

        float direccionBala = movimientoScript.mirandoDerecha ? 1 : -1;
        rb.velocity = new Vector2(direccionBala * velocidadBala, rb.velocity.y);

        if (!movimientoScript.mirandoDerecha)
        {
            Vector3 escalaBala = bala.transform.localScale;
            escalaBala.x = -escalaBala.x;
            bala.transform.localScale = escalaBala;
        }
    }
}
