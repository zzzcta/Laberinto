using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMovement : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento = 1f; // 
    [SerializeField] private float alturaMovimiento = 0.5f;  // Para el movimiento vertical y rotacion de la fresa
    [SerializeField] private float velocidadRotacion = 50f;  //

    private Vector3 posicionInicial; // Guarda la posición inicial de la fresa
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento de subir y bajar usando Mathf.Sin
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadMovimiento) * alturaMovimiento;
        transform.position = new Vector3(posicionInicial.x, nuevaY, posicionInicial.z);
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime); //Rotacion alrededor del eje Y
    }
}
