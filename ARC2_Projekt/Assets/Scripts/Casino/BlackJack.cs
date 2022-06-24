using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BlackJack : MonoBehaviour
{
    public GameObject CurrentPlayer;

    public Text PlayerMoney;

    public Text PlayerWonMoney;

    public InputField PlayerBetInput;

    public Text PlayerBet;

    public int PlayerWonMoneyInt = 0;

    public int PlayerBetInt = 0;

    public Text MaxBet;

    public Text Alert;

    public string PlayerBetString;

    public GameObject MainPanel;

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
            back,
            gameEnded;

    public GameObject

            Hit,
            Split,
            Stand,
            Double;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        UpdatePlayerMoneyText();
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

    public void DoubleBet()
    {
        GetMoneyFromPlayerDouble();
    }

    public void ResetBet()
    {
        PlayerBetInt = 0;
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
                    GetMoneyFromPlayer();
                    StartGame();
                }
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
    }

    // Croupier Get Cards
    public void PutCardsInCroupierCardsPanel(int a)
    {
        var CasinoCard = Instantiate(CasinoCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        CasinoCard.transform.SetParent(CroupierCardsPanel.transform, false);
        if (GetComponent<Deck>().GetCroupierDeckFace(a) == 11)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "J";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 12)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "Q";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 13)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "K";
        else if (GetComponent<Deck>().GetCroupierDeckFace(a) == 1)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "A";
        else
            CasinoCard.GetComponent<CasinoCard>().cardValue = GetComponent<Deck>().GetCroupierDeckFace(a).ToString();
        CasinoCard.GetComponent<CasinoCard>().cardSymbol = GetComponent<Deck>().GetCroupierDeckSuit(a);
        CasinoCard.GetComponent<CasinoCard>().SetCardColor(GetComponent<Deck>().GetCroupierDeckSuit(a));
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
        ShowValueOnCroupierHand();
    }

    // HIT
    public void PutCardsInPlayerCardsPanel(int a)
    {
        var CasinoCard = Instantiate(CasinoCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        CasinoCard.transform.SetParent(PlayerCardsPanel.transform, false);
        if (GetComponent<Deck>().GetPlayerDeckFace(a) == 11)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "J";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 12)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "Q";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 13)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "K";
        else if (GetComponent<Deck>().GetPlayerDeckFace(a) == 1)
            CasinoCard.GetComponent<CasinoCard>().cardValue = "A";
        else
            CasinoCard.GetComponent<CasinoCard>().cardValue = GetComponent<Deck>().GetPlayerDeckFace(a).ToString();
        CasinoCard.GetComponent<CasinoCard>().cardSymbol = GetComponent<Deck>().GetPlayerDeckSuit(a);
        CasinoCard.GetComponent<CasinoCard>().SetCardColor(GetComponent<Deck>().GetPlayerDeckSuit(a));
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
        ShowValueOnHand1();
        if (GetComponent<Deck>().BustedHand1())
        {
            GameEnded("Busted");
        }
        else if (GetComponent<Deck>().PlayerHasTwoCards()) ShowButtons();
    }

    // Stand
    public void StandAndGetPLayerValue()
    {
        if (FindObjectOfType<HandValue>().valueAs <= 21)
            GetComponent<Deck>().CroupierVsOneHand(FindObjectOfType<HandValue>().valueAs);
        else
            GetComponent<Deck>().CroupierVsOneHand(FindObjectOfType<HandValue>().value);
    }

    // Cards Value Show in hand 1
    public void ShowValueOnHand1()
    {
        DestroyHand1Text();
        var HandValue = Instantiate(Hand1Value, new Vector3(0, 0, 0), Quaternion.identity);
        HandValue.transform.SetParent(HandValue1Panel.transform, false);

        if (GetComponent<Deck>().GetAs())
        {
            HandValue.GetComponent<HandValue>().value = GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().AssignInfoAs();
        }
        else
        {
            HandValue.GetComponent<HandValue>().value = GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().valueAs = GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().AssignInfo();
        }
    }

    // Cards Value Show in croupier hand
    public void ShowValueOnCroupierHand()
    {
        DestroyCroupierHandText();
        var HandValue = Instantiate(CroupierHandValue, new Vector3(0, 0, 0), Quaternion.identity);
        HandValue.transform.SetParent(CroupierHandValuePanel.transform, false);

        if (GetComponent<Deck>().GetAsCroupier())
        {
            HandValue.GetComponent<CroupierHandValue>().value = GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfoAs();
        }
        else
        {
            HandValue.GetComponent<CroupierHandValue>().value = GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().valueAs = GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfo();
        }
    }

    // Show buttons for decision
    public void ShowButtons()
    {
        DestroyButtons();
        var HitButton = Instantiate(Hit, new Vector3(0, 0, 0), Quaternion.identity);
        HitButton.transform.SetParent(ButtonsPanel1.transform, false);
        var StandButton = Instantiate(Stand, new Vector3(0, 0, 0), Quaternion.identity);
        StandButton.transform.SetParent(ButtonsPanel1.transform, false);
        if (GetComponent<Deck>().DoubleButton() && CurrentPlayer.GetComponent<CurrentPlayer>().Money >= int.Parse(PlayerBet.text))
        {
            var DoubleButton = Instantiate(Double, new Vector3(0, 0, 0), Quaternion.identity);
            DoubleButton.transform.SetParent(ButtonsPanel1.transform, false);
            Debug.Log(CurrentPlayer.GetComponent<CurrentPlayer>().Money + ">=" + int.Parse(PlayerBet.text));
        }
        if (GetComponent<Deck>().SplitButton())
        {
            var SplitButton = Instantiate(Split, new Vector3(0, 0, 0), Quaternion.identity);
            SplitButton.transform.SetParent(ButtonsPanel1.transform, false);
        }
    }

    // GameEnded

    public void GameEnded(string title)
    {
        DestroyButtons();
        var EndButton = Instantiate(gameEnded, new Vector3(0, 0, 0), Quaternion.identity);
        EndButton.transform.SetParent(MainPanel.transform, false);
        if (title == "Lost" || title == "Busted")
        {
            EndButton.GetComponent<Image>().color = Color.red;
            PlayerWonMoneyInt -= int.Parse(PlayerBet.text);
            UpdatePlayerWonMoneyText();
        }
        if (title == "Win")
        {
            EndButton.GetComponent<Image>().color = Color.green;
            PlayerWonMoneyInt += int.Parse(PlayerBet.text);
            UpdatePlayerWonMoneyText();
        }
        if (title == "Push") EndButton.GetComponent<Image>().color = Color.yellow;
        EndButton.GetComponentInChildren<Text>().text = title;
    }

    // Take money from Player bet

    public void GetMoneyFromPlayer()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Money -= int.Parse(PlayerBet.text);
        UpdatePlayerMoneyText();
    }

    // Take money from Player double bet

    public void GetMoneyFromPlayerDouble()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Money -= int.Parse(PlayerBet.text);
        PlayerBetInt = int.Parse(PlayerBet.text);
        PlayerBetInt += PlayerBetInt;
        PlayerBetInput.text = PlayerBetInt.ToString();
        PlayerBet.text = PlayerBetInput.text;
        UpdatePlayerMoneyText();
    }

    // update moany after game

    public void UpdatePlayerMoney(bool win)
    {
        int money = 0;
        if (win) money = CurrentPlayer.GetComponent<CurrentPlayer>().Money + 2 * int.Parse(PlayerBet.text);
        else money = CurrentPlayer.GetComponent<CurrentPlayer>().Money + int.Parse(PlayerBet.text);
        CurrentPlayer.GetComponent<CurrentPlayer>().Money = money;
        UpdatePlayerMoneyText();
    }

    // Destroy all cards at the end of the game
    public void DestroyAllCasinoCards()
    {
        var CasinoCards = GameObject.FindGameObjectsWithTag("CasinoCard");
        foreach (var card in CasinoCards)
        {
            Destroy(card);
        }
    }

    // Destroy cards value when: add a card or end game
    public void DestroyHand1Text()
    {
        var HandValueText = GameObject.FindGameObjectsWithTag("Hand1Value");
        foreach (var value in HandValueText)
        {
            Destroy(value);
        }
    }

    // Destroy cards value when: add a card or end game
    public void DestroyCroupierHandText()
    {
        var HandValueText =
            GameObject.FindGameObjectsWithTag("CroupierHandValue");
        foreach (var value in HandValueText)
        {
            Destroy(value);
        }
    }

    // Destroy black jack buttons
    public void DestroyButtons()
    {
        var BlackJackButtons =
            GameObject.FindGameObjectsWithTag("BlackJackButton");
        foreach (var button in BlackJackButtons)
        {
            Destroy(button);
        }
    }

    // Destroy end game button
    public void DestroyEndGameButton()
    {
        var BlackJackButtons = GameObject.FindGameObjectsWithTag("GameEnded");
        foreach (var button in BlackJackButtons)
        {
            Destroy(button);
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

    public void ResetGame()
    {
        bet.enabled = true;
        less.enabled = true;
        more.enabled = true;
        back.enabled = true;
        ResetBet();
        DestroyHand1Text();
        DestroyCroupierHandText();
        DestroyEndGameButton();
        DestroyAllCasinoCards();
    }

    public void UpdatePlayerMoneyText()
    {
        PlayerMoney.text = "Player Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money + "$";
    }

    public void UpdatePlayerWonMoneyText()
    {
        PlayerWonMoney.text = "Money Won: " + PlayerWonMoneyInt + "$";
    }
}
