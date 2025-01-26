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

    public void RecibirDa�o(int da�o)
    {
        vidasRestantes -= da�o;

        if (vidasRestantes <= 0)
        {
            gE.PlayerDead();
        }
    }
}
