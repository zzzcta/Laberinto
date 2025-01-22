using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;

    private void Start()
    {
        gE.OnDead += Muerto;
    }

    private void Muerto()
    {
        SceneManager.LoadScene("LabDeadMenu");
    }
}
