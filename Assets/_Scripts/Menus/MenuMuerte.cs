using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void Start()
    {
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