using System;
using UnityEngine;

public class SoundManager : TekilYonetici<SoundManager>
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public event Action<string> OnSoundRequested;
    void Start() => OnSoundRequested += PlaySound;
    void OnDestroy() => OnSoundRequested -= PlaySound;

    public void RequestSound(string clipName) => OnSoundRequested?.Invoke(clipName);
    public void PlaySound(string clipName)
    {
        AudioClip clip = Array.Find(audioClips, x => x.name == clipName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Sound clip not found: " + clipName);
        }
    }
}