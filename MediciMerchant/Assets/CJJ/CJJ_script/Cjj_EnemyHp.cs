using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cjj_EnemyHp : MonoBehaviour
{
    public int hp;
    public int maxHP = 3;

    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
        }
    }
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
