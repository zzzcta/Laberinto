using UnityEngine;
using UnityEngine.SceneManagement; //Necesario para cambiar de escenas

public class CambioEscena : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Laberinto");
        }
    }
}
