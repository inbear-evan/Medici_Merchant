using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Cjj_Enemy : MonoBehaviour
{
    public float currenttime = 0;
    public float time = 5;
    //
    public GameObject SmokeScreen;
    public GameObject Coin;
    public Animator anim;
    public AudioSource dieSource, hitSource, boomSource, moneySource;

    Camera cam;   
    public bool nohit = false;
    // Start is called before the first frame update
    void Start()
    {
        //
        anim = GetComponent<Animator>();
        nohit = false;
        cam = Camera.main;
        //cam = GetComponent<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneySteal();
        //
        transform.LookAt(Cjj_Player.instance.transform.position);
    }

    //public GameObject damages;
    void PlayerMoneySteal()
    {
        currenttime = currenttime + Time.deltaTime;
        if (currenttime >= time)
        {
            /*//여기에 돈을 빼았는 그림?
            GameObject damageimage = Instantiate(damages);
            damageimage.transform.position = transform.position;
            // 플레이어의 돈을 빼았는다
            YH_InvenManager.instance.gold = YH_InvenManager.instance.gold - (YH_InvenManager.instance.gold / 10);
            // 그리고 사라진다
            Destroy(gameObject);*/

            nohit = true;
            if (enemyHP.HP > 0)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("die") && enemyHP.HP != 0)
                {
                    //돈을 빼았는 애니매이션
                    anim.SetTrigger("attack");

                    // 플레이어의 돈을 빼았는다
                    YH_InvenManager.instance.gold = YH_InvenManager.instance.gold - (YH_InvenManager.instance.gold / 10);
                }
            }
        }
    }
    public void hitpos()
    {
        Vector3 pos = cam.transform.position + (cam.transform.forward * 2f);
        transform.position = new Vector3(pos.x, transform.position.y, pos.z);
    }
    public void stealdie()
    {
        Destroy(gameObject);
        // 비웃음 사운드
    }
    public void smoke()
    {
        GameObject smokescreen = Instantiate(SmokeScreen);
        smokescreen.transform.position = transform.position;
        // 펑터지는 효과음
        boomSource.Play();
    }
    public void EnemyHit()
    {
        if (enemyHP.HP > 0)
        {
            anim.SetTrigger("hit");
            // 맞는 효과음
            hitSource.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        count = 1;
        nohit = false;
        Cjj_Player.instance.enemynumber--;
    }
    public int count = 1;
    public Cjj_EnemyHp enemyHP;
    internal void DoDamage(int damage)
    {
        enemyHP.HP -= damage;
        if (enemyHP.HP <= 0)
        {
            if (count == 1)
            {
                anim.SetTrigger("die");
                // 죽는 애니메이션
                count++;
            }
            Destroy(gameObject, 7);
        }
    }
    public void coin()
    {
        float x = 0;
        float z = -1.2f;
        float y = 1f;

        Vector3 origin = new Vector3(x, y, z);

        GameObject Coins = Instantiate(Coin);
        Coins.transform.position = transform.position + origin;

        YH_InvenManager.instance.gold = YH_InvenManager.instance.gold + 50;

        moneySource.Play();
    }
    public void DieSource()
    {
        dieSource.Play();
    }
}