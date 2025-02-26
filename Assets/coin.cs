using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Moneda recogida!");

         
            CoinManager coinManager = FindObjectOfType<CoinManager>();

            if (coinManager != null)
            {
                coinManager.AddCoins(1); 
            }
            else
            {
                Debug.LogError("No se encontró CoinManager en la escena!");
            }

            Destroy(gameObject); 
        }
    }
}