using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    [SerializeField] private GameObject uiTerminarJuego;
    [SerializeField] private int fresasRecolectadas = 0;
    [SerializeField] private int fresasParaGanar = 5;

    private void OnEnable()
    {
       gE.OnFresaComida += RecolectarFresa;
    }
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
        uiTerminarJuego.SetActive(true);
        Time.timeScale = 0; // Detener el tiempo
    }
}