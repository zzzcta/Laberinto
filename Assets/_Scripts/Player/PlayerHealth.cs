using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxVidas = 3;
    public int vidasRestantes;

    public GameEventSO gE;

    private void Start()
    {
        vidasRestantes = maxVidas;
        gE.OnPlayerDamaged += RecibirDa�o;
    }

    public void RecibirDa�o(int da�o)   // Resta la vida del player segun el da�o que recibe si llega a < 0 muere
    {
        vidasRestantes -= da�o;

        if (vidasRestantes <= 0)
        {
            gE.PlayerDead();
        }
    }
}