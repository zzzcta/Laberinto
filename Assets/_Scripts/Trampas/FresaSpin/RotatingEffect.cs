using System.Collections;
using UnityEngine;

public class RotatingEffect : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    [SerializeField] private float rotationSpeed = 360f; // Velocidad de rotación en grados por segundo
    [SerializeField] private float effectDuration = 3f; // Duración del efecto en segundos
  

    private bool isRotating = false; // Controla si el jugador está rotando


    private void OnEnable()
    {
        // Suscribirse al evento cuando el objeto se active
          gE.OnFresaSpinComida += StartRotationEffect;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento cuando el objeto se desactive
        gE.OnFresaSpinComida -= StartRotationEffect;
    }

    void Update()
    {
        // Si el efecto está activo, rota el jugador
        if (isRotating)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    public void StartRotationEffect()
    {
        if (!isRotating)
        {
            StartCoroutine(RotationCoroutine());
        }
    }

    private IEnumerator RotationCoroutine()
    {
        isRotating = true; // Activar rotación
        yield return new WaitForSeconds(effectDuration); // Esperar el tiempo especificado
        isRotating = false; // Detener rotación
        gE.TriggerPlayerDamaged(2);
    }
}
