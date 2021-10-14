using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using TMPro;

public class DestinationBtn : MonoBehaviour
{
    public GameObject DpPanel;
    public Sprite[] markers;
    public Image markerImg;
    public GameObject cam;
    public int destinationIndex = -1;
    public Image[] itemShowImg;
    public Sprite[] naplesImtemImg;
    public Sprite[] romeImtemImg;
    public Sprite[] veniceImtemImg;
    public Sprite[] milanImtemImg;
    public Sprite[] florenceImtemImg;
    public TMP_Text destText;
    public Slider pathStatus;
    public Image destCheckPinImg;
    public Sprite[] destCheckPin;

    string[] countryName;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DpPanel.SetActive(false);
        destCheckPinImg.gameObject.SetActive(false);
        markerImg.gameObject.SetActive(false);
        for (int ic = 0; ic < 3; ic++)
        {
            itemShowImg[ic].gameObject.SetActive(false);
        }
        pathStatus.gameObject.SetActive(false);
        countryName = new string[5];
        countryName[0] = "나폴리";
        countryName[1] = "로마";
        countryName[2] = "베네치아";
        countryName[3] = "밀라노";
        countryName[4] = "피렌체";
    }

    // Update is called once per frame
    public void InitSettings()
    {
        destinationIndex = -1;
        markerImg.gameObject.SetActive(false);
        destCheckPinImg.gameObject.SetActive(false);
        for (int ic = 0; ic < 3; ic++)
        {
            itemShowImg[ic].gameObject.SetActive(false);
        }
        pathStatus.gameObject.SetActive(false);
        destText.text = "목적지";
        cam.GetComponent<FindPosition>().destination = null;
    }

    public void OpenDestinationPanel()
    {
        Time.timeScale = 0;
        DpPanel.SetActive(true);
    }

    public void CloseDestinationPanel()
    {
        Time.timeScale = 1;
        InitSettings();
        DpPanel.SetActive(false);
    }

    public void OnclickSpriteChange()
    {
        for (int ic = 0; ic < 3; ic++)
        {
            itemShowImg[ic].gameObject.SetActive(true);
        }

        for (int i = 0; i < markers.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == markers[i].name)
            {
                markerImg.gameObject.SetActive(true);
                markerImg.sprite = markers[i];
                markerImg.transform.GetChild(0).GetComponent<TMP_Text>().text = countryName[i];
                destCheckPinImg.gameObject.SetActive(true);
                switch (i)
                {
                    case 0:
                        for (int ic = 0; ic < 3; ic++)
                        {
                            itemShowImg[ic].sprite = naplesImtemImg[ic];
                        }
                        break;
                    case 1:
                        for (int ic = 0; ic < 3; ic++)
                        {
                            itemShowImg[ic].sprite = romeImtemImg[ic];
                        }
                        break;
                    case 2:
                        for (int ic = 0; ic < 3; ic++)
                        {
                            itemShowImg[ic].sprite = veniceImtemImg[ic];
                        }
                        break;
                    case 3:
                        for (int ic = 0; ic < 3; ic++)
                        {
                            itemShowImg[ic].sprite = milanImtemImg[ic];
                        }
                        break;
                    case 4:
                        for (int ic = 0; ic < 3; ic++)
                        {
                            itemShowImg[ic].sprite = florenceImtemImg[ic];
                        }
                        break;

                }
                destText.text = markers[i].name;
                destinationIndex = i;
                destCheckPinImg.gameObject.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
                StopCoroutine(checkMarkerDraw());
                StartCoroutine(checkMarkerDraw());
                
                
            }
        }
    }
    IEnumerator checkMarkerDraw()
    {
        for(int i = 0; i < 2; i++)
        {
            destCheckPinImg.sprite = destCheckPin[i];
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

    public void SetDesitionaion()
    {
        cam.GetComponent<FindPosition>().destination = cam.GetComponent<FindPosition>().mediciMap.transform.GetChild(0).GetChild(destinationIndex);
        Time.timeScale = 1;
        DpPanel.SetActive(false);
    }
}
