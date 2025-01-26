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
            AwaitFallAndDead();
        }
    }

    private async void AwaitFallAndDead()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5));
        FindAnyObjectByType<AudioManager>().Play("BodyFall");
        await Task.Delay(TimeSpan.FromSeconds(0.3));
        gE.TriggerPlayerDamaged(3);
    }
}
