using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Settingmenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetQuality(int qualityIndex)
    {
        if(qualityIndex == 0)
        {
            qualityIndex = 2;
        }
        if(qualityIndex == 2) { 
            qualityIndex= 0;
        }
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

