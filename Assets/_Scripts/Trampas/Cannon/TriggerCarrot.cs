
using UnityEngine;

public class TriggerCarrot : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindAnyObjectByType<AudioManager>().Play("Hurt");
            gE.Daño();
        }
    }
}
