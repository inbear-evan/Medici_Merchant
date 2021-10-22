using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NEXTLEVEL : MonoBehaviour
{
    AnimationCurve ac;
    public TMP_Text OriginGold;
    public GameObject LEVEL1, LEVEL2, LEVEL3;
    public Text Gold;
    float time;
    int gold, Ogold, m = 1;
    public GameObject levelUpBtn;
    int level1_value = 15000;
    int level2_value = 20000;
    //public Text level;

    // 상점에서 1초에 1원씩 들어오게 하고 싶다.
    // OriginGold 가 1000원 이상일때 상점의 레벨을 2로 올릴 수 있게 하고싶다. 
    // 레벨 2 일때 상점에서 들어오는 수입이 2배가 되게 하고 싶다.
    // 쌓인 돈을 클릭하면 OriginGold 로 가져가고 싶다.
    // OriginGold 가 2000원 이상일 때 상점의 레벨을 3으로 올리고 1초에 3원씩

    // Start is called before the first frame update
    void Start()
    {
        levelUpBtn.gameObject.SetActive(false);
        LEVEL1.SetActive(true);
        LEVEL2.SetActive(false);
        LEVEL3.SetActive(false);
        //Gold.text = "100";
         //OriginGold.text = Ogold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Ogold = YH_InvenManager.instance.gold;
        Gold.text = gold.ToString();
        time += Time.deltaTime;
        if (time >= 1)
        {
            gold += m;
            time = 0;
        }

        if (Ogold >= level1_value && m == 1)
        {
            levelUpBtn.gameObject.SetActive(true);
        }
        if (m == 2 && Ogold >= level2_value)
        {
            levelUpBtn.gameObject.SetActive(true);
        }
        //OriginGold.text = Ogold.ToString();

        //level.text = m.ToString();

        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            //if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                int layer = 1 << LayerMask.NameToLayer("LEVELUP");
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 100.0f, layer))
                {
                    if (m == 1 && Ogold >= level1_value)
                    {
                        LEVEL1.SetActive(false);
                        LEVEL2.SetActive(true);
                        Ogold -= level1_value;
                        m = 2;
                        levelUpBtn.gameObject.SetActive(false);
                        //print("Level = " + m);
                    }
                    else if (m == 2)
                    {
                        print("Check " + m);

                        if (Ogold >= level2_value)
                        {
                            //print("Level 2 " + m);
                            LEVEL1.SetActive(false);
                            LEVEL2.SetActive(false);
                            LEVEL3.SetActive(true);
                            Ogold -= level2_value;
                            m = 3;
                            levelUpBtn.gameObject.SetActive(false);
                        }

                    }
                }
            }
        }
    }

    public void GIVEMEGOLD()
    {
        //Debug.Log(Ogold + " " + gold);
        Ogold += gold;
        gold = 0;
        YH_InvenManager.instance.gold = Ogold;
        //OriginGold.text = Ogold.ToString();
        //OriginGold.text = (Ogold + gold).ToString();
        //gold = 0; 
    }
    public void LevelUp()
    {
        //if (Ogold >= 20)
        //{
        //    LEVEL1.SetActive(false);
        //    LEVEL2.SetActive(false);
        //    LEVEL3.SetActive(true);
        //    levelUpBtn.gameObject.SetActive(false);
        //    m = 3;
        //}
        if (Ogold >= level1_value && m == 1)
        {
            LEVEL1.SetActive(false);
            LEVEL2.SetActive(true);
            Ogold -= level1_value;
            m = 2;
            levelUpBtn.gameObject.SetActive(false);
        }
        if (Ogold >= level2_value && m == 2)
        {
            LEVEL1.SetActive(false);
            LEVEL2.SetActive(false);
            LEVEL3.SetActive(true);
            Ogold -= level2_value;
            m = 3;
            levelUpBtn.gameObject.SetActive(false);
        }

    }
}
