using UnityEngine;
public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject carrotPrefab; // Prefab de la zanahoria
    [SerializeField] private Transform spawnPoint;   // Punto de salida de las zanahorias
    [SerializeField] private float shootInterval = 2f; // Intervalo entre disparos
    [SerializeField] private float shootTimer;

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
        carrot.transform.Rotate(-90, 0, 0); // Ajusta los valores para que salga bien
    }
}