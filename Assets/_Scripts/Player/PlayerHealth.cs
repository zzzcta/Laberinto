using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxVidas = 3;
    public int vidasRestantes;

    public GameEventSO gE;

    private void Start()
    {
        vidasRestantes = maxVidas;
        gE.OnPlayerDamaged += RecibirDaño;
    }

    public void RecibirDaño(int daño)
    {
        vidasRestantes -= daño;

        if (vidasRestantes <= 0)
        {
            gE.PlayerDead();
        }
    }
}
