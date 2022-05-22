using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Player : MonoBehaviour
{
    public Text CardsNumber;
    public int CurrentPlayerId;
    public GameObject playerCardPrefab;
    public GameObject showCardPrefab;
    public GameObject mainpanel;
    public GameObject panel;
    public GameObject deckPanel;
    public int cardsNumber;
    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        StartCoroutine(GetAllPlayerCards());
        StartCoroutine(GetAllPlayerDeckCards());
        // Screem.width do skalowania na inne ekrany
    }

    public void LoadPlayerWelcomeScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    public void AllCards()
    {
        DestroyAllPlayerCards();
        StartCoroutine(GetAllPlayerCards());
    }

    public void AttackCards()
    {
        DestroyAllPlayerCards();
        StartCoroutine(GetAllAttackCards());
    }

    public void DefenceCards()
    {
        DestroyAllPlayerCards();
        StartCoroutine(GetAllDefenceCards());
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

    IEnumerator GetAllPlayerCards()
    {
        WWWForm getAllPlayerCardsForm = new WWWForm();
        getAllPlayerCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getall.php", getAllPlayerCardsForm);
        yield return getAllPlayerCardsRequest.SendWebRequest();
        if (getAllPlayerCardsRequest.error == null)
        {
            JSONNode allPlayerCards = JSON.Parse(getAllPlayerCardsRequest.downloadHandler.text);
            if (allPlayerCards != null)
                foreach (JSONNode player_cards in allPlayerCards)
                {
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(panel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
        }
        else
        {
            Debug.Log(getAllPlayerCardsRequest.error);
        }
    }

    IEnumerator GetAllAttackCards()
    {
        WWWForm getAllAttackCardsForm = new WWWForm();
        getAllAttackCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllAttackCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllAttackCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getallattack.php", getAllAttackCardsForm);
        yield return getAllAttackCardsRequest.SendWebRequest();
        if (getAllAttackCardsRequest.error == null)
        {
            JSONNode allPlayerCards = JSON.Parse(getAllAttackCardsRequest.downloadHandler.text);
            if (allPlayerCards != null)
                foreach (JSONNode player_cards in allPlayerCards)
                {
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(panel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
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
        UnityWebRequest getAllDefenceCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getalldefence.php", getAllDefenceCardsForm);
        yield return getAllDefenceCardsRequest.SendWebRequest();
        if (getAllDefenceCardsRequest.error == null)
        {
            JSONNode allPlayerCards = JSON.Parse(getAllDefenceCardsRequest.downloadHandler.text);
            if (allPlayerCards != null)
                foreach (JSONNode player_cards in allPlayerCards)
                {
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(panel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
        }
        else
        {
            Debug.Log(getAllDefenceCardsRequest.error);
        }
    }

    public void DestroyAllPlayerCards()
    {
        var playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in playerCards)
        {
            if (!card.GetComponent<PlayerCard>().IsCardEquipped()) Destroy(card);
        }
    }

    public void DestroyAllPlayerDeckCards()
    {
        var playerCards = GameObject.FindGameObjectsWithTag("PlayerCard");
        foreach (var card in playerCards)
        {
            if (card.GetComponent<PlayerCard>().IsCardEquipped()) Destroy(card);
        }
    }

    // continue
    IEnumerator GetAllPlayerDeckCards()
    {
        WWWForm getAllPlayerDeckCardsForm = new WWWForm();
        getAllPlayerDeckCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllPlayerDeckCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getalldeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            cardsNumber = 0;
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    cardsNumber++;
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(deckPanel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
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
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getallattackdeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(deckPanel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
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
        UnityWebRequest getAllPlayerDeckCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getalldefencedeckcards.php", getAllPlayerDeckCardsForm);
        yield return getAllPlayerDeckCardsRequest.SendWebRequest();
        if (getAllPlayerDeckCardsRequest.error == null)
        {
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var playerCard = Instantiate(playerCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    playerCard.transform.SetParent(deckPanel.transform);
                    playerCard.GetComponent<PlayerCard>().cardname = player_cards[0];
                    playerCard.GetComponent<PlayerCard>().type = player_cards[1];
                    playerCard.GetComponent<PlayerCard>().description = player_cards[2];
                    playerCard.GetComponent<PlayerCard>().price = int.Parse(player_cards[3]);
                    playerCard.GetComponent<PlayerCard>().points = int.Parse(player_cards[4]);
                    playerCard.GetComponent<PlayerCard>().healthPoints = int.Parse(player_cards[5]);
                    playerCard.GetComponent<PlayerCard>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") playerCard.GetComponent<PlayerCard>().is_equipped = false;
                    else playerCard.GetComponent<PlayerCard>().is_equipped = true;
                    playerCard.GetComponent<PlayerCard>().AssignInfo();
                }
            ;
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }

    public void AddCard(int id, bool is_equipped, string type)
    {
        StartCoroutine(AddCardToDeck(id, is_equipped, type));
    }

    IEnumerator AddCardToDeck(int id, bool is_equipped, string type)
    {
        WWWForm updateDeckForm = new WWWForm();
        updateDeckForm.AddField("apppassword", "thisisfromtheapp!");
        updateDeckForm.AddField("Id", CurrentPlayerId);
        updateDeckForm.AddField("Card_Id", id);
        if (is_equipped == false && cardsNumber < 10)
        {
            UnityWebRequest updateDeckRequest = UnityWebRequest.Post("http://localhost/playercards/addtodeck.php", updateDeckForm);
            cardsNumber++;
            CardsNumber.text = cardsNumber + "/10 cards ";
            yield return updateDeckRequest.SendWebRequest();
        }
        else if (is_equipped == true)
        {
            UnityWebRequest updateDeckRequest = UnityWebRequest.Post("http://localhost/playercards/removefromdeck.php", updateDeckForm);
            cardsNumber--;
            CardsNumber.text = cardsNumber + "/10 cards ";
            yield return updateDeckRequest.SendWebRequest();
        }
        UpdateCards(type);
    }

    public void UpdateCards(string type)
    {
        if (type == "Atak")
        {
            DestroyAllPlayerCards();
            StartCoroutine(GetAllAttackCards());
            DestroyAllPlayerDeckCards();
            StartCoroutine(GetAllAttackPlayerDeckCards());

        }
        else if (type == "Obrona")
        {
            DestroyAllPlayerCards();
            StartCoroutine(GetAllDefenceCards());
            DestroyAllPlayerDeckCards();
            StartCoroutine(GetAllDefencePlayerDeckCards());
        }
    }

    public void ShowCard(string Cardname, string Type, string Description, int Price, int Points, int HealthPoints, int Id, bool Is_equipped)
    {
        var showCard = Instantiate(showCardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        showCard.transform.SetParent(mainpanel.transform);
        RectTransform rt = showCard.GetComponent<RectTransform>();
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 21, rt.rect.width);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 489, rt.rect.height);
        Debug.Log("width = " + rt.rect.width + ", height = " + rt.rect.height);
        GameObject playerCard = showCard.transform.GetChild(0).gameObject;
        playerCard.GetComponent<PlayerCard>().cardname = Cardname;
        playerCard.GetComponent<PlayerCard>().type = Type;
        playerCard.GetComponent<PlayerCard>().description = Description;
        playerCard.GetComponent<PlayerCard>().price = Price;
        playerCard.GetComponent<PlayerCard>().points = Points;
        playerCard.GetComponent<PlayerCard>().healthPoints = HealthPoints;
        playerCard.GetComponent<PlayerCard>().id = Id;
        playerCard.GetComponent<PlayerCard>().is_equipped = Is_equipped;
        playerCard.GetComponent<PlayerCard>().AssignInfo();
    }
}