using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cards : MonoBehaviour
{
    public CardList cardList;

    public TMP_Text CardsNumber;
    public TMP_Text PlayerMoney;

    public GameObject CardsInfoPrefab;
    public GameObject showCardPrefab;
    public GameObject mainpanel;
    public GameObject panel;
    public GameObject shoppanel;
    public GameObject deckPanel;
    public GameObject CurrentPlayer;
    public GameObject Tutorial;

    public GameObject BlockDeckButtons, BlockDeckCards, BlockEquipmentButtons, BlockEquipmentCards, BlockExit;
    public GameObject ObjectEquipmentCards, ObjectAttackCards, ObjectDefenceCards, ObjectSpecialCards, ObjectAllCards, ObjectDeckCards, ObjectCardsNumber_1, ObjectCardsNumber_2, ObjectSellCardsLimit, ObjectAddCardsToDeck, ObjectExit;
    public GameObject BlockShopSortCards, BlockShopExit, BlockShopCards, ShopInformation_09;

    public int cardsNumber;
    public string sceneName;

    void Start()
    {
        Tutorial = GameObject.Find("TutorialManager");
        cardList = GameObject.Find("CardManager").GetComponent<CardList>();
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Cards")
        {
            GetAllCardsInfos();
            GetAllPlayerDeckCards();
            if (Tutorial.GetComponent<Tutorial>().cards) StartCardsTutorial();
            else Unlocked();
        }
        if (sceneName == "Shop")
        {
            PlayerMoney.text = "Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money;
            GetAllShopCard();
            //jesli tutorial true
        }
    }

    public void LoadPlayerWelcomeScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    public void AllCards()
    {
        DestroyAllCardsInfos();
        GetAllCardsInfos();
    }

    public void AttackCards()
    {
        DestroyAllCardsInfos();
        GetAllAttackCards();
    }

    public void DefenceCards()
    {
        DestroyAllCardsInfos();
        GetAllDefenceCards();
    }

    public void SpecialCards()
    {
        DestroyAllCardsInfos();
        GetAllSpecialCards();
    }

    public void AllDeckCards()
    {
        DestroyAllPlayerDeckCards();
        GetAllPlayerDeckCards();
    }

    public void AttackDeckCards()
    {
        DestroyAllPlayerDeckCards();
        GetAllAttackPlayerDeckCards();
    }

    public void DefenceDeckCards()
    {
        DestroyAllPlayerDeckCards();
        GetAllDefencePlayerDeckCards();
    }

    public void SpecialDeckCards()
    {
        DestroyAllPlayerDeckCards();
        GetAllSpecialPlayerDeckCards();
    }

    public void AllShopCards()
    {
        DestroyAllShopCards();
        PlayerMoney.text = "Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        GetAllShopCard();
    }

    public void AllShopAttackCards()
    {
        DestroyAllShopCards();
        GetAllShopAttackCards();
    }

    public void AllShopDefenceCards()
    {
        DestroyAllShopCards();
        GetAllShopDefenceCards();
    }

    public void AllShopSpecialCards()
    {
        DestroyAllShopCards();
        GetAllShopSpecialCards();
    }

    public void GetAllCardsInfos()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.is_equipped == false && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(panel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllAttackCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Atak" && card.is_equipped == false && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(panel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllDefenceCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Obrona" && card.is_equipped == false && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(panel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllSpecialCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_type == "Specjalna" && card.is_equipped == false && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(panel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void DestroyAllCardsInfos()
    {
        var CardsInfos = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in CardsInfos)
        {
            if (!card.GetComponent<CardsInfo>().IsCardEquipped()) Destroy(card);
        }
    }

    public void DestroyAllPlayerDeckCards()
    {
        var CardsInfos = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in CardsInfos)
        {
            if (card.GetComponent<CardsInfo>().IsCardEquipped()) Destroy(card);
        }
    }

    public void DestroyShowCard()
    {
        var CardsInfos = GameObject.FindGameObjectsWithTag("ShowCard");
        foreach (var card in CardsInfos)
        {
            Destroy(card);
        }
    }

    public void DestroyAllShopCards()
    {
        var CardsInfos = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in CardsInfos)
        {
            Destroy(card);
        }
    }

    public void GetAllPlayerDeckCards()
    {
        cardsNumber = 0;
        foreach (var card in cardList.cardsList)
        {
            if (card.is_equipped == true && card.bought == true)
            {
                cardsNumber++;
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(deckPanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }

        CardsNumber.text = cardsNumber + "/20 cards ";
    }

    public void GetAllAttackPlayerDeckCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Atak" && card.is_equipped == true && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(deckPanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllDefencePlayerDeckCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Obrona" && card.is_equipped == true && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(deckPanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllSpecialPlayerDeckCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_type == "Specjalna" && card.is_equipped == true && card.bought == true)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(deckPanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
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

    public void MoveCard(int id, bool is_equipped, string type)
    {
        AddRemoveCard(id, is_equipped, type);
    }

    public void AddRemoveCard(int id, bool is_equipped, string type)
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.id == id && card.is_equipped == false && cardsNumber < 20)
            {
                card.is_equipped = true;
                cardsNumber++;
                CardsNumber.text = cardsNumber + "/20 cards ";
                if (Tutorial.GetComponent<Tutorial>().cards && cardsNumber == 3)
                {
                    Cards_Step_11();
                }
            }
            else if (card.id == id && card.is_equipped == true)
            {
                card.is_equipped = false;
                cardsNumber--;
                CardsNumber.text = cardsNumber + "/20 cards ";
            }
        }

        UpdateCards(type);
    }

    public void UpdateCards(string type)
    {
        if (type == "Atak")
        {
            DestroyAllCardsInfos();
            GetAllAttackCards();
            DestroyAllPlayerDeckCards();
            GetAllAttackPlayerDeckCards();
        }
        else if (type == "Obrona")
        {
            DestroyAllCardsInfos();
            GetAllDefenceCards();
            DestroyAllPlayerDeckCards();
            GetAllDefencePlayerDeckCards();
        }
        else
        {
            DestroyAllCardsInfos();
            GetAllSpecialCards();
            DestroyAllPlayerDeckCards();
            GetAllSpecialPlayerDeckCards();
        }
    }

    public void ShowCard(string Cardname, string Type, string Description, int Price, int Points, int HealthPoints, int Id, bool Is_equipped)
    {
        var showCard = Instantiate(showCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        showCard.transform.SetParent(mainpanel.transform, false);
        CheckAddRemoveButton(Is_equipped, showCard);
        CheckBuySellButton(Id, showCard);
        CheckSubtype(showCard, Type);
        showCard.GetComponent<CardsInfo>().cardname = Cardname;
        showCard.GetComponent<CardsInfo>().type = Type;
        showCard.GetComponent<CardsInfo>().description = Description;
        if (sceneName == "Shop")
        {
            showCard.GetComponent<CardsInfo>().price = Price;
            showCard.transform.Find("AddToDeck").gameObject.SetActive(false);
        }
        else if (sceneName == "Cards") showCard.GetComponent<CardsInfo>().price = Price / 2;

        showCard.GetComponent<CardsInfo>().points = Points;
        showCard.GetComponent<CardsInfo>().healthPoints = HealthPoints;
        showCard.GetComponent<CardsInfo>().id = Id;
        showCard.GetComponent<CardsInfo>().is_equipped = Is_equipped;
        showCard.GetComponent<CardsInfo>().AssignInfo();
    }

    public void SellCardFromInventory(int id, int price, string type, bool is_equipped)
    {
        SellCard(id, price, type, is_equipped);
    }

    public void SellCard(int id, int price, string type, bool is_equipped)
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.id == id && card.is_equipped == true)
            {
                card.is_equipped = false;
                card.bought = false;
                cardsNumber--;
                CardsNumber.text = cardsNumber + "/20 cards ";
            }
            else if (card.id == id && card.is_equipped == false)
            {
                card.is_equipped = false;
                card.bought = false;
            }
        }
        CurrentPlayer.GetComponent<CurrentPlayer>().Money += price;
        UpdateCards(type);
    }

    public void BuyCardFromInventory(int id, int price)
    {
        if (CurrentPlayer.GetComponent<CurrentPlayer>().Money >= price) BuyCard(id, price);
    }

    public void BuyCard(int id, int price)
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.id == id)
            {
                CurrentPlayer.GetComponent<CurrentPlayer>().Money -= card.price;
                card.bought = true;
                card.is_equipped = false;
                AllShopCards();
                if (Tutorial.GetComponent<Tutorial>().shop_card)
                {
                    Shop_Card_1();
                }
            }
        }
    }

    public void CheckAddRemoveButton(bool is_equipped, GameObject showCard)
    {
        if (is_equipped == true) showCard.transform.Find("AddToDeck").gameObject.SetActive(false);
        else showCard.transform.Find("RemoveFromDeck").gameObject.SetActive(false);
    }

    public void CheckBuySellButton(int card_id, GameObject showCard)
    {
        int howMany = 0;
        foreach (var card in cardList.cardsList)
        {
            if (card.bought == true) howMany++;
            Debug.Log("howMany: " + howMany);
        }

        foreach (var card in cardList.cardsList)
        {
            if (card_id == card.id && card.bought == true)
            {
                showCard.transform.Find("Buy").gameObject.SetActive(false);
                if (howMany < 4)
                {
                    Debug.Log("howMany: " + howMany);
                    showCard.transform.Find("Sell").gameObject.SetActive(false);
                }
            }
            else if (card_id == card.id && card.bought == false)
            {
                showCard.transform.Find("Sell").gameObject.SetActive(false);
            }
        }
    }

    public void GetAllShopCard()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.bought == false)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(shoppanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllShopAttackCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Atak" && card.bought == false)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(shoppanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllShopDefenceCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_subtype == "Obrona" && card.bought == false)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(shoppanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void GetAllShopSpecialCards()
    {
        foreach (var card in cardList.cardsList)
        {
            if (card.card_type == "Specjalna" && card.bought == false)
            {
                var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                CardsInfo.transform.SetParent(shoppanel.transform, false);
                CheckSubtype(CardsInfo, card.card_subtype);
                CardsInfo.GetComponent<CardsInfo>().cardname = card.card_name;
                CardsInfo.GetComponent<CardsInfo>().type = card.card_subtype;
                CardsInfo.GetComponent<CardsInfo>().description = card.card_description;
                CardsInfo.GetComponent<CardsInfo>().price = card.price;
                CardsInfo.GetComponent<CardsInfo>().points = card.points;
                CardsInfo.GetComponent<CardsInfo>().healthPoints = card.health_points;
                CardsInfo.GetComponent<CardsInfo>().id = card.id;
                CardsInfo.GetComponent<CardsInfo>().AssignInfo();
            }
        }
    }

    public void StartCardsTutorial()
    {
        ObjectEquipmentCards.SetActive(true);
    }

    public void Cards_Step_1()
    {
        ObjectEquipmentCards.SetActive(false);
        ObjectAttackCards.SetActive(true);
    }
    public void Cards_Step_2()
    {
        ObjectAttackCards.SetActive(false);
        ObjectDefenceCards.SetActive(true);
    }
    public void Cards_Step_3()
    {
        ObjectDefenceCards.SetActive(false);
        ObjectSpecialCards.SetActive(true);
    }
    public void Cards_Step_4()
    {
        ObjectSpecialCards.SetActive(false);
        ObjectAllCards.SetActive(true);
    }
    public void Cards_Step_5()
    {
        ObjectAllCards.SetActive(false);
        ObjectDeckCards.SetActive(true);
    }
    public void Cards_Step_6()
    {
        ObjectDeckCards.SetActive(false);
        ObjectCardsNumber_1.SetActive(true);
    }
    public void Cards_Step_7()
    {
        ObjectCardsNumber_1.SetActive(false);
        ObjectCardsNumber_2.SetActive(true);
    }
    public void Cards_Step_8()
    {
        ObjectCardsNumber_2.SetActive(false);
        ObjectSellCardsLimit.SetActive(true);
    }
    public void Cards_Step_9()
    {
        ObjectSellCardsLimit.SetActive(false);
        ObjectAddCardsToDeck.SetActive(true);
    }

    public void Cards_Step_10()
    {
        ObjectAddCardsToDeck.SetActive(false);
        BlockEquipmentButtons.SetActive(false);
        BlockEquipmentCards.SetActive(false);
    }
    public void Cards_Step_11()
    {
        ObjectExit.SetActive(true);
        BlockEquipmentButtons.SetActive(true);
        BlockEquipmentCards.SetActive(true);
    }

    public void Cards_Step_12()
    {
        ObjectExit.SetActive(false);
        BlockExit.SetActive(false);
        Tutorial.GetComponent<Tutorial>().cards = false;
    }

    public void Unlocked()
    {
        BlockDeckButtons.SetActive(false);
        BlockDeckCards.SetActive(false);
        BlockEquipmentButtons.SetActive(false);
        BlockEquipmentCards.SetActive(false);
        BlockExit.SetActive(false);
        ObjectEquipmentCards.SetActive(false);
    }

    public void Shop_Card_1()
    {
        BlockShopSortCards.SetActive(true);
        BlockShopCards.SetActive(true);
        BlockShopExit.SetActive(true);
        ShopInformation_09.SetActive(true);
    }

    public void Shop_Card_2()
    {
        BlockShopExit.SetActive(false);
        ShopInformation_09.SetActive(false);
    }
}
