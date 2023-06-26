using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public float sfxVolume;

    public VolumeManager volumeManager;

    [Header("----------AudioSource----------")]
    [SerializeField] AudioSource sfxSource;
    
    
    [Header("----------Clips----------")]
    public AudioClip coin;
    public AudioClip button;
    public AudioClip backBt;
    public AudioClip theme;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //PlaySfx(theme);
    }
    private void Update()
    {       
        
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void UpdateVol()
    {
        sfxVolume = volumeManager.upVolume;
    }
}
