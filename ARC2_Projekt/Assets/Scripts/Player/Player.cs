using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    void Start()
    {
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
        UnityWebRequest getAllPlayerCardsRequest = UnityWebRequest.Post("http://localhost/playercards/getall.php", getAllPlayerCardsForm);
        yield return getAllPlayerCardsRequest.SendWebRequest();
        if (getAllPlayerCardsRequest.error == null)
        {
            Debug.LogError("good to go!");
        }else
        {
            Debug.Log(getAllPlayerCardsRequest.error);
        }
    }
}
