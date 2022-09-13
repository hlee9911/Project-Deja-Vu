using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;

    [SerializeField] private TextMeshProUGUI volumeTextUI = null;

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    void Start()
    {
        LoadValue();
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeValue", volumeValue);
        LoadValue();
    }
    
    void LoadValue()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

}
