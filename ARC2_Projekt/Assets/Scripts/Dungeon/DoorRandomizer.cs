using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRandomizer : MonoBehaviour
{
    GameObject Door_01, Door_02, Door_03;

    bool flag;

    public string[] doors = {
        "",
        "",
        ""
    };

    public string[] doorValues = {
        "skarb",
        "czaszka",
        "plomien",
        "glowaDiabla",
        "krzyz",
        "smutek",
        "usmiech"
    };
    
    void Start()
    {
        Door_01 = GameObject.Find("Door_01");
        Door_02 = GameObject.Find("Door_02");
        Door_03 = GameObject.Find("Door_03");
    }

    public void RandomizeDoors()
    {
        flag = false;

        for (int i = 0; i < 3; i++)
        {
            if (flag == false)  doors[i] = doorValues[Random.Range(0, (doorValues.Length - 1))];
            else                doors[i] = doorValues[Random.Range(0, (doorValues.Length - 2))];

            if(doors[i] == "usmiech") flag = true;
        }
    }
}