using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBtnManager : MonoBehaviour
{
    public Button startBtn;
    public Button reStartBtn;
    public Button followBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        startBtn.gameObject.SetActive(true);
        reStartBtn.gameObject.SetActive(false);
        followBtn.gameObject.SetActive(false);   
    }

    public void OnClickStartBtn()
    {
        startBtn.gameObject.SetActive(false);
        reStartBtn.gameObject.SetActive(true);
        followBtn.gameObject.SetActive(true);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }


    public void PlayBtn()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
