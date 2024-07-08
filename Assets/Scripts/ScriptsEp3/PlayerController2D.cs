using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Debug para Magnitud
        CVector2 playerPosition = new CVector2(transform.position.x, transform.position.y);
        Debug.Log("Magnitud es " + CVector2.Magnitud(playerPosition));

        // Debug para Normaliza
        playerPosition = CVector2.Normaliza(playerPosition);
        Debug.Log("Normaliza es " + playerPosition);
    }

    void Update()
    {
        // Movimiento del personaje
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.AddForce(movement * moveSpeed);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Debug para Distancia
        CVector2 playerPosition = new CVector2(transform.position.x, transform.position.y);
        CVector2 targetPosition = new CVector2(target.position.x, target.position.y);
        float distance = CVector2.Distancia(playerPosition, targetPosition);
        Debug.Log("Distancia es " + distance);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
