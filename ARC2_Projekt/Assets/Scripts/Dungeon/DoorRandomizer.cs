using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRandomizer : MonoBehaviour
{
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