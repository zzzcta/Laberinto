using UnityEngine;
using UnityEngine.SceneManagement; //Necesario para cambiar de escenas

public class CambioEscena : MonoBehaviour
{
    // Nombre de la escena a la que cambiar (no me va poniendo el nombre de la escena)
    public string nombreEscena;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CambiarEscena();
        }
    }

    //Metodo para cambiar la escena segun su indice
    void CambiarEscena()
    {
        int sceneIndex = 1; 
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
       
    }

}
