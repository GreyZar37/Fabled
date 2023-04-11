using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{
    public static AudioSource sfxSource;
    private void Start()
    {
        sfxSource = GetComponent<AudioSource>();
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
