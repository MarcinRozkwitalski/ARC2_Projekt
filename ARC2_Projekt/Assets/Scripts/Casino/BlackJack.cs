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

    public GameObject CroupierCardsPanel;

    public GameObject PlayerCardsPanel;

    public GameObject Double1Panel;

    public GameObject Double2Panel;

    public GameObject CasinoCardPrefab;

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
        PutCardsInPlayerCardsPanel(0);
        PutCardsInPlayerCardsPanel(1);
    }

    public void PutCardsInPlayerCardsPanel(int a)
    {
        // for(i = 0; i < players.Count; i){
        // }
        //  foreach (Face player_cards in PlayerDeck1Face)
        //         {
        var CasinoCard =
            Instantiate(CasinoCardPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        CasinoCard.transform.SetParent(PlayerCardsPanel.transform);
        CasinoCard.GetComponent<CasinoCard>().cardValue =
            GetComponent<Deck>().GetPlayerDeckFace(a);
        CasinoCard.GetComponent<CasinoCard>().cardSymbol =
            GetComponent<Deck>().GetPlayerDeckSuit(a);
        CasinoCard.GetComponent<CasinoCard>().AssignInfo();
        //         }
    }

    public void DestroyAllCasinoCards()
    {
        var CasinoCards = GameObject.FindGameObjectsWithTag("CasinoCard");
        foreach (var card in CasinoCards)
        {
            Destroy (card);
        }
    }
}
