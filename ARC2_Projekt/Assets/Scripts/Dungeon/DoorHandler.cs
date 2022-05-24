using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public Text DoorCounterText; 
    public int DoorCounter;
    public string DoorValue;

    //skarb, czaszka, plomien, glowa_diabla, krzyz, usmiech, smutek//

    void Start()
    {
        DoorCounter = 0; //need to put that in one object so three objects wont have seperate counters
        DoorCounterText.text = "0";
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
        DoorCounter++;
        DoorCounterText.text = DoorCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
