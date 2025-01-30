using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IEnemyState
{
    public void Enter(EnemyContext context)
    {
        context.CoroutineRunner.GetComponent<NavMeshAgent>().speed *= 1.5f; // Al entrar al estado de chase multiplica su velocidad por 1.5
    }
    public void Update(EnemyContext context)
    {
        context.Agent.SetDestination(context.Player.position);  //Manda al agente a la posicion del player
        context.Animator.SetTrigger("Persecucion");

        if (Vector3.Distance(context.Agent.transform.position, context.Player.position) <= context.AttackRadius)    // Si la distancia entre el agente y el player es <= a su radio de ataque cambia de estado a AttackState
        {
            context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new AttackState());
        }
        else if (Vector3.Distance(context.Agent.transform.position, context.Player.position) > context.DetectionRadius) // Si la distancia entre el agente y el player es > a su radio de ataque cambia de estado a PatrolState
        {
            context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new PatrolState());
        }
    }

    public void Exit(EnemyContext context)
    {
        context.CoroutineRunner.GetComponent<NavMeshAgent>().speed /= 1.5f; // Al salir del estado de chase divide su velocidad por 1.5
        context.Animator.ResetTrigger("Persecucion");   // Al salir del estado de chase resetea el trigger de persecucion
    }

}

