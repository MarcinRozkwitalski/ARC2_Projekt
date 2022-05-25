using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    GameObject Door_01, Door_02, Door_03;
    public DoorCounter doorCounter;
    public DoorRandomizer doorRandomizer;
    Text DoorCounterText; 
    public string DoorValue;

    void Start()
    {
        Door_01 = GameObject.Find("Door_01");
        Door_02 = GameObject.Find("Door_02");
        Door_03 = GameObject.Find("Door_03");
        doorCounter = GameObject.Find("DoorHandler").GetComponent<DoorCounter>();
        doorRandomizer = GameObject.Find("DoorHandler").GetComponent<DoorRandomizer>();
        DoorCounterText = GameObject.Find("DoorCounterText").GetComponent<Text>();
        DoorCounterText.text = "Door counter:\n" + doorCounter.DoorCounterNumber.ToString();
        Randomize();
    }

    public void CheckDoor()
    {
        CheckText();
        UpdateDoorCounter();
    }

    public void CheckText()
    {
        DoorValue = this.transform.GetChild(0).GetComponent<Text>().text;

        switch (DoorValue)
        {
            case "1":
                Debug.Log("jeden");
                break;
            case "2":
                Debug.Log("dwa");
                break;
            case "3":
                Debug.Log("trzy");
                break;
            default:
                break;
        }
    }

    public void UpdateDoorCounter()
    {
        doorCounter.DoorCounterNumber++;
        DoorCounterText.text = "Door counter:\n" + doorCounter.DoorCounterNumber.ToString();
    }

    public void Randomize()
    {
        doorRandomizer.RandomizeDoors();
        Door_01.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[0];
        Door_02.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[1];
        Door_03.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[2];
    }
}