using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCounter : MonoBehaviour
{
    public int DoorCounterNumber;

    void Start()
    {
        var doorCounters = FindObjectsOfType<DoorCounter>();
        if(doorCounters.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
