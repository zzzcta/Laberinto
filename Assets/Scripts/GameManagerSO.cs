using System;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "GameManagerSO")]
public class GameManagerSO : ScriptableObject
{
  
    [SerializeField] private int fresasRecolectadas = 0;
    [SerializeField] private int fresasParaGanar = 5;

    public event Action <int> OnBaldosaPulsada;
    public void BaldosaPulsada(int idBaldosa)
    {
        OnBaldosaPulsada?.Invoke(idBaldosa);
    }

    private void OnEnable()
    {
        fresasRecolectadas = 0;
        fresasParaGanar = 5;
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
        
        Time.timeScale = 0; // Detener el tiempo
    }

}
