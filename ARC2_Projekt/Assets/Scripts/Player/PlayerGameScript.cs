using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerGameScript : MonoBehaviour
{
    public Text UserInfoText;

    private void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        int CurrentPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
        int CurrentPlayerLevel = CurrentPlayer.GetComponent<CurrentPlayer>().Level;

        UserInfoText.text = "User: " + CurrentPlayerUsername + " | Money: " + CurrentPlayerMoney + " | Life: " + CurrentPlayerLife + " | Level: " + CurrentPlayerLevel;
    }

    public void StartGame()
    {
        FindObjectOfType<SceneSwitcher>().LoadGame();
    }

    public void SignOut()
    {
        var CurrentPlayers = GameObject.FindGameObjectsWithTag("CurrentPlayer");
        foreach(var item in CurrentPlayers)
        {
            Destroy(item);
        }
        FindObjectOfType<SceneSwitcher>().LoadWelcomeScene();
    }
}
