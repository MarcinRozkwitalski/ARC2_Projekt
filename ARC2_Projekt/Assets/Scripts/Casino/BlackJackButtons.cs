using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackButtons : MonoBehaviour
{
    public void Hit()
    {
        FindObjectOfType<Deck>().AddCardFromDeckToPlayer();
    }

    public void Stand()
    {
        FindObjectOfType<BlackJack>().StandAndGetPLayerValue();
    }

    public void Double()
    {
        FindObjectOfType<BlackJack>().DoubleBet();
        FindObjectOfType<Deck>().AddCardFromDeckToPlayer();
        FindObjectOfType<BlackJack>().StandAndGetPLayerValue();
    }

    public void Split()
    {
        FindObjectOfType<BlackJack>().ShowValueOnHand1();
    }

    public void GameEnded()
    {
        FindObjectOfType<BlackJack>().ResetGame();
    }
}
