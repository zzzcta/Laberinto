using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    // Referencia a la camara del jugador

    [Header("Movimiento")]
    [SerializeField] Transform playerCamera = null; 
    [SerializeField] float mouseSensivite = 3.5f;   //Sensibilidad del raton para el movimiento de la cámara
    [SerializeField] float walkSpeed = 6.0f;    //Velocidad de movimiento
    [SerializeField] float gravity = -13.0f;    //Gravedad
    [SerializeField] bool lookCursor = true; // Indica si el cursor debe bloquearse al iniciar el juego
    CharacterController controller = null;   // CharacterController para manejar el movimiento

    float camaraPitch = 0.0f; //    Controla la inclinación vertical de la cámara
    float velocityY = 0.0f;//   Velocidad vertical del jugador para calcular la caída

    private Vector2 lastMouseDelta = Vector2.zero; // Para comparar movimientos del ratón
    private Vector2 lastInputDir = Vector2.zero;   // Para comparar entradas de movimiento

    void Start()
    {
        // Obtiene el componente CharacterController del jugador
        controller = GetComponent<CharacterController>();

        // Bloquea el cursor si lookCursor está activado
        if (lookCursor)
        {
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
            Cursor.visible = false;                  // Oculta el cursor
        }
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Verifica si el ratón se mueve
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            if (mouseDelta != Vector2.zero)
            {
                updateMouseLook(mouseDelta);
            }

            // Verifica si hay entrada de movimiento
            Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (inputDir != Vector2.zero)
            {
                updateMovement(inputDir);
 
            }
        }
    }

    //Controla el movimiento de la cámara según la entrada del ratón
    void updateMouseLook(Vector2 mouseDelta)
    {
        camaraPitch -= mouseDelta.y * mouseSensivite;
        camaraPitch = Mathf.Clamp(camaraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * camaraPitch;
        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensivite);

        lastMouseDelta = mouseDelta; // Actualiza el último estado del ratón
    }

    // Controla el movimiento del jugador
    void updateMovement(Vector2 inputDir)
    {
        inputDir.Normalize();

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkSpeed;
        velocity += Vector3.up * velocityY;

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        lastInputDir = inputDir; // Actualiza el último estado de las teclas
    }
}