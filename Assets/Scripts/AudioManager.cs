using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.pitch = sound.pitch;
            sound.source.volume = sound.volume;
        }   
    }

    public bool IsPlaying(string nameOfSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameOfSound);
        return s.source.isPlaying;
    }

    public void Play(string nameOfSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameOfSound);
        s.source.Play();
    }

    public void Loop(string nameOfSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameOfSound);
        s.source.loop = true;
        s.source.Play();
    }

    public void Stop(string nameOfSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameOfSound);
        s.source.Stop();
    }
}
