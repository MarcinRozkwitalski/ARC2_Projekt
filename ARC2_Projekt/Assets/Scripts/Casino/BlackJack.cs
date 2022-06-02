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

    public GameObject CroupierHandValuePanel;

    public GameObject CroupierCardsPanel;

    public GameObject PlayerCardsPanel;

    public GameObject Double1Panel;

    public GameObject Double2Panel;

    public GameObject CasinoCardPrefab;

    public GameObject CroupierHandValue;

    public GameObject Hand1Value;

    public GameObject Hand2Value;

    public GameObject ButtonsPanel1;

    public Button

            bet,
            less,
            more,
            back;

    public GameObject

            Hit,
            Split,
            Stand,
            Double;

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
        DisableBetButtons();
        GetComponent<Deck>().GetDeck();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        GetComponent<Deck>().AddCardFromDeckToCroupier();
        ShowButtons();
        ShowValueOnHand1();
        ShowValueOnCroupierHand();
    }

    // Croupier Get Cards
    public void PutCardsInCroupierCardsPanel(int a)
    {
        var CasinoCard =
            Instantiate(CasinoCardPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        CasinoCard.transform.SetParent(CroupierCardsPanel.transform);
        if (GetComponent<Deck>().GetCroupierDeckFace(a) == 11)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "J";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 12)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "Q";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 13)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "K";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 1)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "A";
        else
            CasinoCard.GetComponent<CasinoCard>().cardValue =
                GetComponent<Deck>().GetCroupierDeckFace(a).ToString();
        CasinoCard.GetComponent<CasinoCard>().cardSymbol =
            GetComponent<Deck>().GetCroupierDeckSuit(a);
        CasinoCard
            .GetComponent<CasinoCard>()
            .SetCardColor(GetComponent<Deck>().GetCroupierDeckSuit(a));
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
    }

    // HIT
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
        CasinoCard
            .GetComponent<CasinoCard>()
            .SetCardColor(GetComponent<Deck>().GetPlayerDeckSuit(a));
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
    }

    // Cards Value Show on screen
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

    public void ShowValueOnCroupierHand()
    {
        var HandValue =
            Instantiate(CroupierHandValue,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        HandValue.transform.SetParent(CroupierHandValuePanel.transform);
        HandValue.transform.position = new Vector3(960, 540, 0);
        if (GetComponent<Deck>().GetAs())
        {
            HandValue.GetComponent<CroupierHandValue>().value =
                GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfoAs();
        }
        else
        {
            HandValue.GetComponent<CroupierHandValue>().value =
                GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfo();
        }
    }

    // Show buttons for decision
    public void ShowButtons()
    {
        DestroyHand1Text();
        var HitButton =
            Instantiate(Hit, new Vector3(0, 0, 0), Quaternion.identity);
        HitButton.transform.SetParent(ButtonsPanel1.transform);
        var StandButton =
            Instantiate(Stand, new Vector3(0, 0, 0), Quaternion.identity);
        StandButton.transform.SetParent(ButtonsPanel1.transform);
        var DoubleButton =
            Instantiate(Double, new Vector3(0, 0, 0), Quaternion.identity);
        DoubleButton.transform.SetParent(ButtonsPanel1.transform);
        var SplitButton =
            Instantiate(Split, new Vector3(0, 0, 0), Quaternion.identity);
        SplitButton.transform.SetParent(ButtonsPanel1.transform);
    }

    // Destroy all cards at the end of the game
    public void DestroyAllCasinoCards()
    {
        var CasinoCards = GameObject.FindGameObjectsWithTag("CasinoCard");
        foreach (var card in CasinoCards)
        {
            Destroy (card);
        }
    }

    // Destroy cards value when: add a card or end game
    public void DestroyHand1Text()
    {
        var HandValueText = GameObject.FindGameObjectsWithTag("Hand1Value");
        foreach (var value in HandValueText)
        {
            Destroy (value);
        }
    }

    // Destroy black jack buttons
    public void DestroyButtons()
    {
        var BlackJackButtons =
            GameObject.FindGameObjectsWithTag("BlackJackButtons");
        foreach (var button in BlackJackButtons)
        {
            Destroy (button);
        }
    }

    // Disable buttons for next bet
    public void DisableBetButtons()
    {
        bet.enabled = false;
        less.enabled = false;
        more.enabled = false;
        back.enabled = false;
    }
}
