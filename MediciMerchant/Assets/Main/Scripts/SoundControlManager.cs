using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControlManager : MonoBehaviour
{
    public Slider BGMSldier;
    public Slider effectSldier;

    public GameObject naplesStore;
    public AudioSource NaMarketSound;
    public AudioSource NaShipSound;
    public AudioSource NaWaveSound;
    public AudioSource NaBGSound;

    public GameObject romeStore;
    public AudioSource romeBGMSound;
    public AudioSource romeSound;
    public AudioSource romePersonSound;
    public AudioSource romeLoudSound;

    public AudioSource pencilX;

    public GameObject florenceStore;
    public AudioSource florenceBGMSound;

    public AudioSource mainSound;

    public GameObject veniceStore;
    public AudioSource veniceBGMSound;

    public GameObject MilanStore;
    public AudioSource MilanBGMSound;

    public AudioSource btnSound;

    float currentTime = 0;
    // Update is called once per frame
    private void Start()
    {
        if (PlayerPrefs.HasKey("effectVolume")) effectSldier.value = PlayerPrefs.GetFloat("effectVolume");
        if (PlayerPrefs.HasKey("bgmVolume")) BGMSldier.value = PlayerPrefs.GetFloat("bgmVolume");
    }
    void Update()
    {
        float BGMvalue = BGMSldier.value;
        float effectValue = effectSldier.value;

        if(naplesStore.activeSelf || romeStore.activeSelf || florenceStore.activeSelf) mainSound.volume = 0;
        else mainSound.volume = BGMvalue;
        currentTime += Time.deltaTime;
        if (naplesStore.activeSelf)
        {
            if (!NaMarketSound.isPlaying) NaMarketSound.Play();
            if (!NaShipSound.isPlaying && currentTime >= 30)
            {
                NaShipSound.Play();
                currentTime = 0;
            }
            if (!NaWaveSound.isPlaying) NaWaveSound.Play();
            if (!NaBGSound.isPlaying) NaBGSound.Play();

            NaMarketSound.loop = true;
            //shipSound.loop = true;
            NaWaveSound.loop = true;
            NaBGSound.loop = true;

            NaMarketSound.volume = effectValue;
            NaWaveSound.volume = effectValue;
            NaShipSound.volume = effectValue;
            NaBGSound.volume = BGMvalue;
        }
        else
        {
            NaMarketSound.Stop();
            NaShipSound.Stop();
            NaWaveSound.Stop();
            NaBGSound.Stop();

            NaMarketSound.loop = false;
            //NaShipSound.loop = false;
            NaWaveSound.loop = false;
            NaBGSound.loop = false;
        }

        if (romeStore.activeSelf)
        {
            if (!romeLoudSound.isPlaying && currentTime >= 30)
            {
                romeLoudSound.Play();
                currentTime = 0;
            }
            if (!romeBGMSound.isPlaying) romeBGMSound.Play();
            if(!romeSound.isPlaying) romeSound.Play();
            if(!romePersonSound.isPlaying) romePersonSound.Play();

            romeSound.volume = effectValue;
            romeLoudSound.volume = effectValue;
            romePersonSound.volume = effectValue;
            romeBGMSound.volume = BGMvalue;

            romePersonSound.loop = true;
            romeSound.loop = true;
            romeBGMSound.loop = true;
        }
        else
        {
            romeSound.Stop();
            romePersonSound.Stop();
            romeBGMSound.Stop();
            romeLoudSound.Stop();
            
            romeSound.loop = false;
            romePersonSound.loop = false;
            romeBGMSound.loop = false;
        }

        if (florenceStore.activeSelf)
        {
            
            if (!florenceBGMSound.isPlaying) florenceBGMSound.Play();

            florenceBGMSound.volume = BGMvalue;

            florenceBGMSound.loop = true;
        }
        else
        {
            florenceBGMSound.Stop();
            florenceBGMSound.loop = false;
        }

        if (veniceStore.activeSelf)
        {
            if (!veniceBGMSound.isPlaying) veniceBGMSound.Play();
            veniceBGMSound.volume = BGMvalue;
            veniceBGMSound.loop = true;
        }
        else
        {
            veniceBGMSound.Stop();
            veniceBGMSound.loop = false;
        }

        if (MilanStore.activeSelf)
        {
            if (!MilanBGMSound.isPlaying) MilanBGMSound.Play();
            MilanBGMSound.volume = BGMvalue;
            MilanBGMSound.loop = true;
        }
        else
        {
            MilanBGMSound.Stop();
            MilanBGMSound.loop = false;
        }
    }

    public void OnWriteSound()
    {
        pencilX.Stop();
        pencilX.Play();
    }

    public void CommonBtnSound()
    {
        btnSound.Play();
    }
}
