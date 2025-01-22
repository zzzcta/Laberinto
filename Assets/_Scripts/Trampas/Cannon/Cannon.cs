using Unity.VisualScripting;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject carrotPrefab; // Prefab de la zanahoria
    public Transform spawnPoint;   // Punto de salida de las zanahorias
    public float shootForce = 500f; // Fuerza con la que se disparará
    public float shootInterval = 2f; // Intervalo entre disparos

    private float shootTimer;

    void Update()
    {
        // Incrementa el temporizador
        shootTimer += Time.deltaTime;

        // Comprueba si es momento de disparar
        if (shootTimer >= shootInterval)
        {
            ShootCarrot();
            shootTimer = 0f; // Reinicia el temporizador
        }
    }

    void ShootCarrot()
    {
        // Crea la zanahoria en el punto de spawn
        GameObject carrot = Instantiate(carrotPrefab, spawnPoint.position, spawnPoint.rotation);

        // Aplica una fuerza al Rigidbody de la zanahoria
        Rigidbody rb = carrot.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(spawnPoint.forward * shootForce);
        }
    }
}

