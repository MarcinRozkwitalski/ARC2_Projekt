using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public Text CardName;
    public Text Type;
    public Text Description;
    public Text Price;
    public Text Points;

    public string cardname;
    public string type;
    public string description;
    public int price;
    public int points;

    void Start()
    {
        CardName.text = cardname;
        Type.text = type;
        Description.text = description;
        Price.text = price.ToString();
        Points.text = points.ToString();

    }
}
