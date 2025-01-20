using UnityEngine;

public class fresasÑam : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gE.FresaÑamComida();
            FindAnyObjectByType<AudioManager>().Play("FresaÑam");
            Destroy(gameObject, 0.2f);  //Destruye la fresa y deja un poco de tiempo para que suene el sonido que lleva.
        }
    }
}