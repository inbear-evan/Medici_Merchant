using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cjj_Player : MonoBehaviour
{
    public static Cjj_Player instance;
    public GameObject Enemy;
    public int enemynumber = 0;
    public int Money = 100;

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

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer = 1 << LayerMask.NameToLayer("Enemy");
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layer))
            {
                Cjj_Enemy enemy = hitInfo.transform.GetComponent<Cjj_Enemy>();
                enemy.DoDamage(1);
            }
        }

        /*Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began) 
        { 
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            int layer = 1 << LayerMask.NameToLayer("Enemy");
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layer))
            {
                print("아아아아아아");
            }
        }*/

    }
    public void EnemyEvent()
    {
        if (enemynumber < 1)
        {
            GameObject enemy = Instantiate(Enemy);
            enemy.transform.position = transform.position + transform.forward * 3;
            enemynumber++;
        }
    }
}
