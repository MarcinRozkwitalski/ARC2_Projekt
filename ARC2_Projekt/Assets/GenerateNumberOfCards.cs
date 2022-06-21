using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GenerateNumberOfCards : MonoBehaviour
{
    public GameObject usedCardsNumber;
    public GameObject deckToPickNumber;

    public TMP_Text usedCardsNumberText;
    public TMP_Text deckToPickNumberText;

    public GameObject usedCardsPanel;
    public GameObject cardsDeckToPick;
    
    void Start()
    {
        usedCardsNumber = GameObject.Find("UsedCardsNumber");
        deckToPickNumber = GameObject.Find("DeckToPickNumber");
        usedCardsNumberText = usedCardsNumber.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        deckToPickNumberText = deckToPickNumber.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        usedCardsPanel = GameObject.Find("UsedCardsPanel");
        cardsDeckToPick = GameObject.Find("CardsDeckToPick");
    }

    void Update()
    {
        usedCardsNumberText.text = usedCardsPanel.transform.childCount.ToString();
        deckToPickNumberText.text = cardsDeckToPick.transform.childCount.ToString();
    }
}