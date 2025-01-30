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

    public void RecibirDaño(int daño)   // Resta la vida del player segun el daño que recibe si llega a < 0 muere
    {
        vidasRestantes -= daño;

        if (vidasRestantes <= 0)
        {
            gE.PlayerDead();
        }
    }
}