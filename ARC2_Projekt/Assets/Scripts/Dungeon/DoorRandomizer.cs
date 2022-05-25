using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRandomizer : MonoBehaviour
{
    GameObject Door_01, Door_02, Door_03;

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
        "usmiech",
        "smutek"
    };
    
    void Start()
    {
        Door_01 = GameObject.Find("Door_01");
        Door_02 = GameObject.Find("Door_02");
        Door_03 = GameObject.Find("Door_03");
    }

    public void RandomizeDoors()
    {
        for (int i = 0; i < 3; i++)
        {
            doors[i] = doorValues[Random.Range(0,(doorValues.Length))];
        }
    }
}
