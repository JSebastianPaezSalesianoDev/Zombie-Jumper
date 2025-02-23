using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento horizontal
    public float jumpForce = 10f;     // Fuerza del salto

    public Transform groundCheckPoint;      // Punto para verificar si está en el suelo
    public float groundCheckRadius = 0.2f;  // Radio de detección del suelo
    public LayerMask groundLayer;           // Capa que representa el suelo

    private Rigidbody2D rb;          // Referencia al Rigidbody2D del personaje
    private bool isGrounded;         // Indica si está en el suelo
    private bool wasJumping = false; // Evita saltos múltiples

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("ZombieMovement: No se encontró un Rigidbody2D en el personaje.");
        }
    }

    void Update()
    {
        isGrounded = CheckGround();

        if (isGrounded)
        {
            wasJumping = false; // Se puede volver a saltar cuando toca el suelo
        }

        // Movimiento Horizontal
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (isGrounded && !wasJumping) // Solo salta si está en el suelo y no ha saltado antes
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Resetea la velocidad en Y antes de saltar
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            wasJumping = true; // Se activa para evitar otro salto inmediato
        }
    }

    bool CheckGround()
    {
        // Usa OverlapCircle para revisar si hay colisión con el suelo
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, groundCheckRadius, groundLayer);
        return colliders.Length > 0;
    }
}
