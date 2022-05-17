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
    public Text HealthPoints;
    public Text Id;

    public string cardname;
    public string type;
    public string description;
    public int price;
    public int points;
    public int healthPoints;
    public int id;

    public void AssignInfo()
    {
        CardName.text = cardname;
        Type.text = type;
        Description.text = description;
        Price.text = price.ToString();
        Points.text = points.ToString();
        HealthPoints.text = healthPoints.ToString();
    }
    public void Swap()
    {
        Debug.Log(cardname + " - " + id);
        // FindObjectOfType<Player>().AddCard();
    }
}
