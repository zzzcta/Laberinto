using System;
using System.Threading.Tasks;
using UnityEngine;

public class Slip : MonoBehaviour
{
    [SerializeField] GameEventSO gE;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra al Trigger tiene el Animator
        Animator playerAnimator = other.GetComponent<Animator>();

        if (playerAnimator != null)
        {
            // Activar la animaci�n
            playerAnimator.SetBool("isSlip", true);
            FindAnyObjectByType<AudioManager>().Play("Slip");

            // Iniciar la tarea asincr�nica
            AwaitAndExecute();
        }
    }

    private async void AwaitAndExecute()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.8));
        gE.Dead();
    }
}
