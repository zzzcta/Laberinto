using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaTecho : MonoBehaviour
{
    [SerializeField] private float velocidadTecho = 0.1f;

    private Vector3 posicionInicial;
    void Start()
    {
        posicionInicial = transform.position;
    }
    void Update()
    {
        
            transform.position -= new Vector3(0, velocidadTecho * Time.deltaTime, 0);
            
  
    }
}
