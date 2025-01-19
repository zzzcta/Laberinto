using UnityEngine;

public class Puertas : MonoBehaviour
{
    [SerializeField] private GameEventSO gE;
    [SerializeField] private int idPuerta;

    private bool abrir = false;
    private void OnEnable()
    {
        gE.OnBaldosaPulsada += Abrir;
    }

    private void OnDisable()
    {
        gE.OnBaldosaPulsada -= Abrir; 
    }
    private void Abrir(int idBaldosa) 
    {
        if(idBaldosa == idPuerta)  
        {
            abrir = true;
        }
    }

    void Update() 
    {
        if (abrir) 
        {
            transform.Translate(Vector3.back * 5 * Time.deltaTime);
        }
    }
}
