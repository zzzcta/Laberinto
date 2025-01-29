using UnityEngine;
using UnityEngine.UI;

public class FresaUI : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    public Image[] fresasUI; // Array que contiene las imagenes de las fresas
    private int fresasRestantes; // Contador de fresas restantes

    public void OnEnable()
    {
        fresasRestantes = fresasUI.Length;
        gE.OnFresaComida += uiFresa;
        
    }

    public void OnDisable()
    {
        gE.OnFresaComida -= uiFresa;
    }

    public void uiFresa()
    {
        // Comprueba si aún quedan fresas por ocultar
        if (fresasRestantes > 0)
        {
            fresasRestantes--; // Reduce el contador de fresas
            fresasUI[fresasRestantes].enabled = false; // Oculta la ultima fresa activa
        }
    }
}