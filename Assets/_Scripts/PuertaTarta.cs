using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaTarta : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            {
                SceneManager.LoadScene("Laberinto");
            }
        }
    }
}