using UnityEngine;
public class Puertas : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    [SerializeField] private int idPuerta;

    private bool abrir = false;
    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private float progreso = 0f;
    private float velocidad = 0.5f;

    private void OnEnable()
    {
        gE.OnBaldosaPulsada += Abrir;
    }

    private void OnDisable()
    {
        gE.OnBaldosaPulsada -= Abrir; 
    }

    private void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = posicionInicial + Vector3.down * 5f; // Se mueve 5 unidades hacia abajo
    }

    private void Update()
    {
        if (abrir && progreso < 1f)
        {
            progreso += Time.deltaTime * velocidad;
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, progreso);
        }
    }
    private void Abrir(int idBaldosa) 
    {
        if(idBaldosa == idPuerta)  
        {
            abrir = true;
        }
    }
}