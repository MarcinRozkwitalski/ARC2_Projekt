using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackButtons : MonoBehaviour
{
    public void Hit()
    {
        FindObjectOfType<Deck>().AddCardFromDeckToPlayer();
        FindObjectOfType<BlackJack>().ShowValueOnHand1();
    }

    public void Stand()
    {
        FindObjectOfType<BlackJack>().ShowValueOnHand1();
    }

    public void Double()
    {
        FindObjectOfType<Deck>().AddCardFromDeckToPlayer();
        FindObjectOfType<BlackJack>().ShowValueOnHand1();
    }

    public void Split()
    {
        FindObjectOfType<BlackJack>().ShowValueOnHand1();
    }
}
