using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayer : MonoBehaviour
{
    public string Username = "Gracz";
    public int Money = 500;
    public int Life = 100;
    public int Level = 1;

    private void Awake()
    {   
        DefaultValues();
        var players = FindObjectsOfType<CurrentPlayer>();
        if(players.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void DefaultValues()
    {
        this.Username = "Gracz";
        this.Money = 500;
        this.Life = 100;
        this.Level = 1;
    }
}
