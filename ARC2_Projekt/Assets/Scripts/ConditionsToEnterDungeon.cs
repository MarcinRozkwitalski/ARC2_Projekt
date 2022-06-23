using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class ConditionsToEnterDungeon : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    public CardList cardList;

    public GameObject CurrentPlayer;
    public GameObject InformationPanel;

    public int errorNumber;
    public int cardsNumber;
    public bool isAttackCardPresent;

    void Awake()
    {
        cardList = GameObject.Find("CardManager").GetComponent<CardList>();
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        InformationPanel = GameObject.Find("InformationPanel");
        sceneSwitcher = GameObject.Find("SceneManager").GetComponent<SceneSwitcher>();

        TurnInformationPanelOff();
        GetAllPlayerDeckCards();
    }

    void Start()
    {
        if (cardsNumber > 2 && isAttackCardPresent == true)         errorNumber = 0; //free to go
        else if (cardsNumber < 3 && isAttackCardPresent == false)   errorNumber = 1; //need more cards and at least one attack card
        else if (cardsNumber < 3 && isAttackCardPresent == true)    errorNumber = 2; //need at least two cards
        else if (cardsNumber > 2 && isAttackCardPresent == false)   errorNumber = 3; //need at least one attack card
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
                sceneSwitcher.LoadMapGenerationScene();
                break;
            case 1:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least three cards and at least one card of Attack type \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
            case 2:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least \three cards \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
            case 3:
                InformationPanel.transform.GetChild(1).GetComponent<Text>().text = "You need at least one card of Attack type \nto enter Dungeon.";
                TurnInformationPanelOn();
                break;
        }
    }

    public void GetAllPlayerDeckCards()
    {   
        cardsNumber = 0;

        foreach(var card in cardList.cardsList)
        {
            if(card.is_equipped == true && card.bought == true)
            {
                cardsNumber++;
                if(card.card_type == "Atak") isAttackCardPresent = true;
            }
        }
    }
}