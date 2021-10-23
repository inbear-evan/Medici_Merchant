using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzzleSprite : MonoBehaviour
{
    // Start is called before the first frame update
   // public GameObject coinPrefab;
    // public Transform firePos;
    MeshRenderer muzzleFlash;

    private void Start()
    {
        muzzleFlash = GetComponentInChildren<MeshRenderer>();
    }

    Touch touch;
    Quaternion quaternion;
    // Update is called once per frame
    void Update()
    {

        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Fire();
            gameObject.transform.position = touch.position;
        }
    }

    private void Fire()
    {
        //Instantiate(coinPrefab, touch.position, quaternion);
        // Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        MuzzleCoin();
    }

    void MuzzleCoin()
    {
        Vector2 offset = new Vector2(Random.Range(0, 2) * 0.5f, Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;
    }
}
