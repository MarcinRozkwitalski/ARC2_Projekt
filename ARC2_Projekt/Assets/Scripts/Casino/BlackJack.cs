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

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        PlayerMoney.text = "Player Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money + "$";
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
        if (int.TryParse(PlayerBet.text, out int value))
            if (CorrectPrice(int.Parse(PlayerBet.text)))
                if (CurrentPlayer.GetComponent<CurrentPlayer>().Money >= int.Parse(PlayerBet.text)) Alert.text = "Correct bet"; // Game start
                else Alert.text = "Not enough money";
            else Alert.text = "Incorrect bet";
        else Alert.text = "Bad bet input";
    }

    public bool CorrectPrice(int playerBetInt)
    {
        bool correctPrice = false;
        if (playerBetInt >= 0 && playerBetInt <= 500) correctPrice = true;
        return correctPrice;
    }

    // Game start

}
