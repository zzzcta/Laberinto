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
            // Activar la animación
            playerAnimator.SetBool("isSlip", true);
            FindAnyObjectByType<AudioManager>().Play("Slip");
            AwaitAndFallSound();
            // Iniciar la tarea asincrónica
            AwaitAndDead();
        }
    }

    private async void AwaitAndDead()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.8));
        gE.Dead();
    }

    private async void AwaitAndFallSound()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5));
        FindAnyObjectByType<AudioManager>().Play("BodyFall");
    }

}
