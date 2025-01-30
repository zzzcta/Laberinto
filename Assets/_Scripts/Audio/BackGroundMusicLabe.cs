using UnityEngine;

public class BackGroundMusicLabe : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            audioManager.PlayLoopingSound("BackgroundLaberinto");
        }
    }
}