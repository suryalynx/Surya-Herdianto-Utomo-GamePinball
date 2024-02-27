using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public GameObject sfxBumper;
    public GameObject sfxSwitchOn;
    public GameObject sfxSwitchOff;
    private void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        bgmAudioSource.Play();
    }
    public void SfxBumper(Vector3 spawnPosition)
    {
        GameObject sfxB = Instantiate(sfxBumper, spawnPosition, Quaternion.identity);
    }
    public void SfxSwitchOn(Vector3 spawnPosition)
    {
        GameObject sfxSon = Instantiate(sfxSwitchOn, spawnPosition, Quaternion.identity);
    }
    public void SfxSwitchOff(Vector3 spawnPosition)
    {
        GameObject sfxSoff = Instantiate(sfxSwitchOff, spawnPosition, Quaternion.identity);
    }
}
