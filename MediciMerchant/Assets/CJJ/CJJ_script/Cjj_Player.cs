
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cjj_Player : MonoBehaviour
{
    public static Cjj_Player instance;
    public GameObject Enemy;
    public int enemynumber = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    int layer = 1 << LayerMask.NameToLayer("Enemy");
        //    RaycastHit hitInfo;
        //    if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layer))
        //    {
        //        Cjj_Enemy enemy = hitInfo.transform.GetComponent<Cjj_Enemy>();
        //        enemy.DoDamage(1);
        //    }
        //}

        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                int layer = 1 << LayerMask.NameToLayer("Enemy");
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo, 10, layer))
                {
                    //print("아아아아아아");
                    hitInfo.transform.GetComponent<Cjj_Enemy>().DoDamage(1);

                }
            }
        }

    }
    public void EnemyEvent()
    {
        float x = Random.Range(-2, 2);
        float z = Random.Range(1, 2);
        float y = transform.position.y;

        Vector3 origin = new Vector3(x, y, z);
        if (enemynumber < 1)
        {
            GameObject enemy = Instantiate(Enemy);
            //enemy.transform.position = transform.position + transform.forward * 3;
            enemy.transform.position = transform.position + origin;
            enemynumber++;
        }
    }
}
