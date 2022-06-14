using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardInfo : MonoBehaviour
{
    public Text CardName;
    public Text Type;
    public Text Description;
    public Text Points;
    public Text HealthPoints;

    public string cardname;
    public string type;
    public string description;
    public int points;
    public int healthPoints;
    public int id;
    public bool is_equipped = false;


    public void AssignInfo()
    {
        CardName.text = cardname;
        Type.text = type;
        Description.text = description;
        Points.text = points.ToString();
        HealthPoints.text = healthPoints.ToString();
    }

    public bool IsCardEquipped()
    {
        return is_equipped;
    }

    public void HideBattleCard()
    {
        this.gameObject.SetActive(false);
    }
}
