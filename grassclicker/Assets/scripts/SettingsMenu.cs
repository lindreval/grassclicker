using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    public float musvol;
    public float sfxvol;
    
    public void ApplyVolumeSettings(){
        audioMixer.SetFloat("music", Mathf.Log10(musvol) * 20);
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxvol) * 20);
    }

    public void SetVolumeMusic(){
        musvol = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(musvol)*20);
    }

    public void SetVolumeSFX(){
        sfxvol = sfxSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxvol)*20);
    }
}
