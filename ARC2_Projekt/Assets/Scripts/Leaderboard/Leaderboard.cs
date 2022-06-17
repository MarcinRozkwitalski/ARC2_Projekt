using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Leaderboard : MonoBehaviour
{
    public GameObject leaderPrefab;
    public GameObject panel;

    public InputField searchInput;
    public Button searchButton;
    public TMP_Text searchButtonText;
    void Start()
    {
        StartCoroutine(GetAllPlayers());
    }

    public void LoadPlayerWelcomeScene()
    {
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    IEnumerator GetAllPlayers()
    {
        WWWForm getAllPlayersForm = new WWWForm();
        getAllPlayersForm.AddField("apppassword", "thisisfromtheapp!");
        UnityWebRequest getAllPlayersRequest = UnityWebRequest.Post("http://localhost/leaderboard/getall.php", getAllPlayersForm);
        yield return getAllPlayersRequest.SendWebRequest();
        if (getAllPlayersRequest.error == null)
        {
            int rank = 1;
            JSONNode allPlayers = JSON.Parse(getAllPlayersRequest.downloadHandler.text);
            foreach (JSONNode player in allPlayers)
            {
                var leaderboardPlayer = Instantiate(leaderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                leaderboardPlayer.transform.SetParent(panel.transform);
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().username = player[0];
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().score = int.Parse(player[1]);
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().rank = rank;
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().AssignInfo();
                rank++;
            }
        }
        else
        {
            Debug.Log(getAllPlayersRequest.error);
        }
    }

    public void Search()
    {
        DestroyAllLeaderboardPlayers();
        DisableSearchButton();
        if(searchInput.text == "")
        {
            StartCoroutine(GetAllPlayers());
            ResetSearchButton();
        } 
        else 
        {
            StartCoroutine(SearchForPlayer());
        }
    }

    IEnumerator SearchForPlayer()
    {
        WWWForm searchForm = new WWWForm();
        searchForm.AddField("apppassword", "thisisfromtheapp!");
        searchForm.AddField("search", searchInput.text);
        UnityWebRequest searchForPlayerRequest = UnityWebRequest.Post("http://localhost/leaderboard/search.php", searchForm);
        yield return searchForPlayerRequest.SendWebRequest();
        if (searchForPlayerRequest.error == null)
        {
            Debug.Log(searchForPlayerRequest.downloadHandler.text);
            JSONNode allPlayers = JSON.Parse(searchForPlayerRequest.downloadHandler.text);
            foreach (JSONNode player in allPlayers)
            {
                var leaderboardPlayer = Instantiate(leaderPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                leaderboardPlayer.transform.SetParent(panel.transform);
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().username = player[0];
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().score = int.Parse(player[1]);
                leaderboardPlayer.GetComponent<LeaderboardPlayer>().AssignSearchInfo();
            }
        }
        else
        {
            Debug.Log(searchForPlayerRequest.error);
        }
        ResetSearchButton();
    }

    public void DisableSearchButton()
    {
        searchButtonText.text = "Searching...";
        searchButton.GetComponent<Image>().color = Color.grey;
        searchButton.interactable = false;
    }

    public void ResetSearchButton()
    {
        searchButtonText.text = "Search";
        searchButton.GetComponent<Image>().color = Color.white;
        searchButton.interactable = true;
    }

    public void DestroyAllLeaderboardPlayers()
    {
        var leaderboardPlayers = GameObject.FindGameObjectsWithTag("LeaderboardPlayer");
        foreach (var player in leaderboardPlayers)
        {
            Destroy(player);
        }
    }

}
