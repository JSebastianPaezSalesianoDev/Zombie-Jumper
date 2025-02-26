using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;      // Velocidad de movimiento horizontal
    [SerializeField] float jumpForce = 7.5f;     // Fuerza del salto

    [SerializeField] float fallMultiplier= 2.5f;

    Vector2 vecGravity;
    public LayerMask groundLayer;           // Capa que representa el suelo
    public Transform groundCheck;      // Punto para verificar si está en el suelo
    public bool isGrounded;         // Indica si está en el suelo
    public float groundCheckRadius = 0.2f;  // Radio de detección del suelo

    private Rigidbody2D rb;          // Referencia al Rigidbody2D del personaje
    private bool firstJump = true;  // Permite un primer salto extra
    private AudioSource jumpSoundEffect; // Variable para el Audio Source del sonido de salto

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();   
         jumpSoundEffect = GetComponent<AudioSource>();
    }

    void Update()
    {
       /*  isGrounded = Physics2D.OverlapCircle(groundCheck.position, new Vector2(8f,0.3f), CapsuleDirection2D.Horizontal
        , groundLayer);  */// checkground() 

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (isGrounded)
        {
            firstJump = true; // Se resetea cuando toca el suelo
        }

        // Movimiento Horizontal
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (isGrounded || firstJump) // Permite un salto extra si no está en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpSoundEffect.Play();
            
            if (isGrounded)
            {
                firstJump = false;
            }
        }
    }

    bool CheckGround()
    {
        // Usa OverlapCircle para revisar si hay colisión con el suelo
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        return colliders.Length > 0;
    }
}
