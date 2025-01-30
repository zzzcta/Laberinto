using System.Collections;
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

            // Iniciar la corrutina en lugar de usar async
            StartCoroutine(FallAndDamage());
        }
    }

    private IEnumerator FallAndDamage()
    {
        yield return new WaitForSeconds(0.5f); // Espera 0.5s
        FindAnyObjectByType<AudioManager>().Play("BodyFall");

        yield return new WaitForSeconds(0.3f); // Espera 0.3s
        gE.TriggerPlayerDamaged(3);
    }
}
