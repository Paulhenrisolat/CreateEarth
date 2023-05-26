using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundScript
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume; //volume of the sound
    [Range(.1f, 3f)]
    public float pitch; //speed of the sound

    public bool loop; //loop to play an infinite time the sound

    [HideInInspector]
    public AudioSource source;
}
