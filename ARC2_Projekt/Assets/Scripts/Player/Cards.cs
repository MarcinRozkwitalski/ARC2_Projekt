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
    public TMP_Text CardsNumber;

    public TMP_Text PlayerMoney;

    public int CurrentPlayerId;

    public GameObject CardsInfoPrefab;

    public GameObject showCardPrefab;

    public GameObject mainpanel;

    public GameObject panel;

    public GameObject shoppanel;

    public GameObject deckPanel;

    public GameObject CurrentPlayer;

    public int cardsNumber;

    public string sceneName;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Cards")
        {
            StartCoroutine(GetAllCardsInfos());
            StartCoroutine(GetAllPlayerDeckCards());
        }
        if (sceneName == "Shop")
        {
            PlayerMoney.text = "Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money;
            StartCoroutine(GetAllShopCards());
        }
        // Screem.width do skalowania na inne ekrany
    }

    public void LoadPlayerWelcomeScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    public void AllCards()
    {
        DestroyAllCardsInfos();
        StartCoroutine(GetAllCardsInfos());
    }

    public void AttackCards()
    {
        DestroyAllCardsInfos();
        StartCoroutine(GetAllAttackCards());
    }

    public void DefenceCards()
    {
        DestroyAllCardsInfos();
        StartCoroutine(GetAllDefenceCards());
    }

    public void SpecialCards()
    {
        DestroyAllCardsInfos();
        StartCoroutine(GetAllSpecialCards());
    }

    public void AllDeckCards()
    {
        DestroyAllPlayerDeckCards();
        StartCoroutine(GetAllPlayerDeckCards());
    }

    public void AttackDeckCards()
    {
        DestroyAllPlayerDeckCards();
        StartCoroutine(GetAllAttackPlayerDeckCards());
    }

    public void DefenceDeckCards()
    {
        DestroyAllPlayerDeckCards();
        StartCoroutine(GetAllDefencePlayerDeckCards());
    }

    public void SpecialDeckCards()
    {
        DestroyAllPlayerDeckCards();
        StartCoroutine(GetAllSpecialPlayerDeckCards());
    }

    public void AllShopCards()
    {
        DestroyAllShopCards();
        PlayerMoney.text = "Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money;
        StartCoroutine(GetAllShopCards());
    }

    public void AllShopAttackCards()
    {
        DestroyAllShopCards();
        StartCoroutine(GetAllShopAttackCards());
    }

    public void AllShopDefenceCards()
    {
        DestroyAllShopCards();
        StartCoroutine(GetAllShopDefenceCards());
    }

     public void AllShopSpecialCards()
    {
        DestroyAllShopCards();
        StartCoroutine(GetAllShopSpecialCards());
    }

    IEnumerator GetAllCardsInfos()
    {
        WWWForm getAllCardsInfosForm = new WWWForm();
        getAllCardsInfosForm.AddField("apppassword", "thisisfromtheapp!");
        getAllCardsInfosForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllCardsInfosRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getall.php", getAllCardsInfosForm);
        yield return getAllCardsInfosRequest.SendWebRequest();
        if (getAllCardsInfosRequest.error == null)
        {
            JSONNode allCardsInfos = JSON.Parse(getAllCardsInfosRequest.downloadHandler.text);
            if (allCardsInfos != null)
                foreach (JSONNode player_cards in allCardsInfos)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(panel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllCardsInfosRequest.error);
        }
    }

    IEnumerator GetAllAttackCards()
    {
        WWWForm getAllAttackCardsForm = new WWWForm();
        getAllAttackCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllAttackCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllAttackCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallattack.php", getAllAttackCardsForm);
        yield return getAllAttackCardsRequest.SendWebRequest();
        if (getAllAttackCardsRequest.error == null)
        {
            JSONNode allCardsInfos = JSON.Parse(getAllAttackCardsRequest.downloadHandler.text);
            if (allCardsInfos != null)
                foreach (JSONNode player_cards in allCardsInfos)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(panel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllAttackCardsRequest.error);
        }
    }

    IEnumerator GetAllDefenceCards()
    {
        WWWForm getAllDefenceCardsForm = new WWWForm();
        getAllDefenceCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllDefenceCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllDefenceCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getalldefence.php", getAllDefenceCardsForm);
        yield return getAllDefenceCardsRequest.SendWebRequest();
        if (getAllDefenceCardsRequest.error == null)
        {
            JSONNode allCardsInfos = JSON.Parse(getAllDefenceCardsRequest.downloadHandler.text);
            if (allCardsInfos != null)
                foreach (JSONNode player_cards in allCardsInfos)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(panel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllDefenceCardsRequest.error);
        }
    }

     IEnumerator GetAllSpecialCards()
    {
        WWWForm getAllDefenceCardsForm = new WWWForm();
        getAllDefenceCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllDefenceCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllDefenceCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallspecial.php", getAllDefenceCardsForm);
        yield return getAllDefenceCardsRequest.SendWebRequest();
        if (getAllDefenceCardsRequest.error == null)
        {
            JSONNode allCardsInfos = JSON.Parse(getAllDefenceCardsRequest.downloadHandler.text);
            if (allCardsInfos != null)
                foreach (JSONNode player_cards in allCardsInfos)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(panel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllDefenceCardsRequest.error);
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
            Destroy (card);
        }
    }

    public void DestroyAllShopCards()
    {
        var CardsInfos = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in CardsInfos)
        {
            Destroy (card);
        }
    }

    IEnumerator GetAllPlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getalldeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards =
                JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            cardsNumber = 0;
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    cardsNumber++;
                    var CardsInfo = Instantiate(CardsInfoPrefab,new Vector3(0, 0, 0),Quaternion.identity);
                    CardsInfo.transform.SetParent(deckPanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }

            CardsNumber.text = cardsNumber + "/10 cards ";
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }

    IEnumerator GetAllAttackPlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallattackdeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(deckPanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }

    IEnumerator GetAllDefencePlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest =
            UnityWebRequest
                .Post("http://localhost/CardsInfos/getalldefencedeckcards.php",
                getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(deckPanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }

     IEnumerator GetAllSpecialPlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallspecialdeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(deckPanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") CardsInfo.GetComponent<CardsInfo>().is_equipped = false;
                    else                        CardsInfo.GetComponent<CardsInfo>().is_equipped = true;
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
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
        StartCoroutine(AddRemoveCard(id, is_equipped, type));
    }

    IEnumerator AddRemoveCard(int id, bool is_equipped, string type)
    {
        WWWForm updateDeckForm = new WWWForm();
        updateDeckForm.AddField("apppassword", "thisisfromtheapp!");
        updateDeckForm.AddField("Id", CurrentPlayerId);
        updateDeckForm.AddField("Card_Id", id);
        if (is_equipped == false && cardsNumber < 10)
        {
            UnityWebRequest updateDeckRequest = UnityWebRequest.Post("http://localhost/CardsInfos/addtodeck.php", updateDeckForm);
            cardsNumber++;
            CardsNumber.text = cardsNumber + "/10 cards ";
            yield return updateDeckRequest.SendWebRequest();
        }
        else if (is_equipped == true)
        {
            UnityWebRequest updateDeckRequest = UnityWebRequest.Post("http://localhost/CardsInfos/removefromdeck.php", updateDeckForm);
            cardsNumber--;
            CardsNumber.text = cardsNumber + "/10 cards ";
            yield return updateDeckRequest.SendWebRequest();
        }
        UpdateCards (type);
    }

    public void UpdateCards(string type)
    {
        if (type == "Atak")
        {
            DestroyAllCardsInfos();
            StartCoroutine(GetAllAttackCards());
            DestroyAllPlayerDeckCards();
            StartCoroutine(GetAllAttackPlayerDeckCards());
        }
        else if (type == "Obrona")
        {
            DestroyAllCardsInfos();
            StartCoroutine(GetAllDefenceCards());
            DestroyAllPlayerDeckCards();
            StartCoroutine(GetAllDefencePlayerDeckCards());
        }
        else
        {
            DestroyAllCardsInfos();
            StartCoroutine(GetAllSpecialCards());
            DestroyAllPlayerDeckCards();
            StartCoroutine(GetAllSpecialPlayerDeckCards());
        }
    }

    public void ShowCard(
        string Cardname,
        string Type,
        string Description,
        int Price,
        int Points,
        int HealthPoints,
        int Id,
        bool Is_equipped
    )
    {
        var showCard =
            Instantiate(showCardPrefab,
            new Vector3(0, 0, 0),
            Quaternion.identity);
        showCard.transform.SetParent(mainpanel.transform);
        showCard.transform.position = new Vector3(960, 540, 0);
        CheckAddRemoveButton (Is_equipped, showCard);
        StartCoroutine(CheckBuySellButton(Id, showCard));
        CheckSubtype(showCard, Type);
        showCard.GetComponent<CardsInfo>().cardname = Cardname;
        showCard.GetComponent<CardsInfo>().type = Type;
        showCard.GetComponent<CardsInfo>().description = Description;
        if (sceneName == "Shop")
        {
            showCard.GetComponent<CardsInfo>().price = Price;
            showCard.transform.Find("AddToDeck").gameObject.SetActive(false); // nowa metoda na przyciski (zmienić kod?)
        }
        else if (sceneName == "Cards")  showCard.GetComponent<CardsInfo>().price = Price / 2;

        showCard.GetComponent<CardsInfo>().points = Points;
        showCard.GetComponent<CardsInfo>().healthPoints = HealthPoints;
        showCard.GetComponent<CardsInfo>().id = Id;
        showCard.GetComponent<CardsInfo>().is_equipped = Is_equipped;
        showCard.GetComponent<CardsInfo>().AssignInfo();
    }

    public void SellCardFromInventory(
        int id,
        int price,
        string type,
        bool is_equipped
    )
    {
        StartCoroutine(SellCard(id, price, type, is_equipped));
    }

    IEnumerator SellCard(int id, int price, string type, bool is_equipped)
    {
        WWWForm sellCardForm = new WWWForm();
        sellCardForm.AddField("apppassword", "thisisfromtheapp!");
        sellCardForm.AddField("Id", CurrentPlayerId);
        sellCardForm.AddField("Card_Id", id);
        sellCardForm.AddField("Price", price + CurrentPlayer.GetComponent<CurrentPlayer>().Money);
        UnityWebRequest sellCardRequest = UnityWebRequest.Post("http://localhost/CardsInfos/sellcard.php", sellCardForm);
        if (sellCardRequest.error == null)
        {
            if (is_equipped == true)
            {
                cardsNumber--;
                CardsNumber.text = cardsNumber + "/10 cards ";
            }
            yield return sellCardRequest.SendWebRequest();

            CurrentPlayer.GetComponent<CurrentPlayer>().Money += price;
            UpdateCards (type);
        }
    }

    public void BuyCardFromInventory(int id, int price)
    {
        if (CurrentPlayer.GetComponent<CurrentPlayer>().Money >= price) StartCoroutine(BuyCard(id, price));
    }

    IEnumerator BuyCard(int id, int price)
    {
        WWWForm buyCardForm = new WWWForm();
        buyCardForm.AddField("apppassword", "thisisfromtheapp!");
        buyCardForm.AddField("Id", CurrentPlayerId);
        buyCardForm.AddField("Card_Id", id);
        buyCardForm.AddField("Price", CurrentPlayer.GetComponent<CurrentPlayer>().Money - price);
        CurrentPlayer.GetComponent<CurrentPlayer>().Money -= price;
        UnityWebRequest buyCardRequest = UnityWebRequest.Post("http://localhost/CardsInfos/buycard.php", buyCardForm);
        if (buyCardRequest.error == null)
        {
            yield return buyCardRequest.SendWebRequest();
            AllShopCards();
        }
    }

    public void CheckAddRemoveButton(bool is_equipped, GameObject showCard)
    {
        if (is_equipped == true)    showCard.transform.Find("AddToDeck").gameObject.SetActive(false);
        else                        showCard.transform.Find("RemoveFromDeck").gameObject.SetActive(false);
    }

    IEnumerator CheckBuySellButton(int card_id, GameObject showCard)
    {
        WWWForm sellCardForm = new WWWForm();
        sellCardForm.AddField("apppassword", "thisisfromtheapp!");
        sellCardForm.AddField("Id", CurrentPlayerId);
        sellCardForm.AddField("Card_Id", card_id);
        UnityWebRequest sellCardRequest = UnityWebRequest.Post("http://localhost/CardsInfos/ownercard.php", sellCardForm);
        yield return sellCardRequest.SendWebRequest();
        if (sellCardRequest.error == null)
        {
            JSONNode allShopCards = JSON.Parse(sellCardRequest.downloadHandler.text);
            if (allShopCards != null)
            {
                showCard.transform.Find("Buy").gameObject.SetActive(false);
            }
            else
            {
                showCard.transform.Find("Sell").gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log(sellCardRequest.error);
        }
    }

    IEnumerator GetAllShopCards()
    {
        WWWForm getAllShopCardsForm = new WWWForm();
        getAllShopCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllShopCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllShopCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/allshopcards.php", getAllShopCardsForm);
        yield return getAllShopCardsRequest.SendWebRequest();
        if (getAllShopCardsRequest.error == null)
        {
            JSONNode allShopCards = JSON.Parse(getAllShopCardsRequest.downloadHandler.text);
            if (allShopCards != null)
                foreach (JSONNode player_cards in allShopCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(shoppanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllShopCardsRequest.error);
        }
    }

    IEnumerator GetAllShopAttackCards()
    {
        WWWForm getAllShopCardsForm = new WWWForm();
        getAllShopCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllShopCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllShopCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallshopattack.php", getAllShopCardsForm);
        yield return getAllShopCardsRequest.SendWebRequest();
        if (getAllShopCardsRequest.error == null)
        {
            JSONNode allShopCards = JSON.Parse(getAllShopCardsRequest.downloadHandler.text);
            if (allShopCards != null)
                foreach (JSONNode player_cards in allShopCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(shoppanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllShopCardsRequest.error);
        }
    }

    IEnumerator GetAllShopDefenceCards()
    {
        WWWForm getAllShopCardsForm = new WWWForm();
        getAllShopCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllShopCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllShopCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallshopdefence.php", getAllShopCardsForm);
        yield return getAllShopCardsRequest.SendWebRequest();
        if (getAllShopCardsRequest.error == null)
        {
            JSONNode allShopCards = JSON.Parse(getAllShopCardsRequest.downloadHandler.text);
            if (allShopCards != null)
                foreach (JSONNode player_cards in allShopCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(shoppanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllShopCardsRequest.error);
        }
    }

     IEnumerator GetAllShopSpecialCards()
    {
        WWWForm getAllShopCardsForm = new WWWForm();
        getAllShopCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllShopCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllShopCardsRequest = UnityWebRequest.Post("http://localhost/CardsInfos/getallshopspecial.php", getAllShopCardsForm);
        yield return getAllShopCardsRequest.SendWebRequest();
        if (getAllShopCardsRequest.error == null)
        {
            JSONNode allShopCards = JSON.Parse(getAllShopCardsRequest.downloadHandler.text);
            if (allShopCards != null)
                foreach (JSONNode player_cards in allShopCards)
                {
                    var CardsInfo = Instantiate(CardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    CardsInfo.transform.SetParent(shoppanel.transform);
                    CheckSubtype(CardsInfo, player_cards[1]);
                    CardsInfo.GetComponent<CardsInfo>().cardname = player_cards[0];
                    CardsInfo.GetComponent<CardsInfo>().type = player_cards[1];
                    CardsInfo.GetComponent<CardsInfo>().description = player_cards[2];
                    CardsInfo.GetComponent<CardsInfo>().price = int.Parse(player_cards[3]);
                    CardsInfo.GetComponent<CardsInfo>().points = int.Parse(player_cards[4]);
                    CardsInfo.GetComponent<CardsInfo>().healthPoints = int.Parse(player_cards[5]);
                    CardsInfo.GetComponent<CardsInfo>().id = int.Parse(player_cards[6]);
                    CardsInfo.GetComponent<CardsInfo>().AssignInfo();
                }
        }
        else
        {
            Debug.Log(getAllShopCardsRequest.error);
        }
    }
}
