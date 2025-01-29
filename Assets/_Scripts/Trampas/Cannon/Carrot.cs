using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Velocidad de la zanahoria

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
    }
}
