using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        PlayerPrefs.SetFloat("musicVolume", 1);

        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple AudioManger Instances");
        }
        foreach (Sound sound in sounds)
        {
            AudioSource temp = gameObject.AddComponent<AudioSource>();
            temp.clip = sound.sound;
            temp.volume = sound.volume;
            temp.playOnAwake = false;
        }
    }

    private void Start()
    {
        Play("music");
    }

    public void Play(string name)
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        AudioClip tempClip = null;
        foreach(Sound sound in sounds)
        {
            if(sound.name.Equals(name))
            {
                tempClip = sound.sound;
                break;
            }
        }
        if(tempClip != null)
        {
            foreach (AudioSource asrc in audioSources)
            {
                if (asrc.clip == tempClip)
                {
                    asrc.Play();
                    return;
                }
            }
        }
        else
        {
            Debug.Log("Audio Clip failed to be found");
        }
        
    }

}
