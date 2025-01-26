using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : MonoBehaviour
{
    [SerializeField] private Transform ruta;
    [SerializeField] private float rangoVision;
    [SerializeField] private float anguloVision;
    [SerializeField] private LayerMask queEsTarget;
    [SerializeField] private LayerMask queEsObstaculo;
    private List<Vector3> puntosDeRuta = new List<Vector3>();
    private NavMeshAgent agent;
    private int indicePuntoActual = 0;
    private Vector3 destinoActual;
    private Coroutine corrutinaPatrulla;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (ruta == null)
        {
            Debug.LogError("No se asigno una ruta en el inspector");
            return;
        }

        foreach (Transform punto in ruta)
        {
            puntosDeRuta.Add(punto.position);
        }

        if (puntosDeRuta.Count == 0)
        {
            Debug.LogError("La ruta no tiene puntos asignados");
            return;
        }

        destinoActual = puntosDeRuta[indicePuntoActual];
    }

    private void OnEnable()
    {
        if (puntosDeRuta.Count > 0)
        {
            corrutinaPatrulla = StartCoroutine(PatrullarYEsperar());
        }
    }

    private void OnDisable()
    {
        if (corrutinaPatrulla != null)
        {
            StopCoroutine(corrutinaPatrulla);
        }
    }

    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            agent.SetDestination(destinoActual);
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance);
            CalcularNuevoDestino();
        }
    }

    private void CalcularNuevoDestino()
    {
        indicePuntoActual = (indicePuntoActual + 1) % puntosDeRuta.Count;
        destinoActual = puntosDeRuta[indicePuntoActual];
    }


    private void FixedUpdate()
    {
        Collider[] collsDetectados =Physics.OverlapSphere(transform.position, rangoVision, queEsTarget);
        if(collsDetectados.Length >0)
        {
            Debug.Log("Dentro Del Circulo");
            Vector3 direccionATarget = (collsDetectados[0].transform.position - transform.position).normalized;

            if (!Physics.Raycast(transform.position, direccionATarget, rangoVision, queEsObstaculo))
            {
                Debug.Log("Hay un obstaculo");
                if (Vector3.Angle(transform.forward, direccionATarget) <= anguloVision / 2)
                {
                    this.enabled = false;
                    Debug.Log("Visto");
                }
            }
        }
    }
}