using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
    public Text MoneyText;
    public GameObject CurrentPlayer;
    void Start()
    {
        CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        UpdateMoneyText();
    }

    public void Add10Money()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Money += 10;
        UpdateMoneyText();
    }

    public void Add100Money()
    {
        CurrentPlayer.GetComponent<CurrentPlayer>().Money += 100;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        MoneyText.text = "Money: " + CurrentPlayer.GetComponent<CurrentPlayer>().Money.ToString();
    }

    public void EndGame()
    {
        StartCoroutine(SavePlayerMoney());
        FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
    }

    IEnumerator SavePlayerMoney()
    {        
        string username = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        string moneyFromPlayer = CurrentPlayer.GetComponent<CurrentPlayer>().Money.ToString();
        WWWForm moneyForm = new WWWForm();
        moneyForm.AddField("apppassword","thisisfromtheapp!");
        moneyForm.AddField("username", username);
        moneyForm.AddField("money", moneyFromPlayer);
        UnityWebRequest updatePlayerRequest = UnityWebRequest.Post("http://localhost/arcCruds/updateplayermoney.php", moneyForm);
        yield return updatePlayerRequest.SendWebRequest();
        if (updatePlayerRequest.error == null)
        {
            string result = updatePlayerRequest.downloadHandler.text;
            Debug.Log(result);
            if (result == "0"){
                Debug.Log("good to go");
            } else {
                Debug.Log("Error!");
            }
        } else {
            Debug.Log(updatePlayerRequest.error);
        }
    }
}
