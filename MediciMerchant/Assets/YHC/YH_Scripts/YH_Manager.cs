using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YH_Manager : MonoBehaviour
{
    public static YH_Manager instance;
    public YH_InvenManager invenManager;

    public int currentRoom;

    private void Awake()
    {
        if (instance != this)
            instance = this;
    }
}
