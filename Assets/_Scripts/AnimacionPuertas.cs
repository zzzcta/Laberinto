using UnityEngine;

public class AnimacionPuertas : MonoBehaviour
{
    public GameObject targetObject1; // Primer puerta que rota
    public GameObject targetObject2; // Segunda puerta que rota
    public Vector3 rotationAngles1 = new Vector3(0, 90, 0); // Angulo de rotación1
    public Vector3 rotationAngles2 = new Vector3(90, 0, 0); // Angulo de rotación2
    public float rotationDuration1 = 1f; // DuracionRotacion1
    public float rotationDuration2 = 1f; // DuracionRotacion2

    private Quaternion initialRotation1;
    private Quaternion targetRotation1;
    private Quaternion initialRotation2;
    private Quaternion targetRotation2;
    private bool isRotating = false;
    private float rotationTime = 0;

    private void Start()
    {
        // Guarda la rotación inicial de los objetos
        if (targetObject1 != null)
        {
            initialRotation1 = targetObject1.transform.rotation;
            targetRotation1 = initialRotation1 * Quaternion.Euler(rotationAngles1);
        }

        if (targetObject2 != null)
        {
            initialRotation2 = targetObject2.transform.rotation;
            targetRotation2 = initialRotation2 * Quaternion.Euler(rotationAngles2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isRotating) // Verifica que el jugador entre
        {
            isRotating = true; // Activa la rotacion
            rotationTime = 0; // Reinicia el tiempo
        }
    }

    private void Update()
    {
        if (isRotating)
        {
            // Realiza la interpolacion de la rotación para la primera puerta
            if (targetObject1 != null)
            {
                rotationTime += Time.deltaTime;
                float t = Mathf.Clamp01(rotationTime / rotationDuration1);
                targetObject1.transform.rotation = Quaternion.Lerp(initialRotation1, targetRotation1, t);
            }

            // Realiza la interpolacion de la rotación para la segunda puerta
            if (targetObject2 != null)
            {
                rotationTime += Time.deltaTime;
                float t = Mathf.Clamp01(rotationTime / rotationDuration2);
                targetObject2.transform.rotation = Quaternion.Lerp(initialRotation2, targetRotation2, t);
            }

            // Termina la rotacion cuando alcanza el objetivo
            if (rotationTime >= Mathf.Max(rotationDuration1, rotationDuration2))
            {
                isRotating = false;
            }
        }
    }
}
