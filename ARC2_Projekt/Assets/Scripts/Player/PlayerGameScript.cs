using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class PlayerGameScript : MonoBehaviour
{
    public TMP_Text UserInfoText;
    public GameObject CurrentPlayer, Tutorial, BlockDungeon, BlockCards, BlockTown, BlockShop, BlockCasino, BlockTownExit;
    public GameObject Welcome, PlayerInfo, HowToLevelUp_1, HowToLevelUp_2, HowToEnterDungeon, HowToGetCards_1, HowToGetCards_2, ClickOnTown, ClickOnShop, ClickOnTownExit;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        CurrentPlayer = GameObject.Find("CurrentPlayerManager");
        Tutorial = GameObject.Find("TutorialManager");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        int CurrentPlayerMoney = CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        int CurrentPlayerLife = CurrentPlayer.GetComponent<CurrentPlayer>().Life;
        int CurrentPlayerLevel = CurrentPlayer.GetComponent<CurrentPlayer>().Level;

        // UserInfoText.text = "User: " + CurrentPlayerUsername + " | Money: " + CurrentPlayerMoney + " | Life: " + CurrentPlayerLife + " | Level: " + CurrentPlayerLevel;
        //UserInfoText.text = CurrentPlayerUsername + ": lvl " + CurrentPlayerLevel + "\nLife: " + CurrentPlayerLife + "\nMoney: " + CurrentPlayerMoney;
        Debug.Log("Start = " + Tutorial.GetComponent<Tutorial>().start_part_1);

        if(scene.name == "Welcome")
        {
            if (Tutorial.GetComponent<Tutorial>().start_part_1) StartTutorialPart1();
            // else if (Tutorial.GetComponent<Tutorial>().start_part_2) StartTutorialPart2();
            else Unlocked();
        }
        
        if(scene.name == "Town")
        {
            if (Tutorial.GetComponent<Tutorial>().start_town_part_1) StartTownPart1();
            else if(Tutorial.GetComponent<Tutorial>().start_town_part_2) StartTownPart2();
            else UnlockedTown();
        }

        if(scene.name == "Shop")
        {
            if (Tutorial.GetComponent<Tutorial>().start_shop) StartShop();
            else UnlockedShop();
        }

        if(scene.name == "Shop")
        {
            
        }
        
    }

    public void LoadLeaderboard()
    {
        FindObjectOfType<SceneSwitcher>().LoadLeaderboardScene();
    }

    public void LoadPlayer()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayer();
    }
    public void StartTutorialPart1()
    {
        Welcome.SetActive(true);
    }
    public void StartTownPart1()
    {
        BlockCasino.SetActive(true);
        BlockShop.SetActive(true);
        BlockTownExit.SetActive(true);
        ClickOnShop.SetActive(true);
        ClickOnTownExit.SetActive(false);
    }

    public void StartTownPart2()
    {
        BlockCasino.SetActive(true);
        BlockShop.SetActive(true);
        BlockTownExit.SetActive(true);
        ClickOnShop.SetActive(false);
        ClickOnTownExit.SetActive(true);
    }
    public void StartShop()
    {
        //.SetActive(true);
    }
    public void SkipTutorial()
    {
        Welcome.SetActive(false);
        BlockDungeon.SetActive(false);
        BlockCards.SetActive(false);
        BlockTown.SetActive(false);
        Tutorial.GetComponent<Tutorial>().start_part_1 = false;
        Tutorial.GetComponent<Tutorial>().start_town_part_1 = false;
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
        Tutorial.GetComponent<Tutorial>().start_part_1 = false;
    }

    public void Step_9_Shop()
    {
        ClickOnShop.SetActive(false);
        BlockShop.SetActive(false);
        Tutorial.GetComponent<Tutorial>().start_town_part_1 = false;
    }

    public void Step_number_ExitTown()
    {
        BlockTownExit.SetActive(false);
        ClickOnTownExit.SetActive(false);
        Tutorial.GetComponent<Tutorial>().start_town_part_2 = false;
    }

    public void Unlocked()
    {
        BlockCards.SetActive(false);
        BlockTown.SetActive(false);
        BlockDungeon.SetActive(false);
    }

    public void UnlockedTown()
    {
        BlockCasino.SetActive(false);
        BlockShop.SetActive(false);
        BlockTownExit.SetActive(false);
        ClickOnShop.SetActive(false);
    }

    public void UnlockedShop()
    {

    }

    public void StartTutorialPart2()
    {
        
    }
}
