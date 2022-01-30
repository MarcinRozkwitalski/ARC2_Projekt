using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public string Username;
    public string Email;
    public int Money;
    public int Life;
    public int Level;

    private void Awake()
    {
        var players = FindObjectsOfType<CurrentPlayer>();
        if(players.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
