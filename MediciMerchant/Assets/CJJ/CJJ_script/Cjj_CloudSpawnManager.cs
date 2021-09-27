using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cjj_CloudSpawnManager : MonoBehaviour
{
    public static Cjj_CloudSpawnManager instance;
    public GameObject spawnmanager;
    public int spawnnumber = 0;

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
        if (spawnnumber <= 2)
        {
            GameObject enemyspawn = Instantiate(spawnmanager);
            enemyspawn.transform.position = EnemyRandomPosition();
            spawnnumber++;
        }
    }

    // 랜덤 위치값을 설정
    private Vector3 EnemyRandomPosition()
    {
        float px = transform.position.x;
        float pz = transform.position.z;
        float halfScaleX = transform.localScale.x * 0.5f;
        float halfScaleZ = transform.localScale.z * 0.5f;

        float minX = px - halfScaleX;
        float maxX = px + halfScaleX;

        float minZ = pz - halfScaleZ;
        float maxZ = pz + halfScaleZ;

        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        float y = transform.position.y;

        Vector3 origin = new Vector3(x, y, z);

        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit hitlnfo;
        if (Physics.Raycast(ray, out hitlnfo)) { }
        return hitlnfo.point;


    }
}
