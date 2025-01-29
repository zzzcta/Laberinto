using UnityEngine;

public class MusicaMuerte : MonoBehaviour
{
    private void Awake()
    {
        FindAnyObjectByType<AudioManager>().Play("GameOver");
    }
}
