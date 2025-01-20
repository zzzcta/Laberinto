
using UnityEngine;
using Unity.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        
        foreach (Sound s in Sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;   
        }
    }

    public void Play(string name) 
    {
       Sound s = Array.Find(Sounds,Sound => Sound.Name == name);
       s.source.Play();
    }
}
