using UnityEngine;
using UnityEngine.UI;

public class FresaUI : MonoBehaviour
{
    public Image[] fresasUI; // Array que contiene las imagenes de las fresas
    private int fresasRestantes; // Contador de fresas restantes

    void Start()
    {
        // Inicializa el contador de fresas restantes con el total de imagenes que haya
        fresasRestantes = fresasUI.Length;
    }

    public void ComerFresa()
    {
        // Comprueba si aún quedan fresas por ocultar
        if (fresasRestantes > 0)
        {
            fresasRestantes--; // Reduce el contador de fresas
            fresasUI[fresasRestantes].enabled = false; // Oculta la ultima fresa activa
        }
    }
}
