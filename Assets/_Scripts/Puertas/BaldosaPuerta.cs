using UnityEngine;

public class BaldosaPuerta : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    [SerializeField] private int idBaldosa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gE.BaldosaPulsada(idBaldosa);
        }
    }
}