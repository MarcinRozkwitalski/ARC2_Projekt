using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public BattleHandler battleHandler;

    public void LoadWelcomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNewUserScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLoginScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadPlayerWelcomeScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadPlayer()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadTownScene()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadDungeonScene()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadProperDungeonScene()
    {
        if(battleHandler.whoWon == "player")        SceneManager.LoadScene(8);
        else if(battleHandler.whoWon == "enemy")    SceneManager.LoadScene(13);
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadCasinoScene()
    {
        SceneManager.LoadScene(10);
    }

    public void LoadBlackJackScene()
    {
        SceneManager.LoadScene(11);
    }

    public void LoadDungeonBattleScene()
    {
        SceneManager.LoadScene(12);
    }

    public void LoadDungeonResultsScene()
    {
        SceneManager.LoadScene(13);
    }

    public void LoadMapGenerationScene()
    {
        SceneManager.LoadScene(14);
    }
}
