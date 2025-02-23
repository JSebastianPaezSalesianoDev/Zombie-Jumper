using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento horizontal (ajustable en el Inspector)
    public float jumpForce = 10f;     // Fuerza del salto (ajustable en el Inspector)
    private Rigidbody2D rb;           // Referencia al componente Rigidbody2D del personaje
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("ZombieMovement: No se encontró un Rigidbody2D en el personaje.(Null)");
            // hay que tenerlo para que el script funcione
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;// para que se salga si no hay

         // Movimiento Horizontal
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // Obtiene -1 (izquierda), 0 (ninguno), 1 (derecha)
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // Mantiene la velocidad vertical actual
        rb.velocity = movement; // Aplica la velocidad horizontal al Rigidbody2D

        // Salto (al presionar la barra espaciadora)
        if (Input.GetButtonDown("Jump")) // "Jump" por defecto es la barra espaciadora
        {
            Jump();
        }

            void Jump()
    {
        // Aplicar una fuerza vertical para el salto
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ForceMode2D.Impulse es para un salto instantáneo
    }
        
    }
}
