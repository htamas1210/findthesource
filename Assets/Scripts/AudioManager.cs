using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Sound[] sounds;

    private void Awake() {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.outputMixer;
        }
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();
    }

    public void SetMainVolume(float mainVolume) {
        audioMixer.SetFloat("Master", mainVolume);
    }
    public void SetMusicVolume(float musicVolume) {
        audioMixer.SetFloat("Music", musicVolume);
    }
    public void SetSfxVolume(float sfxVolume) {
        audioMixer.SetFloat("Sfx", sfxVolume);
    }
}
