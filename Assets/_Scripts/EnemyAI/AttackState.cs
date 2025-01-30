using UnityEngine;
public class AttackState : IEnemyState
{
    [SerializeField] private float attackInterval = 1f;  // Intervalo entre ataques en segundos
    private float lastAttackTime = 0f;  // Ultima vez que el enemigo ataco
    [SerializeField] private int damage = 1;  // Daño que realiza el enemigo

    public void Enter(EnemyContext context)
    {
        context.Agent.isStopped = true;
        lastAttackTime = Time.time; // Inicia el temporizador de ataque al entrar al estado
    }

    public void Update(EnemyContext context)
    {
        // Verifica si el jugador esta dentro del radio de ataque
        if (Vector3.Distance(context.Agent.transform.position, context.Player.position) > context.AttackRadius)
        {
            // Si el jugador se aleja, cambia al estado de persecución
            context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new ChaseState());
        }
        else
        {
            // Si el jugador esta dentro del radio de ataque y ha pasado el intervalo de ataque
            if (Time.time - lastAttackTime >= attackInterval)
            {
                // Iniciar animación
                context.Animator.SetTrigger("Atacando");
                context.GameEvent.TriggerPlayerDamaged(damage);  // Llama al evento para aplicar el daño al jugador
                lastAttackTime = Time.time;  // Reinicia el temporizador de ataque
            }
        }
    }

    public void Exit(EnemyContext context)
    {
        context.Agent.isStopped = false;
        context.Animator.ResetTrigger("Atacando");
    }
}