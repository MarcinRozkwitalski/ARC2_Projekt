using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleResult : MonoBehaviour
{
    public BattleHandler battleHandler;
    public TempCurrentPlayer tempCurrentPlayer;
    
    private void Start() {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
    }

    public void CheckWhoWon()
    {
        if(battleHandler.whoWon == "player")    PlayerWon();
        else                                    EnemyWon();
    }

    public void PlayerWon()
    {
        tempCurrentPlayer.whoWon = "player";
        tempCurrentPlayer.TempPlayerLife = battleHandler.currentPlayerHealth;
    }

    public void EnemyWon()
    {
        tempCurrentPlayer.whoWon = "enemy";
        tempCurrentPlayer.TempPlayerLife = 50;
        tempCurrentPlayer.TempPlayerMoneyResults = 0;
        tempCurrentPlayer.TempPlayerMoney = (int)Mathf.Ceil(tempCurrentPlayer.TempPlayerMoney/2);
    }
}
