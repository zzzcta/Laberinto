using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private int indicePuntoActual = 0;
    private List<Vector3> puntosDeRuta;

    public void Enter(EnemyContext context)
    {
        // Inicializar puntos de patrullaje si aún no están configurados
        if (puntosDeRuta == null)
        {
            if (context.Ruta == null)
            {
                Debug.LogError("La ruta no esta asignada");
                return;
            }

            puntosDeRuta = new List<Vector3>();
            foreach (Transform punto in context.Ruta)
            {
                puntosDeRuta.Add(punto.position);
            }
        }

        // Configurar el primer destino
        if (puntosDeRuta.Count > 0)
        {
            context.Agent.SetDestination(puntosDeRuta[indicePuntoActual]);
        }
    }

    public void Update(EnemyContext context)
    {
        // Comprobación de llegada al destino actual
        if (context.Agent.remainingDistance <= 0.5f && puntosDeRuta.Count > 0)
        {
            indicePuntoActual = (indicePuntoActual + 1) % puntosDeRuta.Count;
            context.Agent.SetDestination(puntosDeRuta[indicePuntoActual]);
        }

        // Detección del jugador
        if (Vector3.Distance(context.Agent.transform.position, context.Player.position) <= context.DetectionRadius)
        {
            Vector3 direccionHaciaJugador = (context.Player.position - context.Agent.transform.position).normalized;

            if (!Physics.Raycast(context.Agent.transform.position, direccionHaciaJugador, context.RangoVision, context.QueEsObstaculo))
            {
                if (Vector3.Angle(context.Agent.transform.forward, direccionHaciaJugador) <= context.AnguloVision / 2)
                {
                    context.CoroutineRunner.GetComponent<EnemyAI>().SwitchState(new ChaseState());
                }
            }
        }
    }

    public void Exit(EnemyContext context)
    {


    }
}
