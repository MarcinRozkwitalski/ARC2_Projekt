using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerGameScript : MonoBehaviour
{
    public void SignOut()
    {
        var CurrentPlayers = GameObject.FindGameObjectsWithTag("CurrentPlayer");
        foreach(var item in CurrentPlayers)
        {
            Destroy(item);
        }
        FindObjectOfType<SceneSwitcher>().LoadWelcomeScene();
    }
}
