using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTempCurrentPlayer : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;
    public CurrentPlayer currentPlayer;

    private void Start() {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
        currentPlayer = GameObject.Find("CurrentPlayerManager").GetComponent<CurrentPlayer>();
    }

    public void LostDungeon()
    {
        if(tempCurrentPlayer.whoWon != "player"){
            //StartCoroutine(doorHandler.UpdatePlayerLifeMoney(tempCurrentPlayer.TempPlayerLife, tempCurrentPlayer.TempPlayerMoney));
        }
    }

    public void DestroyTempPlayerManagerAndMapStatus()
    {
        Destroy(GameObject.Find("PlayerManager"));
        Destroy(GameObject.Find("MapStatus"));
    }
}