using UnityEngine;

public class TriggerCarrot : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gE.TriggerPlayerDamaged(1);
            FindAnyObjectByType<AudioManager>().Play("Hurt");
        }
    }
}
