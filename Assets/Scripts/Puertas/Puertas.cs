using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int idPuerta;

    private bool abrir = false;
    // Start is called before the first frame update
    void Start()
    {
        gM.OnBaldosaPulsada += Abrir;
    }

    private void Abrir(int idBaldosa)
    {
        if(idBaldosa == idPuerta)
        {
            abrir = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (abrir)
        {
            transform.Translate(Vector3.back * 5 * Time.deltaTime);
        }
    }
}
