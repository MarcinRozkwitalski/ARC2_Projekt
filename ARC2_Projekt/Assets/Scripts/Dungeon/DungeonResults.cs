using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class DungeonResults : MonoBehaviour
{
    public Text ResultsText;
    public string MoneyText;
    public string BeatenText = "Beaten:\n";
    public string NormalEnemiesText = "";
    public string PowerfulEnemiesText = "";
    public TempCurrentPlayer tempCurrentPlayer;

    private void Start() 
    {
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");

        CheckMoney();
        CheckEnemies();

        ResultsText.text = "You've passed dungeon, " + CurrentPlayer.GetComponent<CurrentPlayer>().Username + "!\n\n" +
        "You've " + MoneyText + "Total money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money + "\n\n" + 
        BeatenText + NormalEnemiesText + PowerfulEnemiesText;
    }

    void CheckMoney()
    {
        if(tempCurrentPlayer.TempPlayerMoneyResults > 0)        GainedMoney();
        else if(tempCurrentPlayer.TempPlayerMoneyResults == 0)  NoMoney();
        else                                                    LostMoney();
    }

    void GainedMoney()
    {
        MoneyText = "gained " + tempCurrentPlayer.TempPlayerMoneyResults + " money.\n";
    }

    void NoMoney()
    {
        MoneyText = "gained no money at all.\n";
    }

    void LostMoney()
    {
        MoneyText = "lost " + Math.Abs(tempCurrentPlayer.TempPlayerMoneyResults) + " money.\n";
    }

    void CheckEnemies()
    {
        if(tempCurrentPlayer.BeatenNormalEnemies == 0 && tempCurrentPlayer.BeatenPowerfulEnemies == 0) BeatenText = "";
        if(tempCurrentPlayer.BeatenNormalEnemies > 0) CheckNormalEnemies();
        if(tempCurrentPlayer.BeatenPowerfulEnemies > 0) CheckPowerfulEnemies();
    }

    void CheckNormalEnemies()
    {
        if(tempCurrentPlayer.BeatenNormalEnemies == 1)
        NormalEnemiesText = tempCurrentPlayer.BeatenNormalEnemies + " normal enemy.\n";
        else
        NormalEnemiesText = tempCurrentPlayer.BeatenNormalEnemies + " normal enemies.\n";
    }

    void CheckPowerfulEnemies()
    {
        if(tempCurrentPlayer.BeatenPowerfulEnemies == 1)
        PowerfulEnemiesText = tempCurrentPlayer.BeatenPowerfulEnemies + " powerful enemy.\n";
        else
        PowerfulEnemiesText = tempCurrentPlayer.BeatenPowerfulEnemies + " powerful enemies.\n";
    }
}
