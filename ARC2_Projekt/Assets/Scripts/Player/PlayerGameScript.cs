using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerGameScript : MonoBehaviour
{
    public TMP_Text UserInfoText;
    public GameObject CurrentPlayer, Tutorial, BlockDungeon, BlockCards, BlockTown;
    public GameObject Welcome, PlayerInfo, HowToLevelUp_1, HowToLevelUp_2, HowToEnterDungeon, HowToGetCards_1, HowToGetCards_2, ClickOnTown;

    private void Start()
    {
        CurrentPlayer = GameObject.Find("CurrentPlayerManager");
        Tutorial = GameObject.Find("TutorialManager");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        int CurrentPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
        int CurrentPlayerLevel = CurrentPlayer.GetComponent<CurrentPlayer>().Level;

        // UserInfoText.text = "User: " + CurrentPlayerUsername + " | Money: " + CurrentPlayerMoney + " | Life: " + CurrentPlayerLife + " | Level: " + CurrentPlayerLevel;
        UserInfoText.text = CurrentPlayerUsername + ": lvl " + CurrentPlayerLevel + "\nLife: " + CurrentPlayerLife + "\nMoney: " + CurrentPlayerMoney;
        Debug.Log("Start = " + Tutorial.GetComponent<Tutorial>().start);
        if (Tutorial.GetComponent<Tutorial>().start) StartTutorial();
    }

    public void LoadLeaderboard()
    {
        FindObjectOfType<SceneSwitcher>().LoadLeaderboardScene();
    }

    public void LoadPlayer()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayer();
    }
    public void StartTutorial()
    {
        Welcome.SetActive(true);
    }
    public void SkipTutorial()
    {
        Welcome.SetActive(false);
        BlockDungeon.SetActive(false);
        BlockCards.SetActive(false);
        BlockTown.SetActive(false);
        Tutorial.GetComponent<Tutorial>().start = false;
    }


    public void Step_1()
    {
        Welcome.SetActive(false);
        PlayerInfo.SetActive(true);
    }
    public void Step_2()
    {
        PlayerInfo.SetActive(false);
        HowToLevelUp_1.SetActive(true);
    }
    public void Step_3()
    {
        HowToLevelUp_1.SetActive(false);
        HowToLevelUp_2.SetActive(true);
    }
    public void Step_4()
    {
        HowToLevelUp_2.SetActive(false);
        HowToEnterDungeon.SetActive(true);
    }
    public void Step_5()
    {
        HowToEnterDungeon.SetActive(false);
        HowToGetCards_1.SetActive(true);
    }

    public void Step_6()
    {
        HowToGetCards_1.SetActive(false);
        HowToGetCards_2.SetActive(true);
    }

    public void Step_7()
    {
        HowToGetCards_2.SetActive(false);
        ClickOnTown.SetActive(true);
    }

    public void Step_8()
    {
        ClickOnTown.SetActive(false);
        BlockTown.SetActive(false);
    }
}
