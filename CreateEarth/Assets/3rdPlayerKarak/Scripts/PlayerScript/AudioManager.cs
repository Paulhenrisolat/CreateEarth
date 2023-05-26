using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public SoundScript[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
         foreach(SoundScript s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        Play("MusicTheme");
    }

    public void Play(string name)
    {
        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
