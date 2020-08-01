using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    new public string name;
    public AudioClip sound;
    public float volume;

    public Sound(string name, AudioClip sound, float volume)
    {
        this.name = name;
        this.sound = sound;
        this.volume = volume;
    }
}
