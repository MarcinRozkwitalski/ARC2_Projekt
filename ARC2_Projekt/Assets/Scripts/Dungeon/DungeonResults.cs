using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DungeonResults : MonoBehaviour
{
    public Text ResultsText;
    public TempCurrentPlayer tempCurrentPlayer;

    private void Start() {
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();

        ResultsText.text = "You've passed dungeon!\n\n" +
        "You've:\n" +
        "Gained " + tempCurrentPlayer.TempPlayerMoney + " money.\n" +
        "Beaten " + tempCurrentPlayer.BeatenNormalEnemies + " normal enemies.\n" +
        "Beaten " + tempCurrentPlayer.BeatenPowerfulEnemies + " powerful enemies.\n";
    }
}
