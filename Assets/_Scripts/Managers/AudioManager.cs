
using UnityEngine;
using Unity.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sfxSounds;

    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)   //Singleton
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sfxSounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name) 
    {
       Sound s = Array.Find(sfxSounds,Sound => Sound.Name == name);
       s.source.Play();
    }

    public void PlayLoopingSound(string name)
    {
        Sound s = Array.Find(sfxSounds, Sound => Sound.Name == name);

        if (!s.source.isPlaying)  // Si no está sonando, lo inicia
        {
            s.source.loop = true;
            s.source.PlayOneShot(s.clip);
        }
    }
}
