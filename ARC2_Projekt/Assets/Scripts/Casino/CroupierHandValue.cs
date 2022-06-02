using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CroupierHandValue : MonoBehaviour
{
    public Text Value;

    public int value;

    public int valueAs;

    public void AssignInfoAs()
    {
        valueAs = value + 10;
        Value.text = value.ToString() + "/" + (valueAs).ToString();
    }

    public void AssignInfo()
    {
        Value.text = value.ToString();
    }
}
