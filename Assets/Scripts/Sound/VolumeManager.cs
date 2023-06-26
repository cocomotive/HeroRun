using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;

    public AudioManager audioManager;

    public float upVolume;


    private void Start()
    {
    }

    private void Update()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        //masterSlider.value = upVolume;
    }

    public void SetVolume()
    {
        float volume = masterSlider.value;
        upVolume = masterSlider.value;
        myMixer.SetFloat("master", volume);
        audioManager.UpdateVol();
    }





}
