
using UnityEngine;

public class TriggerCarrot : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gE.Dead();
        }
    }
}