using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemyToTCP : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;
    public DoorHandler doorHandler;
    
    private void Start() {
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
    }

    public void HandleAddingEnemy()
    {
        if(tempCurrentPlayer.LastDoorValue == "czaszka")
        AddNormalEnemy();
        else if(tempCurrentPlayer.LastDoorValue == "glowaDiabla")
        AddPowerfulEnemy();
    }

    public void AddNormalEnemy()
    {
        tempCurrentPlayer.BeatenNormalEnemies += 1;
    }

    public void AddPowerfulEnemy()
    {
        tempCurrentPlayer.BeatenPowerfulEnemies += 1;
    }
}
