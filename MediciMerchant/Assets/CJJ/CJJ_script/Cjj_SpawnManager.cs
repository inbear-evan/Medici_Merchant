using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cjj_SpawnManager : MonoBehaviour
{
    public GameObject EnemySpawn;
    public float currenttime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currenttime = currenttime + Time.deltaTime;
        if (currenttime >= 30)
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
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Cjj_Player.instance.EnemyEvent();
        }
    }

    private void OnDestroy()
    {
        Cjj_CloudSpawnManager.instance.spawnnumber--;
    }
}
