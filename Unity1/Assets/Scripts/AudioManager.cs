using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource policeAudio;
    [SerializeField]
    AudioSource explosionSound, shootSound;
    [SerializeField]
    AudioSource[] destructions;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void Police()
    {
        policeAudio.Play();
    }

    public void Explosion()
    {
        explosionSound.Play();
    }

    public void Shoot()
    {
        shootSound.Play();
    }

    public void Destruction(int i)
    {
        if(!destructions[i].isPlaying)
        destructions[i].Play();
    }
}
