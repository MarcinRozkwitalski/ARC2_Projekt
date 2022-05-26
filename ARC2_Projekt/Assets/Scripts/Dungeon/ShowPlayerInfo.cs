using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowPlayerInfo : MonoBehaviour
{
    public Text UserInfoText;

    private void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        int CurrentPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;

        UserInfoText.text = 
        "Player: " + CurrentPlayerUsername +
        "\nLife: " + CurrentPlayerLife + 
        "\nMoney: " + CurrentPlayerMoney;
    }
}