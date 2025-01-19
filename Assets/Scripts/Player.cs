using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
public class Player : MonoBehaviour
{
    // Referencia a la camara del jugador
    [SerializeField] Transform playerCamera = null; 
    [SerializeField] float mouseSensivite = 3.5f;   //Sensibilidad del raton para el movimiento de la c�mara
    [SerializeField] float walkSpeed = 6.0f;    //Velocidad de movimiento
    [SerializeField] float gravity = -13.0f;    //Gravedad
    [SerializeField] bool lookCursor = true; // Indica si el cursor debe bloquearse al iniciar el juego
    CharacterController controller = null;   // CharacterController para manejar el movimiento
    float camaraPitch = 0.0f; //    Controla la inclinaci�n vertical de la c�mara
    float velocityY = 0.0f;//   Velocidad vertical del jugador para calcular la ca�da

    void Start()
    {
        // Obtiene el componente CharacterController del jugador
        controller = GetComponent<CharacterController>();

        // Bloquea el cursor si lookCursor est� activado
        if (lookCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
            Cursor.visible = false;                  // Oculta el cursor
        }
    }

    void Update()
    {
        updateMouseLook();  //Llamada a los metodos 
        updateMovement();
    }

    //Controla el movimiento de la c�mara seg�n la entrada del rat�n
    void updateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));   // Obtiene la entrada del raton en los ejes X e Y
        camaraPitch -= mouseDelta.y * mouseSensivite;   // Calcula el angulo de inclinaci�n vertical
        camaraPitch = Mathf.Clamp(camaraPitch, -90.0f, 90.0f);  // Restringe el �ngulo de la camara entre -90 y 90 grados
        playerCamera.localEulerAngles = Vector3.right * camaraPitch;    //Aplica la rotaci�n vertical a la c�mara
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensivite);   //Rota al jugador horizontalmente segun el movimiento del rat�n
    }

    // Controla el movimiento del jugador
    void updateMovement()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));   //Obtiene la entrada de movimiento en los ejes horizontal y vertical
        inputDir.Normalize();   //Normaliza el vector para mantener una velocidad constante
        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;     //Calcula la velocidad de movimiento del jugador en el plano XZ
        velocity += Vector3.up * velocityY;    //A�ade la velocidad vertical (ca�da o salto)

        if (controller.isGrounded)  //Si el jugador est� en el suelo reinicia la velocidad vertical
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;  //Aplica la gravedad al jugador

        controller.Move(velocity * Time.deltaTime);   //Mueve al jugador segun la velocidad calculada
    }

}
