using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public int CurrentPlayerMoney;
    public int CurrentPlayerLife;

    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        CurrentPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
    }
    
    public void TreasureAddMoney()
    {
        CurrentPlayerMoney += Random.Range(10, 50);
    }

    public void FlameGiveCard()
    {
        //some more advanced coding needed here
    }

    public void CrossHeal()
    {
        CurrentPlayerLife += Random.Range(5, 20);
        if (CurrentPlayerLife > 100) CurrentPlayerLife = 100;
    }

    public void SadnessLoseMoney()
    {
        CurrentPlayerMoney -= Random.Range(10, 25);
    }
}