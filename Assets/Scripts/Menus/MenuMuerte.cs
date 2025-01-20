using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    private void Start()
    {
        // Asegúrate de que el cursor sea visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Laberinto");
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
