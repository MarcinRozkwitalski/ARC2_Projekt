using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsInfo : MonoBehaviour
{
    public TMP_Text CardName;
    public Text Type;
    public Text Description;
    public Text Price;
    public Text Points;
    public Text HealthPoints;

    public string cardname;
    public string type;
    public string description;
    public int price;
    public int points;
    public int healthPoints;
    public int id;
    public bool is_equipped = false;


    public void AssignInfo()
    {
        CardName.text = cardname;
        Type.text = type;
        Description.text = description;
        Price.text = price.ToString();
        Points.text = points.ToString();
        HealthPoints.text = healthPoints.ToString();
    }

    public bool IsCardEquipped()
    {
        return is_equipped;
    }
    public void ShowCard()
    {
        Debug.Log("name - " + cardname + "\n id - " + id + "\n is_equipped - " + is_equipped);
        FindObjectOfType<Cards>().ShowCard(cardname, type, description, price, points, healthPoints, id, is_equipped);

    }
    public void CloseShowCard()
    {
        FindObjectOfType<Cards>().DestroyShowCard();
    }
    public void MoveCard()
    {
        FindObjectOfType<Cards>().MoveCard(id, is_equipped, type);
        CloseShowCard();
    }

    public void SellCard(){
        FindObjectOfType<Cards>().SellCardFromInventory(id,price,type,is_equipped);
        CloseShowCard();
    }

     public void BuyCard(){
        FindObjectOfType<Cards>().BuyCardFromInventory(id,price);
        CloseShowCard();
    }
}
