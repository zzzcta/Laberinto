using UnityEngine;

public class Baldosa : MonoBehaviour
{
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           transform.position = new Vector3(initialPosition.x, -1, initialPosition.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        }
    }
}