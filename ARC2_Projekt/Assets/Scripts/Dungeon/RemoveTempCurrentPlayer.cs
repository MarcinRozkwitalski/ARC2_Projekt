using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTempCurrentPlayer : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;

    private void Start() {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
    }

    public void LostDungeon()
    {
        if(tempCurrentPlayer.whoWon != "player"){
            //StartCoroutine(doorHandler.UpdatePlayerLifeMoney(tempCurrentPlayer.TempPlayerLife, tempCurrentPlayer.TempPlayerMoney));
        }
    }

    //do przycisku EXIT DUNGEON
    public void DestroyTempCurrentPlayer()
    {
        Destroy(GameObject.Find("DoorHandler"));
    }
}