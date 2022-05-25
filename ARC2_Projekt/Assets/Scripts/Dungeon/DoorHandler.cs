using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public DoorCounter doorCounter;
    Text DoorCounterText; 
    public string DoorValue;

    //skarb, czaszka, plomien, glowa_diabla, krzyz, usmiech, smutek//

    void Start()
    {
        doorCounter = GameObject.Find("DoorCounterHandler").GetComponent<DoorCounter>();
        DoorCounterText = GameObject.Find("DoorCounterText").GetComponent<Text>();
        DoorCounterText.text = "Door counter:\n" + doorCounter.DoorCounterNumber.ToString();
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

    void Update()
    {
        
    }
}
