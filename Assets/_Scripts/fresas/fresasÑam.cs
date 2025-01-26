using UnityEngine;

public class fresasÑam : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gE.TriggerFresaComida();
            FindAnyObjectByType<AudioManager>().Play("FresaÑam");
            Destroy(gameObject);
        }
    }
}