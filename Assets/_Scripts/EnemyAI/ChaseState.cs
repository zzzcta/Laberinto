using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IEnemyState
{
    public void Enter(EnemyContext context)
    {
        context.CoroutineRunner.GetComponent<NavMeshAgent>().speed *= 1.5f;
    }
    public void Update(EnemyContext context)
    {
        context.Agent.SetDestination(context.Player.position);
        context.Animator.SetTrigger("Persecucion");

        if (Vector3.Distance(context.Agent.transform.position, context.Player.position) <= context.AttackRadius)
        {
            context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new AttackState());
        }
        else if (Vector3.Distance(context.Agent.transform.position, context.Player.position) > context.DetectionRadius)
        {
            context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new PatrolState());
        }
    }

    public void Exit(EnemyContext context)
    {
        context.CoroutineRunner.GetComponent<NavMeshAgent>().speed /= 1.5f;
        context.Animator.ResetTrigger("Persecucion");
    }

}

