using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEffect : MonoBehaviour
{
    public GameObject[] coinPrf;
    float spawnsTime;
    public float defaultTime = 0.05f;

    Touch touch;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CoinCreat();
                spawnsTime = 0;
            }
            //if (Input.GetMouseButton(0) && spawnsTime >= defaultTime)
            //{
            //    CoinCreat();
            //    spawnsTime =0;
            //}
        }
        spawnsTime += Time.deltaTime;

    }
    void CoinCreat()
    {
        int num = Random.Range(0, coinPrf.Length);
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
        GameObject eff = Instantiate(coinPrf[num], mPosition, Quaternion.identity);
        Destroy(eff, 1);
    }
}
