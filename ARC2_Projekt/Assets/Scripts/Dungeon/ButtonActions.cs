using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;

    void Start()
    {
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();

        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        tempCurrentPlayer.TempPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        tempCurrentPlayer.TempPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
    }
    
    public void TreasureAddMoney()
    {
        int ValueToAdd = Random.Range(10, 50);
        tempCurrentPlayer.TempPlayerMoney += ValueToAdd;
        tempCurrentPlayer.TempPlayerMoneyResults += ValueToAdd;
    }

    public void FlameGiveCard()
    {
        //some more advanced coding needed here
    }

    public void CrossHeal()
    {
        tempCurrentPlayer.TempPlayerLife += Random.Range(5, 20);
        if (tempCurrentPlayer.TempPlayerLife > 100) tempCurrentPlayer.TempPlayerLife = 100;
    }

    public void SadnessLoseMoney()
    {
        int ValueToAdd = Random.Range(10, 20);
        tempCurrentPlayer.TempPlayerMoney -= ValueToAdd;
        tempCurrentPlayer.TempPlayerMoneyResults -= ValueToAdd;
    }
}