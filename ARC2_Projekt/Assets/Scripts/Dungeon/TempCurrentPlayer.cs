using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TempCurrentPlayer : MonoBehaviour
{
    public Text UserInfoText;

    public int TempPlayerMoney;
    public int TempPlayerLife;

    private void Awake() {

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