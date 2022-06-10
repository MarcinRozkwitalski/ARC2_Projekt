using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class ConditionsToEnterDungeon : MonoBehaviour
{
    public GameObject CurrentPlayer;
    public int CurrentPlayerId;
    public GameObject InformationPanel;
    public SceneSwitcher sceneSwitcher;

    public int errorNumber;
    public int cardsNumber;
    public bool isAttackCardPresent;

    void Awake() {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        InformationPanel = GameObject.Find("InformationPanel");
        sceneSwitcher = GameObject.Find("SceneManager").GetComponent<SceneSwitcher>();

        TurnInformationPanelOff();
        StartCoroutine(GetAllPlayerDeckCards());
    }

    void Start()
    {
        if (cardsNumber > 1 && isAttackCardPresent == true)         errorNumber = 0; //free to go
        else if (cardsNumber < 2 && isAttackCardPresent == false)   errorNumber = 1; //need more cards and at least one attack card
        else if (cardsNumber < 2 && isAttackCardPresent == true)    errorNumber = 2; //need at least two cards
        else if (cardsNumber > 1 && isAttackCardPresent == false)   errorNumber = 3; //need at least one attack card
    }

    public void TurnInformationPanelOn()
    {
        InformationPanel.GetComponent<Image>().enabled = true;
        for(int i = 0; i <= 2; i++)
        {
            InformationPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    
    public void TurnInformationPanelOff()
    {
        InformationPanel.GetComponent<Image>().enabled = false;
        for(int i = 0; i <= 2; i++)
        {
            InformationPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void CheckConditions()
    {
        switch(errorNumber)
        {
            case 0:
                sceneSwitcher.LoadDungeonScene();
                break;
            case 1:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least two cards and at least one card of Attack type \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
            case 2:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least \ntwo cards \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
            case 3:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least one card of Attack type \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
        }
    }

    IEnumerator GetAllPlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getalldeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            cardsNumber = 0;
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    cardsNumber++;
                    if(player_cards[1] == "Atak") isAttackCardPresent = true;
                }
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }
}