using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonIcon : MonoBehaviour
{
    public string iconName, iconType;
    public int icon_lvl = 0;

    public void SetIconName(string name, int icon_lvl)
    {
        iconName = name;
        this.icon_lvl = icon_lvl;
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
            case "Treasure":
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

    public void Action()
    {
        GameObject.Find("MapManager").GetComponent<MapGeneration>().AfterAction();
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.transform.Find("GrayDirt").gameObject.SetActive(true);
        gameObject.transform.Find("Dirt").gameObject.SetActive(false);
    }

    public void Disable()
    {
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.transform.Find("GrayDirt").gameObject.SetActive(true);
        gameObject.transform.Find("Dirt").gameObject.SetActive(false);
    }

}
