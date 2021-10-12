using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DestinationBtn : MonoBehaviour
{
    public GameObject DpPanel;
    public Sprite[] markers;
    public Image markerImg;
    public GameObject cam;
    public int destinationIndex = -1;
    public Image[] itemImg;
    public TMP_Text destText;
    // Start is called before the first frame update
    void Start()
    {
        DpPanel.SetActive(false);
        markerImg.gameObject.SetActive(false);
        itemImg[0].gameObject.SetActive(false);
        itemImg[1].gameObject.SetActive(false);
        itemImg[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void InitSettings()
    {
        destinationIndex = -1;
        markerImg.gameObject.SetActive(false);
        itemImg[0].gameObject.SetActive(false);
        itemImg[1].gameObject.SetActive(false);
        itemImg[2].gameObject.SetActive(false);
        destText.text = "¸ñÀûÁö";
        cam.GetComponent<FindPosition>().destination = null;
    }

    public void OpenDestinationPanel()
    {
        Time.timeScale = 0;
        DpPanel.SetActive(true);
        //if(cam.GetComponent<FindPosition>().markerIndex != -1)
        //{
        //    DpPanel.transform.GetChild(1).GetChild(cam.GetComponent<FindPosition>().markerIndex).GetComponent<Image>().color = new Color(255, 155, 0);
        //}
    }

    public void CloseDestinationPanel()
    {
        Time.timeScale = 1;
        InitSettings();
        //if (cam.GetComponent<FindPosition>().markerIndex != -1)
        //{
        //    DpPanel.transform.GetChild(1).GetChild(cam.GetComponent<FindPosition>().markerIndex).GetComponent<Image>().color = new Color(255, 255, 255);
        //    cam.GetComponent<FindPosition>().markerIndex = -1;
        //}
        DpPanel.SetActive(false);
    }
    public void OnclickSpriteChange()
    {
        for (int i = 0; i < markers.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.name == markers[i].name)
            {
                markerImg.gameObject.SetActive(true);
                markerImg.sprite = markers[i];
                markerImg.transform.GetChild(0).GetComponent<TMP_Text>().text = markers[i].name;
                itemImg[0].gameObject.SetActive(true);
                itemImg[1].gameObject.SetActive(true);
                itemImg[2].gameObject.SetActive(true);
                destText.text = markers[i].name;
                destinationIndex = i;
            }
        }
    }

    public void SetDesitionaion()
    {
        cam.GetComponent<FindPosition>().destination = cam.GetComponent<FindPosition>().mediciMap.transform.GetChild(0).GetChild(destinationIndex);
        CloseDestinationPanel();
    }
}
