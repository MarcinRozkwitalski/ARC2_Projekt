using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayerTurn : MonoBehaviour
{
    public BattleHandler battleHandler;
    public GameObject battleCardPrefab;
        
    private void Start() 
    { 
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        MakeButtonInvisibleOnStart();
    }

    public void MakeButtonVisible()
    {
        gameObject.SetActive(true);
    }

    public void MakeButtonInvisibleOnStart()
    {
        gameObject.SetActive(false);
    }
    
    public void MakeButtonInvisible()
    {
        gameObject.SetActive(false);
    }

    public void EndPlayerTurnOnClick()
    {
        battleHandler.remainingMoves = 0;
        battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;

        GameObject battleCard = GameObject.FindWithTag("PlayerCard");
        battleCard.GetComponent<BattleCardInfo>().CheckIfRemainingMovesIsZero();
        MakeButtonInvisible();
    }
}