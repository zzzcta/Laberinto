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
        vidasRestantes = vidaUI.Length; // Inicializar vidas según la UI
        gE.OnPlayerDamaged += ActualizarUI;
        gE.OnPlayerDead += MostrarGameOver;
    }

    private void OnDisable()
    {
        gE.OnPlayerDamaged -= ActualizarUI;
        gE.OnPlayerDead -= MostrarGameOver;
    }

    private void ActualizarUI(int daño)
    {
        // Reducir las vidas restantes según el daño recibido
        vidasRestantes -= daño;

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
