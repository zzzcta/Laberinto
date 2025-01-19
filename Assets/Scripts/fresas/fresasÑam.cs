using UnityEngine;

public class fresasÑam : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    [SerializeField] private CanvasManagerSO cM;

    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Coge el componente de audio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gE.FresaComida();

            // Reproduce el sonido
            if (audioSource != null)
            {
               audioSource.Play();
            }
            Destroy(gameObject, 0.2f);  //Destruye la fresa y deja un poco de tiempo para que suene el sonido que lleva.
        }
    }
}