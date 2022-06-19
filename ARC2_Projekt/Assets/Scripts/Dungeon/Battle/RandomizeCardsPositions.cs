using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RandomizeCardsPositions : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardHandler battleCardHandler;
    
    void Start()
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
    }

    public void RandomizePositions()
    {
        int howManyCards = battleCardHandler.cardsDeckToPick.transform.childCount;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < howManyCards; j++)
            {
                battleCardHandler.cardsDeckToPick.transform.GetChild(0).gameObject.transform.SetSiblingIndex(Random.Range(0, howManyCards));
            }
        }
    }
}