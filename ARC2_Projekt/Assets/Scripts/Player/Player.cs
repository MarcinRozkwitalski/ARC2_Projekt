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
    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        StartCoroutine(GetAllPlayerCards());
    }

    public void LoadPlayerWelcomeScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
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
                playerCard.GetComponent<PlayerCard>().AssignInfo();
            }
        }
        else
        {
            Debug.Log(getAllPlayerCardsRequest.error);
        }
    }
}
