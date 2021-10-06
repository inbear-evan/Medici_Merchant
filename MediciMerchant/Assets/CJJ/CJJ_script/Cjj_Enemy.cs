using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cjj_Enemy : MonoBehaviour
{
    public float currenttime = 0;
    public float time = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneySteal();
    }
    public GameObject damages;
    void PlayerMoneySteal()
    {
        currenttime = currenttime + Time.deltaTime;
        if (currenttime >= time)
        {
            //���⿡ ���� ���Ҵ� �׸�?
            GameObject damageimage = Instantiate(damages);
            damageimage.transform.position = transform.position;
            // �÷��̾��� ���� ���Ҵ´�
            YH_InvenManager.instance.gold = YH_InvenManager.instance.gold - (YH_InvenManager.instance.gold / 10);
            // �׸��� �������
            Destroy(gameObject);
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
        Cjj_Player.instance.enemynumber--;
    }

    public Cjj_EnemyHp enemyHP;
    internal void DoDamage(int damage)
    {
        enemyHP.HP -= damage;
        if (enemyHP.HP <= 0)
        {
            Destroy(gameObject);
        }

    }
}
