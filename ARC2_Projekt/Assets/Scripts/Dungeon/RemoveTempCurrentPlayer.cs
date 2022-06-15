using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTempCurrentPlayer : MonoBehaviour
{
    public DoorHandler doorHandler;
    public TempCurrentPlayer tempCurrentPlayer;

    private void Start() {
        doorHandler = GameObject.Find("DoorHandler").GetComponent<DoorHandler>();
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
    }

    public void LostDungeon()
    {
        if(tempCurrentPlayer.whoWon != "player"){
            StartCoroutine(doorHandler.UpdatePlayerLifeMoney(tempCurrentPlayer.TempPlayerLife, tempCurrentPlayer.TempPlayerMoney));
        }
    }
    public void DestroyTempCurrentPlayer()
    {
        Destroy(GameObject.Find("DoorHandler"));
    }
}