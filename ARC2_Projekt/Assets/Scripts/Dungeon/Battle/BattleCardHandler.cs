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
    public GameObject cardsDeckToPick;
    public GameObject usedCardsPanel;
    public GameObject cardsOnHandRevealPanel;
    public GameObject CurrentPlayer;

    void Awake()
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
                    BattleCardsInfo.transform.SetParent(cardsDeckToPick.transform);
                    CheckSubtype(BattleCardsInfo, player_cards[1]);
                    BattleCardsInfo.GetComponent<BattleCardInfo>().cardname = player_cards[0];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().type = player_cards[1];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().description = player_cards[2];
                    BattleCardsInfo.GetComponent<BattleCardInfo>().price = int.Parse(player_cards[3]);
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
