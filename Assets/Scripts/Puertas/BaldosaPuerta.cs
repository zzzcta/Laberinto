using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldosaPuerta : MonoBehaviour
{

    [SerializeField] private GameManagerSO gM;
    [SerializeField] private int idBaldosa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gM.BaldosaPulsada(idBaldosa);
        }
    }
}
