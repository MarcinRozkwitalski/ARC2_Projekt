using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public BattleHandler battleHandler;

    public void LoadPlayerWelcomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPlayer()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadTownScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLeaderboardScene()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadCasinoScene()
    {
        SceneManager.LoadScene(5);
    }

    public void LoadBlackJackScene()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadMapGenerationScene()
    {
        SceneManager.LoadScene(7);
    }

    public void LoadDungeonBattleScene()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadDungeonResultsScene()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadProperDungeonScene()
    {
        if(battleHandler.whoWon == "player")        SceneManager.LoadScene(7);
        else if(battleHandler.whoWon == "enemy")    SceneManager.LoadScene(9);
    }

}