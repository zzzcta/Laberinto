using UnityEngine;

public class Carrot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       Destroy(gameObject);
    }
}
