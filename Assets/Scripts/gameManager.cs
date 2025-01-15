using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia global para acceder desde otros scripts
    public int fresasRecolectadas = 0; // Contador de fresas
    public int fresasParaGanar = 5; // Numero de fresas para ganar

    public GameObject uiFresasConseguidas; // UI para terminar el juego "temporal"
    public GameObject Player;

    void Awake()
    {
        // Asegurarse de que haya solo una instancia del GameManager
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Metodo que se llama cada vez que el jugador recoge una fresa
    public void RecolectarFresa()
    {
        fresasRecolectadas++;

        // Si el jugador ha recolectado todas las fresas necesarias, llama a terminarJuego
        if (fresasRecolectadas >= fresasParaGanar)
        {
            terminarJuego();
        }
    }

    private void terminarJuego()
    {
        uiFresasConseguidas.SetActive(true); // Activar el panel para terminar
        Time.timeScale = 0; // Detener el tiempo
    }

    
}
