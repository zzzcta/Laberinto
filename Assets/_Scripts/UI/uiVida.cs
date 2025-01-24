using UnityEngine;
using UnityEngine.UI;

public class uiVida : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    public Image[] vidaUI; // Array que contiene las imagenes de las fresas
    private int vidasRestantes; // Contador de fresas restantes

    public void OnEnable()
    {
        vidasRestantes = vidaUI.Length;
        gE.OnDa�o += uiVidaRestar;

    }

    public void OnDisable()
    {
        gE.OnDa�o -= uiVidaRestar;
    }
    public void uiVidaRestar()
    {
        // Comprueba si a�n quedan fresas por ocultar
        if (vidasRestantes > 0)
        {
            vidasRestantes--; // Reduce el contador de fresas
            vidaUI[vidasRestantes].enabled = false; // Oculta la ultima fresa activa
        }

        if (vidasRestantes == 0)
        {
            gE.Dead();
        }
    }
}