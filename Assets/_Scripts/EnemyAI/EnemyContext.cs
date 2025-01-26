using UnityEngine;
using UnityEngine.AI;

public class EnemyContext
{
    public Transform Ruta { get; private set; }
    public float RangoVision { get; private set; }
    public float AnguloVision { get; private set; }
    public Transform Player { get; private set; }
    public LayerMask QueEsObstaculo { get; private set; }
    public float DetectionRadius { get; private set; }
    public float AttackRadius { get; private set; }
    public NavMeshAgent Agent { get; private set; } 
    public MonoBehaviour CoroutineRunner { get; private set; }
    public GameEventSO GameEvent {  get; private set; } 

    public EnemyContext(NavMeshAgent agent, Transform player, LayerMask obstaculo , Transform ruta, float anguloVision ,float detectionRadius, float attackRadius, MonoBehaviour coroutineRunner, GameEventSO gameEvent)
    {
        Agent = agent;
        Player = player;
        QueEsObstaculo = obstaculo;
        AnguloVision = anguloVision;
        Ruta = ruta;
        DetectionRadius = detectionRadius;
        AttackRadius = attackRadius;
        CoroutineRunner = coroutineRunner;
        GameEvent = gameEvent;
    }
}
