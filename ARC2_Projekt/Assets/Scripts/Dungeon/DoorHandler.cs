using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    GameObject Door_01, Door_02, Door_03;
    public int CurrentPlayerId;
    public GameObject CurrentPlayer;
    public DoorCounter doorCounter;
    public DoorRandomizer doorRandomizer;
    public SceneSwitcher sceneSwitcher;
    public ShowPlayerInfo showPlayerInfo;
    public ButtonActions buttonActions;
    public TempCurrentPlayer tempCurrentPlayer;
    Text DoorCounterText; 
    public string DoorValue;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");

        Door_01 = GameObject.Find("Door_01");
        Door_02 = GameObject.Find("Door_02");
        Door_03 = GameObject.Find("Door_03");
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
        doorCounter = GameObject.Find("DoorHandler").GetComponent<DoorCounter>();
        doorRandomizer = GameObject.Find("DoorHandler").GetComponent<DoorRandomizer>();
        sceneSwitcher = GameObject.Find("SceneManager").GetComponent<SceneSwitcher>();
        showPlayerInfo = GameObject.Find("NetworkManager").GetComponent<ShowPlayerInfo>();
        buttonActions = GameObject.Find("DoorHandler").GetComponent<ButtonActions>();

        DoorCounterText = GameObject.Find("DoorCounterText").GetComponent<Text>();
        DoorCounterText.text = "Door counter:\n" + doorCounter.DoorCounterNumber.ToString();
        Randomize();
    }

    public void CheckDoor()
    {
        CheckText();
        UpdateDoorCounter();
        UpdatePlayerInfo();
    }

    public void CheckText()
    {
        DoorValue = this.transform.GetChild(0).GetComponent<Text>().text;
        tempCurrentPlayer.LastDoorValue = DoorValue;

        switch (DoorValue)
        {
            case "skarb":
                buttonActions.TreasureAddMoney();
                break;
            case "czaszka":
                sceneSwitcher.LoadDungeonBattleScene();
                break;
            case "plomien":
                buttonActions.FlameGiveCard();
                break;
            case "glowaDiabla":
                sceneSwitcher.LoadDungeonBattleScene();
                break;
            case "krzyz":
                buttonActions.CrossHeal();
                break;
            case "smutek":
                buttonActions.SadnessLoseMoney();
                break;
            case "usmiech":
                StartCoroutine(UpdatePlayerLifeMoney(tempCurrentPlayer.TempPlayerLife, tempCurrentPlayer.TempPlayerMoney));
                sceneSwitcher.LoadDungeonResultsScene();
                break;    
            default:
                break;
        }
    }

    public void UpdateDoorCounter()
    {
        doorCounter.DoorCounterNumber++;
        DoorCounterText.text = "Door counter:\n" + doorCounter.DoorCounterNumber.ToString();
    }

    public void UpdatePlayerInfo()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        Text UserInfoText = GameObject.Find("UserInfoText").GetComponent<Text>();
        
        UserInfoText.text = 
        "Player: " + CurrentPlayerUsername +
        "\nLife: " + tempCurrentPlayer.TempPlayerLife + 
        "\nMoney: " + tempCurrentPlayer.TempPlayerMoney;
    }

    public void Randomize()
    {
        doorRandomizer.RandomizeDoors();
        Door_01.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[0];
        Door_02.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[1];
        Door_03.transform.GetChild(0).GetComponent<Text>().text = doorRandomizer.doors[2];
    }

    public IEnumerator UpdatePlayerLifeMoney(int life, int player_money)
    {
        WWWForm updatePlayerLifeMoneyForm = new WWWForm();
        updatePlayerLifeMoneyForm.AddField("apppassword", "thisisfromtheapp!");
        updatePlayerLifeMoneyForm.AddField("Id", CurrentPlayerId);
        updatePlayerLifeMoneyForm.AddField("Life", life);
        updatePlayerLifeMoneyForm.AddField("Money", player_money);

        UnityWebRequest updatePlayerLifeMoneyRequest = UnityWebRequest.Post("http://localhost/arcCruds/dungeon/updateplayerlifemoney.php", updatePlayerLifeMoneyForm);

        CurrentPlayer.GetComponent<CurrentPlayer>().Life = life;
        CurrentPlayer.GetComponent<CurrentPlayer>().Money = player_money;
        yield return updatePlayerLifeMoneyRequest.SendWebRequest();
    }
}