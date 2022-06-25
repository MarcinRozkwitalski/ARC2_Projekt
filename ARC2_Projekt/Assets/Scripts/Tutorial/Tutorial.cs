using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public bool start_part_1 = true, start_part_2 = true, start_town_part_1 = true, start_town_part_2 = true, start_shop = true,
    cards = true, town = true, shop = true, casino = true, blackJack = true, dungeon = true, battle = true;



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

    public void Default()
    {
        start_part_1 = true;
        start_part_2 = true;
        start_town_part_1 = true;
        start_shop = true;
        cards = true;
        town = true;
        shop = true;
        casino = true;
        blackJack = true;
        dungeon = true;
        battle = true;
    }

    public void CheckIfCanDestroy()
    {
        if (start_part_1 && start_part_2 && cards && town && shop && casino && blackJack && dungeon && battle) Destroy(gameObject);
    }
}
