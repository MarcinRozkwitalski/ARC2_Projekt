using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Player : MonoBehaviour
{
    public int CurrentPlayerId;
    public GameObject playerCardPrefab;
    public GameObject panel;
    public GameObject deckPanel;
    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        StartCoroutine(GetAllPlayerCards());
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
                playerCard.GetComponent<PlayerCard>().AssignInfo();
            }
        }
        else
        {
            Debug.Log(getAllPlayerCardsRequest.error);
        }
    }

    public void AttackCards()
    {
        DestroyAllPlayerCards();
        StartCoroutine(GetAllAttackCards());
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
                playerCard.GetComponent<PlayerCard>().AssignInfo();
            }
        }
        else
        {
            Debug.Log(getAllAttackCardsRequest.error);
        }
    }

    public void DefenceCards()
    {
        DestroyAllPlayerCards();
        StartCoroutine(GetAllDefenceCards());
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
                playerCard.GetComponent<PlayerCard>().AssignInfo();
            }
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
            Destroy(card);
        }
    }

    // continue
    public void AddCard(){
        StartCoroutine(AddCardToDeck());
    }

    IEnumerator AddCardToDeck()
    {
        WWWForm getAllDefenceCardsForm = new WWWForm();
        getAllDefenceCardsForm.AddField("apppassword", "thisisfromtheapp!");
        getAllDefenceCardsForm.AddField("Id", CurrentPlayerId);
        UnityWebRequest getAllDefenceCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getalldefence.php", getAllDefenceCardsForm);
        yield return getAllDefenceCardsRequest.SendWebRequest();
    }

}