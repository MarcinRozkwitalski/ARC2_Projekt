using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
        StartCoroutine(GetMoneyFromPlayerDouble());
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
                    StartCoroutine(GetMoneyFromPlayer());
                    StartCoroutine(StartGame());
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
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f); // dzięki temu nie pojawia się button double bo program ma czas na update playermoney
        DisableBetButtons();
        GetComponent<Deck>().GetDeck();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        GetComponent<Deck>().AddCardFromDeckToPlayer();
        GetComponent<Deck>().AddCardFromDeckToCroupier();
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
        ShowValueOnCroupierHand();
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
        ShowValueOnHand1();
        if (GetComponent<Deck>().BustedHand1())
        {
            StartCoroutine(GameEnded("Busted"));
        }
        else if (GetComponent<Deck>().PlayerHasTwoCards()) ShowButtons();
    }

    // Stand
    public void StandAndGetPLayerValue()
    {
        if (FindObjectOfType<HandValue>().valueAs <= 21)
            GetComponent<Deck>()
                .CroupierVsOneHand(FindObjectOfType<HandValue>().valueAs);
        else
            GetComponent<Deck>()
                .CroupierVsOneHand(FindObjectOfType<HandValue>().value);
    }

    // Cards Value Show in hand 1
    public void ShowValueOnHand1()
    {
        DestroyHand1Text();
        var HandValue =
            Instantiate(Hand1Value, new Vector3(0, 0, 0), Quaternion.identity);
        HandValue.transform.SetParent(HandValue1Panel.transform);

        // HandValue.transform.position = new Vector3(960, 540, 0);
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
            HandValue.GetComponent<HandValue>().valueAs =
                GetComponent<Deck>().GetValueA1();
            HandValue.GetComponent<HandValue>().AssignInfo();
        }
        // GetComponent<Deck>().GetPlayerCard();
    }

    // Cards Value Show in croupier hand
    public void ShowValueOnCroupierHand()
    {
        DestroyCroupierHandText();
        var HandValue =
            Instantiate(CroupierHandValue,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        HandValue.transform.SetParent(CroupierHandValuePanel.transform);

        // HandValue.transform.position = new Vector3(960, 540, 0);
        if (GetComponent<Deck>().GetAsCroupier())
        {
            HandValue.GetComponent<CroupierHandValue>().value =
                GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfoAs();
        }
        else
        {
            HandValue.GetComponent<CroupierHandValue>().value =
                GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().valueAs =
                GetComponent<Deck>().GetCroupierValueA1();
            HandValue.GetComponent<CroupierHandValue>().AssignInfo();
        }
    }

    // Show buttons for decision
    public void ShowButtons()
    {
        DestroyButtons();
        var HitButton =
            Instantiate(Hit, new Vector3(0, 0, 0), Quaternion.identity);
        HitButton.transform.SetParent(ButtonsPanel1.transform);
        var StandButton =
            Instantiate(Stand, new Vector3(0, 0, 0), Quaternion.identity);
        StandButton.transform.SetParent(ButtonsPanel1.transform);
        if (
            GetComponent<Deck>().DoubleButton() &&
            CurrentPlayer.GetComponent<CurrentPlayer>().Money >=
            int.Parse(PlayerBet.text)
        )
        {
            var DoubleButton =
                Instantiate(Double, new Vector3(0, 0, 0), Quaternion.identity);
            DoubleButton.transform.SetParent(ButtonsPanel1.transform);
            Debug
                .Log(CurrentPlayer.GetComponent<CurrentPlayer>().Money +
                ">=" +
                int.Parse(PlayerBet.text));
        }
        if (GetComponent<Deck>().SplitButton())
        {
            var SplitButton =
                Instantiate(Split, new Vector3(0, 0, 0), Quaternion.identity);
            SplitButton.transform.SetParent(ButtonsPanel1.transform);
        }
    }

    // GameEnded
    public IEnumerator GameEnded(string title)
    {
        DestroyButtons();
        yield return new WaitForSeconds(1F);
        var EndButton =
            Instantiate(gameEnded, new Vector3(0, 0, 0), Quaternion.identity);
        EndButton.transform.SetParent(MainPanel.transform);
        EndButton.transform.position = new Vector3(960, 640, 0);
        if (title == "Lost") EndButton.GetComponent<Image>().color = Color.red;
        if (title == "Win") EndButton.GetComponent<Image>().color = Color.green;
        if (title == "Push")
            EndButton.GetComponent<Image>().color = Color.yellow;
        EndButton.GetComponentInChildren<Text>().text = title;
    }

    // Take money from Player bet
    public IEnumerator GetMoneyFromPlayer()
    {
        WWWForm betMoneyForm = new WWWForm();
        betMoneyForm.AddField("apppassword", "thisisfromtheapp!");
        betMoneyForm
            .AddField("Id", CurrentPlayer.GetComponent<CurrentPlayer>().Id);
        betMoneyForm
            .AddField("Price",
            CurrentPlayer.GetComponent<CurrentPlayer>().Money -
            int.Parse(PlayerBet.text));
        UnityWebRequest betMoneyRequest =
            UnityWebRequest
                .Post("http://localhost/BlackJack/betmoney.php", betMoneyForm);
        Debug.Log("Money halo");
        if (betMoneyRequest.error == null)
        {
            yield return betMoneyRequest.SendWebRequest();
            CurrentPlayer.GetComponent<CurrentPlayer>().Money -=
                int.Parse(PlayerBet.text);
            UpdatePlayerMoneyText();
            Debug.Log("Money bet = " + int.Parse(PlayerBet.text));
        }
        else
            Debug.Log("oj");
    }

    // Take money from Player double bet
    public IEnumerator GetMoneyFromPlayerDouble()
    {
        WWWForm betMoneyForm = new WWWForm();
        betMoneyForm.AddField("apppassword", "thisisfromtheapp!");
        betMoneyForm
            .AddField("Id", CurrentPlayer.GetComponent<CurrentPlayer>().Id);
        betMoneyForm
            .AddField("Price",
            CurrentPlayer.GetComponent<CurrentPlayer>().Money -
            int.Parse(PlayerBet.text));
        UnityWebRequest betMoneyRequest =
            UnityWebRequest
                .Post("http://localhost/BlackJack/betmoney.php", betMoneyForm);
        if (betMoneyRequest.error == null)
        {
            yield return betMoneyRequest.SendWebRequest();
            CurrentPlayer.GetComponent<CurrentPlayer>().Money -=
                int.Parse(PlayerBet.text);
            PlayerBetInt = int.Parse(PlayerBet.text);
            PlayerBetInt += PlayerBetInt;
            PlayerBetInput.text = PlayerBetInt.ToString();
            PlayerBet.text = PlayerBetInput.text;
            UpdatePlayerMoneyText();
            Debug.Log("Money bet = " + int.Parse(PlayerBet.text));
        }
        else
            Debug.Log("oj");
    }

    // update moany after game
    public IEnumerator UpdatePlayerMoney(bool win)
    {
        yield return new WaitForSeconds(1F);
        WWWForm betMoneyForm = new WWWForm();
        betMoneyForm.AddField("apppassword", "thisisfromtheapp!");
        betMoneyForm
            .AddField("Id", CurrentPlayer.GetComponent<CurrentPlayer>().Id);
        int money = 0;
        if (win)
            money =
                CurrentPlayer.GetComponent<CurrentPlayer>().Money +
                2 * int.Parse(PlayerBet.text);
        else
            money =
                CurrentPlayer.GetComponent<CurrentPlayer>().Money +
                int.Parse(PlayerBet.text);
        betMoneyForm.AddField("Price", money);
        UnityWebRequest betMoneyRequest =
            UnityWebRequest
                .Post("http://localhost/BlackJack/betmoney.php", betMoneyForm);
        if (betMoneyRequest.error == null)
        {
            yield return betMoneyRequest.SendWebRequest();
            CurrentPlayer.GetComponent<CurrentPlayer>().Money = money;
            UpdatePlayerMoneyText();
        }
        else
            Debug.Log("oj");
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

    // Destroy cards value when: add a card or end game
    public void DestroyCroupierHandText()
    {
        var HandValueText =
            GameObject.FindGameObjectsWithTag("CroupierHandValue");
        foreach (var value in HandValueText)
        {
            Destroy (value);
        }
    }

    // Destroy black jack buttons
    public void DestroyButtons()
    {
        var BlackJackButtons =
            GameObject.FindGameObjectsWithTag("BlackJackButton");
        foreach (var button in BlackJackButtons)
        {
            Destroy (button);
        }
    }

    // Destroy end game button
    public void DestroyEndGameButton()
    {
        var BlackJackButtons = GameObject.FindGameObjectsWithTag("GameEnded");
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
        PlayerMoney.text =
            "Player Money: " +
            CurrentPlayer.GetComponent<CurrentPlayer>().Money +
            "$";
    }
}
