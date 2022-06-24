using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DungeonResults : MonoBehaviour
{
    public MapStatus mapStatus;

    public TMP_Text ResultsText;
    public string MoneyText;
    public string BeatenText = "Beaten:\n";
    public string NormalEnemiesText = "";
    public string PowerfulEnemiesText = "";
    public TempCurrentPlayer tempCurrentPlayer;
    public CurrentPlayer currentPlayer;

    private void Start() 
    {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
        currentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer").GetComponent<CurrentPlayer>();
        mapStatus = GameObject.Find("MapManager").GetComponent<MapStatus>();

        CheckMoney();
        CheckEnemies();

        if(tempCurrentPlayer.whoWon == "player")
        {
            ResultsText.text = "You've passed dungeon!\n\n" +
            "You've " + MoneyText + "Total money: " + (tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney) + "\n\n" + 
            BeatenText + NormalEnemiesText + PowerfulEnemiesText;

            currentPlayer.Money = tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney;
            currentPlayer.Life = tempCurrentPlayer.TempPlayerLife;
            if(tempCurrentPlayer.TempPlayerLevel < mapStatus.dungeon_zone) currentPlayer.Level = mapStatus.dungeon_zone;
        }
        else if(tempCurrentPlayer.whoWon == "enemy")
        {
            ResultsText.text = "You didn't pass dungeon!\n\n" +
            "You've " + MoneyText + "Total money: " + tempCurrentPlayer.TempPlayerSaveMoney + "\n\n" + 
            BeatenText + NormalEnemiesText + PowerfulEnemiesText;

            currentPlayer.Money = tempCurrentPlayer.TempPlayerSaveMoney;
            currentPlayer.Life = 100;
        }
    }

    void CheckMoney()
    {
        if(tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney > 0 && tempCurrentPlayer.whoWon == "player")        GainedMoney();
        else if(tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney < 0 && tempCurrentPlayer.whoWon == "player")   LostMoney();
        else if(tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney == 0 && tempCurrentPlayer.whoWon == "player")  NoMoney();
        else                                                                                            LostGainedMoney();
    }

    void GainedMoney()
    {
        MoneyText = "gained " + (tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney) + " money.\n";
    }

    void NoMoney()
    {
        MoneyText = "gained no money at all.\n";
    }

    void LostMoney()
    {
        MoneyText = "lost " + Math.Abs(tempCurrentPlayer.TempPlayerMoney + tempCurrentPlayer.TempPlayerSaveMoney) + " money.\n";
    }

    void LostGainedMoney()
    {
        MoneyText = "lost gained money from dungeon!\n";
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
