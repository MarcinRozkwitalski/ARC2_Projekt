using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class BattleCardHandler : MonoBehaviour
{
    public CardList cardList;

    public GameObject BattleCardsInfoPrefab;
    public GameObject cardsDeckToPick;
    public GameObject usedCardsPanel;
    public GameObject cardsOnHandRevealPanel;
    public GameObject CurrentPlayer;

    void Awake()
    {
        cardList = GameObject.Find("CardManager").GetComponent<CardList>();
        GetAllPlayerDeckCards();
    }

    public void GetAllPlayerDeckCards()
    {
        foreach(var card in cardList.cardsList)
        {
            if(card.is_equipped == true && card.bought == true)
            {
                var BattleCardsInfo = Instantiate(BattleCardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                BattleCardsInfo.transform.SetParent(cardsDeckToPick.transform);
                CheckSubtype(BattleCardsInfo, card.card_subtype);
                BattleCardsInfo.GetComponent<BattleCardInfo>().cardname = card.card_name;
                BattleCardsInfo.GetComponent<BattleCardInfo>().type = card.card_subtype;
                BattleCardsInfo.GetComponent<BattleCardInfo>().description = card.card_description;
                BattleCardsInfo.GetComponent<BattleCardInfo>().price = card.price;
                BattleCardsInfo.GetComponent<BattleCardInfo>().points = card.points;
                BattleCardsInfo.GetComponent<BattleCardInfo>().healthPoints = card.health_points;
                BattleCardsInfo.GetComponent<BattleCardInfo>().id = card.id;
                BattleCardsInfo.GetComponent<BattleCardInfo>().is_equipped = true;
                BattleCardsInfo.GetComponent<BattleCardInfo>().AssignInfo();
            }
        }
    }

    public void CheckSubtype(GameObject cardInfo, string subtype)
    {
        switch (subtype)
        {
            case "Atak":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
                break;
            case "Obrona":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Ogluszenie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Leczenie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Oslabienie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Pospiech":
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Wzmocnienie":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Wytrwalosc":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Tecza":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
            case "Ulepszenie":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
                break;
        }
    }
}
