using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public enum Suit
    {
        Clubs = '♣',
        Spades = '♠',
        Diamonds = '♦',
        Hearts = '♥'
    }

    public enum Face
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    List<Face> DeckFace = new List<Face>();

    List<Suit> DeckSuit = new List<Suit>();

    List<Face> PlayerDeck1Face = new List<Face>();

    List<Suit> PlayerDeck1Suit = new List<Suit>();

    Suit suit;

    Face face;

    public string number;

    public int value;

    public char symbol;

    public void GetDeck()
    {
        DeckFace.Clear();
        DeckSuit.Clear();
        PlayerDeck1Face.Clear();
        PlayerDeck1Suit.Clear();

        for (int i = 1; i < 14; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Cardsymbol (i, j);
                DeckFace.Add (face);
                DeckSuit.Add (suit);
            }
        }
        for (int i = 0; i < 52; i++)
        {
            Debug.Log(DeckFace[i] + " - " + (char) DeckSuit[i]);
        }
    }

    public void AddCardFromDeckToPlayer()
    {
        int cardNumber = Random.Range(1, DeckFace.Count);
        PlayerDeck1Face.Add(DeckFace[cardNumber]);
        PlayerDeck1Suit.Add(DeckSuit[cardNumber]);
        DeckFace.Remove(DeckFace[cardNumber]);
        DeckSuit.Remove(DeckSuit[cardNumber]);
    }

    public void GetPlayerCard()
    {
        foreach (Face entry in PlayerDeck1Face)
        {
            Debug.Log(" [" + entry + "] = " + (int) entry);
        }
        foreach (Suit entry in PlayerDeck1Suit)
        {
            Debug.Log(" [" + entry + "] = " + (char) entry);
        }
        for (int i = 0; i < DeckFace.Count; i++)
        {
            Debug.Log(DeckFace[i] + " - " + (char) DeckSuit[i]);
        }
    }

    public void GetPlayerDeckFaceDebug(int a)
    {
       Debug.Log((int) PlayerDeck1Face[a]);
    }

    public void GetPlayerDeckSuitDebug(int a)
    {
        Debug.Log((int)PlayerDeck1Suit[a]);
    }

    public int GetPlayerDeckFace(int a)
    {
        return (int) PlayerDeck1Face[a];
    }

    public char GetPlayerDeckSuit(int a)
    {
        return (char) PlayerDeck1Suit[a];
    }

    public void Cardsymbol(int i, int j)
    {
        Symbol (j);
        Value (i);

        switch (suit)
        {
            case Suit.Clubs:
                symbol = '♣';
                break;
            case Suit.Spades:
                symbol = '♠';
                break;
            case Suit.Diamonds:
                symbol = '♦';
                break;
            case Suit.Hearts:
                symbol = '♥';
                break;
        }
    }

    public Suit Symbol(int j)
    {
        suit = Suit.Hearts;
        switch (j)
        {
            case 0:
                suit = Suit.Clubs;
                return suit;
            case 1:
                suit = Suit.Spades;
                return suit;
            case 2:
                suit = Suit.Diamonds;
                return suit;
            case 3:
                suit = Suit.Hearts;
                return suit;
        }
        return suit;
    }

    public Face Value(int i)
    {
        face = Face.Ten;
        switch (i)
        {
            case 1:
                face = Face.Ace;
                return face;
            case 2:
                face = Face.Two;
                return face;
            case 3:
                face = Face.Three;
                return face;
            case 4:
                face = Face.Four;
                return face;
            case 5:
                face = Face.Five;
                return face;
            case 6:
                face = Face.Six;
                return face;
            case 7:
                face = Face.Seven;
                return face;
            case 8:
                face = Face.Eight;
                return face;
            case 9:
                face = Face.Nine;
                return face;
            case 10:
                face = Face.Ten;
                return face;
            case 11:
                face = Face.Jack;
                return face;
            case 12:
                face = Face.Queen;
                return face;
            case 13:
                face = Face.King;
                return face;
        }
        return face;
    }
}
