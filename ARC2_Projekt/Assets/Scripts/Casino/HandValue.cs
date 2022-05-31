using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandValue : MonoBehaviour
{
    public Text Value;
    public int value;

    public void AssignInfoAs(){
        Value.text = value.ToString() + "/" + (value + 10).ToString();
    }

    public void AssignInfo(){
        Value.text = value.ToString();
    }
}
