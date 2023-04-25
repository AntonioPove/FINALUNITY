using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource policeAudio;
    [SerializeField]
    AudioSource explosionSound;
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

    public void Destruction(int i)
    {
        destructions[i].Play();
    }
}
