using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{

    static public SaveManager instance;
    public int[] item;
    public int gold;
    public int storeGold;
    public int storeGrade;
    public GameObject saveCheckUI;
    public Slider bgmVolume;
    public Slider effectVolume;

    private void Awake()
    {
        instance = this;
        item = new int[6];
        saveCheckUI.SetActive(false);
    }
    
    public void SavePlayerPrefab()
    {
        saveCheckUI.SetActive(true);
        PlayerPrefs.SetInt("item1", item[0]);
        PlayerPrefs.SetInt("item2", item[1]);
        PlayerPrefs.SetInt("item3", item[2]);
        PlayerPrefs.SetInt("item4", item[3]);
        PlayerPrefs.SetInt("item5", item[4]);
        PlayerPrefs.SetInt("item6", item[5]);
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("StoreGold", storeGold);
        PlayerPrefs.SetInt("StoreGrade", storeGrade);
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume.value);
        PlayerPrefs.SetFloat("effectVolume", effectVolume.value);
        PlayerPrefs.Save();
    }

    //public void ReadPlayerPrefab()
    //{
    //    item[0] = PlayerPrefs.GetInt("item1");
    //    item[1] = PlayerPrefs.GetInt("item2");
    //    item[2] = PlayerPrefs.GetInt("item3");
    //    item[3] = PlayerPrefs.GetInt("item4");
    //    item[4] = PlayerPrefs.GetInt("item5");
    //    item[5] = PlayerPrefs.GetInt("item6");
    //    gold = PlayerPrefs.GetInt("Gold");
    //    storeGold = PlayerPrefs.GetInt("StoreGold");
    //    storeGrade = PlayerPrefs.GetInt("StoreGrade");
    //}

    public void FindPathRestart()
    {
        PlayerPrefs.SetInt("item1", item[0]);
        PlayerPrefs.SetInt("item2", item[1]);
        PlayerPrefs.SetInt("item3", item[2]);
        PlayerPrefs.SetInt("item4", item[3]);
        PlayerPrefs.SetInt("item5", item[4]);
        PlayerPrefs.SetInt("item6", item[5]);
        PlayerPrefs.SetInt("Gold", gold);
        PlayerPrefs.SetInt("StoreGold", storeGold);
        PlayerPrefs.SetInt("StoreGrade", storeGrade);
        PlayerPrefs.SetFloat("bgmVolume", bgmVolume.value);
        PlayerPrefs.SetFloat("effectVolume", effectVolume.value);
        PlayerPrefs.Save();
        //SceneManager.LoadScene("StartScene2");
        //SceneManager.LoadScene("LoadingScene");
        SceneManager.LoadScene("MainScene");
    }
}
