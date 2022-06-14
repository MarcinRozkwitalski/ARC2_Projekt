using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class BattleCardHandler : MonoBehaviour
{
    public int CurrentPlayerId;
    public GameObject BattleCardsInfoPrefab;
    public GameObject playerCardsPanel;
    public GameObject CurrentPlayer;

    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        CurrentPlayerId = CurrentPlayer.GetComponent<CurrentPlayer>().Id;
        StartCoroutine(GetAllPlayerDeckCards());
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
            JSONNode allPlayerDeckCards = JSON.Parse(getAllPlayerDeckCardsRequest.downloadHandler.text);
            if (allPlayerDeckCards != null)
                foreach (JSONNode player_cards in allPlayerDeckCards)
                {
                    var BattleCardsInfo = Instantiate(BattleCardsInfoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    BattleCardsInfo.transform.SetParent(playerCardsPanel.transform);
                    BattleCardsInfo.GetComponent<BattleCardInfo>().cardname = player_cards[0];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().type = player_cards[1];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().description = player_cards[2];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().points = int.Parse(player_cards[4]);
                    BattleCardsInfo.GetComponent<BattleCardInfo>().healthPoints = int.Parse(player_cards[5]);
                    BattleCardsInfo.GetComponent<BattleCardInfo>().id = int.Parse(player_cards[6]);
                    if (player_cards[7] == "0") BattleCardsInfo.GetComponent<BattleCardInfo>().is_equipped = false;
                    else BattleCardsInfo.GetComponent<BattleCardInfo>().is_equipped = true;
                    BattleCardsInfo.GetComponent<BattleCardInfo>().AssignInfo();
                }
            ;
        }
        else
        {
            Debug.Log(getAllPlayerDeckCardsRequest.error);
        }
    }
}
