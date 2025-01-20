using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FresaSpin : MonoBehaviour
{
    [SerializeField] GameEventSO gE;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene el script de rotación
        RotatingEffect rotatingEffect = other.GetComponent<RotatingEffect>();
        if (rotatingEffect != null)
        {
            gE.FresaSpinComida();
            Destroy(gameObject); // Eliminar el comestible
        }
    }
}
