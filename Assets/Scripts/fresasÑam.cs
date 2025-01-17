using UnityEngine;

public class fresasÑam : MonoBehaviour
{
    public float velocidadMovimiento = 1f; // 
    public float alturaMovimiento = 0.5f;  // Para el movimiento vertical y rotacion de la fresa
    public float velocidadRotacion = 50f;  // 

    private AudioSource audioSource; // Referencia al AudioSource
    private Vector3 posicionInicial; // Guarda la posición inicial de la fresa



    void Start()
    {
        posicionInicial = transform.position;  //Guarda la posición inicial de la fresa

        audioSource = GetComponent<AudioSource>(); //Coge el componente de audio
    }

    void Update()
    {
        // Movimiento de subir y bajar usando Mathf.Sin
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadMovimiento) * alturaMovimiento;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime); //Rotacion alrededor del eje Y
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<FresaUI>().ComerFresa();   //Llamar al sistema de puntuacion
            GameManager.instance.RecolectarFresa(); 

            // Reproduce el sonido
            if (audioSource != null)
            {
                audioSource.Play();
            }
            Destroy(gameObject, 0.2f);  //Destruye la fresa y deja un poco de tiempo para que suene el sonido que lleva.
        }
    }
}