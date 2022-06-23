using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemyToTCP : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;
    public DoorHandler doorHandler;
    
    private void Start() {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
    }

    public void HandleAddingEnemy()
    {
        if(tempCurrentPlayer.LastDoorValue == "Skull")
        AddNormalEnemy();
        else if(tempCurrentPlayer.LastDoorValue == "Devil")
        AddPowerfulEnemy();
    }

    public void AddNormalEnemy()
    {
        tempCurrentPlayer.BeatenNormalEnemies += 1;
        tempCurrentPlayer.TempPlayerMoney += Mathf.RoundToInt(100 * tempCurrentPlayer.TempPlayerMoneyToWinPercentage);
    }

    public void AddPowerfulEnemy()
    {
        tempCurrentPlayer.BeatenPowerfulEnemies += 1;
        tempCurrentPlayer.TempPlayerMoney += Mathf.RoundToInt(200 * tempCurrentPlayer.TempPlayerMoneyToWinPercentage);
    }
}
