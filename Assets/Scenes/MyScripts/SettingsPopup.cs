using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private AudioClip sound;

    void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        Managers.Audio.PlaySound(sound);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnSubmitName(string name)
    {
        Debug.Log(name);
        Managers.Audio.PlaySound(sound);
    }

    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        Debug.Log("Speed: " + speed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }

    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnSoundValue(float volume)
    {
        Managers.Audio.soundVolume = volume;
    }

    public void OnMusicToggle()
    {
        Managers.Audio.musicMute = !Managers.Audio.musicMute;
        Managers.Audio.PlaySound(sound);
    }

    public void OnMusicValue(float volume)
    {
        Managers.Audio.musicVolume = volume;
    }

    public void OnPlayMusic(int selector)
    {
        Managers.Audio.PlaySound(sound);

        switch(selector)
        {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }
}
