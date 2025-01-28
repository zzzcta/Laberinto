using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] GameEventSO GameEvent;
    public Transform Ruta;  // Puntos de patrulla
    public Transform Player;         // Referencia al jugador
    public LayerMask QueEsObstaculo;
    public LayerMask QueEsPlayer;
    [Header("Enemy Propieties")]
    public float AnguloVision;
    public float DetectionRadius = 10f; // Rango de detección
    public float AttackRadius = 2f;     // Rango de ataque

    private EnemyContext _context;      // Contexto para los estados  
    private IEnemyState _currentState;   // Estado actual

    private void Start()
    {
        // Crear el contexto
        _context = new EnemyContext(
            GetComponent<NavMeshAgent>(),
            Player,
            QueEsObstaculo,
            QueEsPlayer,
            Ruta,
            AnguloVision,
            DetectionRadius,
            AttackRadius,
            this,
            GameEvent,
            GetComponent<Animator>()
        );

        // Iniciar con un estado inicial
        SwitchState(new PatrolState());
    }

    private void Update()
    {
        // Actualizar el estado actual
        _currentState?.Update(_context);

    }

    public void SwitchState(IEnemyState newState)
    {
        _currentState?.Exit(_context);  // Salir del estado actual
        _currentState = newState;
        _currentState.Enter(_context); // Entrar al nuevo estado
    }

    private void OnDrawGizmosSelected()
    {
        // Visualización de los rangos en la escena
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
