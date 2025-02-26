using UnityEngine;
using TMPro; // Necesario si usas TextMeshPro. Si usas Text UI normal, usa: using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount = 0; // Variable para llevar la cuenta de monedas

    [SerializeField] public TextMeshProUGUI coinText; // Referencia al TextMeshPro Text UI. Si usas Text UI normal, usa: public Text coinText;

    void Start()
    {
        UpdateCoinText(); // Inicializa el texto al inicio
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        UpdateCoinText(); // Actualiza el texto cada vez que se añaden monedas
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Monedas: " + coinCount.ToString(); // Actualiza el texto con el valor de coinCount
        }
        else
        {
            Debug.LogError("CoinCounterText no asignado en CoinManager!");
        }
    }
}