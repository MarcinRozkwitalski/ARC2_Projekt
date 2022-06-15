using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempCurrentPlayer : MonoBehaviour
{
    public Text UserInfoText;

    public int TempPlayerMoney = 0;
    public int TempPlayerLife = 0;
    public int TempPlayerMoneyResults = 0;
    public int BeatenNormalEnemies = 0;
    public int BeatenPowerfulEnemies = 0;
    public string whoWon = "player";
    public string LastDoorValue;

    private void Awake() 
    {

        var tempCurrentPlayers = FindObjectsOfType<TempCurrentPlayer>();
        if(tempCurrentPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        TempPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        TempPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
    }
}