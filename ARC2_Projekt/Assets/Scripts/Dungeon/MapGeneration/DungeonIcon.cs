using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonIcon : MonoBehaviour
{
    public string iconName, iconType;

    public void SetIconName(string name)
    {
        iconName = name;
        SetIconType(iconName);
    }

    public void SetIconType(string name)
    {

        switch (name)
        {
            case "Skull":
                iconType = "Bad";
                break;
            case "Devil":
                iconType = "Bad";
                break;
            case "Sadness":
                iconType = "Bad";
                break;
            case "Altar":
                iconType = "Neutral";
                break;
            case "Exit":
                iconType = "Neutral";
                break;
            case "Event":
                iconType = "Neutral";
                break;
            case "Messenger":
                iconType = "Neutral";
                break;
            case "Treasuer":
                iconType = "Good";
                break;
            case "Cross":
                iconType = "Good";
                break;
            case "Torch":
                iconType = "Good";
                break;
        }
    }

}
