using UnityEngine;

public class FresaSpin : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el script de rotaci�n
        RotatingEffect rotatingEffect = other.GetComponent<RotatingEffect>();
        if (rotatingEffect != null)
        {
            gE.TriggerFresaSpinComida();
            FindAnyObjectByType<AudioManager>().Play("FresaSpin");
            Destroy(gameObject); // Eliminar el comestible
        }
    }
}