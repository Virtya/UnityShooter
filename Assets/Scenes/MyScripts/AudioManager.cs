using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSource;
    public ManagerStatus status { get; private set; }
    public float soundVolume { 
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Audio manager starting...");

        _network = service;

        soundVolume = 0.3f;

        status = ManagerStatus.Started;
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
