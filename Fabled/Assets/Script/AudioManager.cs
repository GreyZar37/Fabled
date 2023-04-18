using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static AudioSource sfxSource;
    public static AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        sfxSource = GetComponentInChildren<AudioSource>();
    }
    public static void playSound(AudioClip[] clip, float volume)
    {
        sfxSource.PlayOneShot(clip[Random.Range(0, clip.Length)], volume);
    }
    public static void playSound(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }
}
