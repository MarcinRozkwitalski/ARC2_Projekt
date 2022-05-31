using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    public GameObject CurrentPlayer;

    public Text PlayerMoney;

    public InputField PlayerBetInput;

    public Text PlayerBet;

    public int PlayerBetInt = 0;

    public Text MaxBet;

    public Text Alert;

    public string PlayerBetString;

    public GameObject HandValue1Panel;

    public GameObject CroupierCardsPanel;

    public GameObject PlayerCardsPanel;

    public GameObject Double1Panel;

    public GameObject Double2Panel;

    public GameObject CasinoCardPrefab;

    public GameObject Hand1Value;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        PlayerMoney.text =
            "Player Money: " +
            CurrentPlayer.GetComponent<CurrentPlayer>().Money +
            "$";
    }

    // Betting
    public void AddBet()
    {
        if (PlayerBetInt + 10 <= 500) PlayerBetInt += 10;
        PlayerBetInput.text = PlayerBetInt.ToString();
        PlayerBet.text = PlayerBetInput.text;
    }

    public void RemoveBet()
    {
        if (PlayerBetInt - 10 >= 0) PlayerBetInt -= 10;
        PlayerBetInput.text = PlayerBetInt.ToString();
        PlayerBet.text = PlayerBetInput.text;
    }

    public void Bet()
    {
        DestroyAllCasinoCards();
        if (int.TryParse(PlayerBet.text, out int value))
            if (CorrectPrice(int.Parse(PlayerBet.text)))
                if (
                    CurrentPlayer.GetComponent<CurrentPlayer>().Money >=
                    int.Parse(PlayerBet.text)
                )
                {
                    Alert.text = "Correct bet";
                    StartGame();
                } // Game start
                else
                    Alert.text = "Not enough money";
            else
                Alert.text = "Incorrect bet";
        else
            Alert.text = "Bad bet input";
    }

    public bool CorrectPrice(int playerBetInt)
    {
        bool correctPrice = false;
        if (playerBetInt > 0 && playerBetInt <= 500) correctPrice = true;
        return correctPrice;
    }

    // Game start
    public void StartGame()
    {
        GetComponent<Deck>().GetDeck();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        ShowValueOnHand1();
    }

    public void PutCardsInPlayerCardsPanel(int a)
    {
        var CasinoCard =
            Instantiate(CasinoCardPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        CasinoCard.transform.SetParent(PlayerCardsPanel.transform);
        if (GetComponent<Deck>().GetPlayerDeckFace(a) == 11)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "J";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 12)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "Q";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 13)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "K";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 1)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "A";
        else
            CasinoCard.GetComponent<CasinoCard>().cardValue =
                GetComponent<Deck>().GetPlayerDeckFace(a).ToString();
        CasinoCard.GetComponent<CasinoCard>().cardSymbol =
            GetComponent<Deck>().GetPlayerDeckSuit(a);
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
    }

    public void ShowValueOnHand1()
    {
        DestroyHand1Text();
        var HandValue =
            Instantiate(Hand1Value, new Vector3(0, 0, 0), Quaternion.identity);
        HandValue.transform.SetParent(HandValue1Panel.transform);
        HandValue.transform.position = new Vector3(960, 540, 0);
        if (GetComponent<Deck>().GetAs())
        {
            HandValue.GetComponent<HandValue>().value =
                GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().AssignInfoAs();
        }
        else
        {
            HandValue.GetComponent<HandValue>().value =
                GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().AssignInfo();
        }
        GetComponent<Deck>().GetPlayerCard();
    }

    public void DestroyAllCasinoCards()
    {
        var CasinoCards = GameObject.FindGameObjectsWithTag("CasinoCard");
        foreach (var card in CasinoCards)
        {
            Destroy (card);
        }
    }

    public void DestroyHand1Text()
    {
        var HandValueText = GameObject.FindGameObjectsWithTag("Hand1Value");
        foreach (var value in HandValueText)
        {
            Destroy (value);
        }
    }
}
