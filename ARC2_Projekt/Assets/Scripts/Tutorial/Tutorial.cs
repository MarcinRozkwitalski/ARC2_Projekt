using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool start = true, cards = true, town = true, shop = true, casino = true, blackJack = true, dungeon = true, battle = true;



    void Awake()
    {
        Default();
        var tutorial = FindObjectsOfType<Tutorial>();
        if (tutorial.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Default(){
        start = true;
        cards = true;
        town = true;
        shop = true;
        casino = true;
        blackJack = true;
        dungeon = true;
        battle = true;
    }

    public bool ReturnStart(){
        return this.start;
    }

    public void CheckIfCanDestroy()
    {
        if (start && cards && town && shop && casino && blackJack && dungeon && battle) Destroy(gameObject);
    }
}
