using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cjj_SpawnManager : MonoBehaviour
{
    public GameObject EnemySpawn;
    public float currenttime = 0;

    TMP_Text ttt;//test

    // Start is called before the first frame update
    void Start()
    {
        ttt = GameObject.Find("CHECK").GetComponent<TMP_Text>(); //test
    }

    // Update is called once per frame
    void Update()
    {
        currenttime = currenttime + Time.deltaTime;
        if (currenttime >= 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("MainCamera"))
        {
            
            ttt.text = "Collusion";//test
            Destroy(gameObject,2);
            Cjj_Player.instance.EnemyEvent();
        }
    }
    
    private void OnDestroy()
    {
        Cjj_CloudSpawnManager.instance.spawnnumber--;
        ttt.text = "";//test
    }
}
