using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIVida : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    public Image[] vidaUI;

    private int vidasRestantes;

    private void OnEnable()
    {
        vidasRestantes = vidaUI.Length; // Inicializar vidas seg�n la UI
        gE.OnPlayerDamaged += ActualizarUI;
        gE.OnPlayerDead += MostrarGameOver;
    }

    private void OnDisable()
    {
        gE.OnPlayerDamaged -= ActualizarUI;
        gE.OnPlayerDead -= MostrarGameOver;
    }

    private void ActualizarUI(int da�o)
    {
        // Reducir las vidas restantes seg�n el da�o recibido
        vidasRestantes -= da�o;

        for (int i = 0; i < vidaUI.Length; i++)
        {
            vidaUI[i].enabled = i < vidasRestantes;
        }
    }

    private void MostrarGameOver()
    {
        SceneManager.LoadScene("LabDeadMenu");
    }
}
