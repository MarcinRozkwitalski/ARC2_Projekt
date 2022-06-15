using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightingLogic : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardHandler battleCardHandler;
    public NormalEnemiesList normalEnemiesList;
    public PowerfulEnemiesList powerfulEnemiesList;

    public class EnemyMoves
    {
        public int enemyId;
        public string moveName;
        public string description;
        public string type;
        public int cost;
        public int value;

        public EnemyMoves(int newEnemyId, string newMoveName, string newDescription, string newType, int newCost, int newValue)
        {
            enemyId = newEnemyId;
            moveName = newMoveName;
            description = newDescription;
            type = newType;
            cost = newCost;
            value = newValue;
        }
    }

    public List<EnemyMoves> enemyMoves = new List<EnemyMoves>();

    private void Start() {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
        normalEnemiesList = GameObject.Find("BattleHandler").GetComponent<NormalEnemiesList>();
        powerfulEnemiesList = GameObject.Find("BattleHandler").GetComponent<PowerfulEnemiesList>();

        GetEnemyMoves();

        foreach(var x in enemyMoves) {
            Debug.Log(x.enemyId + "/" + x.moveName + "/" + x.description + "/" + x.type + "/" + x.cost + "/" + x.value);
        }
    }

    public void StartEnemyTurn()
    {
        StartCoroutine(HandleEnemyMoves());
    }

    public void GetEnemyMoves()
    {
        if(battleHandler.enemyType == "normal")
        {
            for (int i = 0; i < normalEnemiesList.normalEnemiesMovesList.Count; i++)
            {
                if(normalEnemiesList.normalEnemiesMovesList[i].enemyId == battleHandler.currentEnemyId){
                    AddMoveToList(
                        normalEnemiesList.normalEnemiesMovesList[i].enemyId, 
                        normalEnemiesList.normalEnemiesMovesList[i].moveName,
                        normalEnemiesList.normalEnemiesMovesList[i].description,
                        normalEnemiesList.normalEnemiesMovesList[i].type,
                        normalEnemiesList.normalEnemiesMovesList[i].cost,
                        normalEnemiesList.normalEnemiesMovesList[i].value);
                }
            }
        }
        else if(battleHandler.enemyType == "powerful")
        {
            for (int i = 0; i < powerfulEnemiesList.powerfulEnemiesMovesList.Count; i++)
            {
                if(powerfulEnemiesList.powerfulEnemiesMovesList[i].enemyId == battleHandler.currentEnemyId){
                    AddMoveToList(
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].enemyId, 
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].moveName,
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].description,
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].type,
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].cost,
                        powerfulEnemiesList.powerfulEnemiesMovesList[i].value);
                }
            }
        }
    }

    public void AddMoveToList(int newEnemyId, string newMoveName, string newDescription, string newType, int newCost, int newValue)
    {
        EnemyMoves newEnemyMove = new EnemyMoves(newEnemyId, newMoveName, newDescription, newType, newCost, newValue);
        newEnemyMove.enemyId = newEnemyId;
        newEnemyMove.moveName = newMoveName;
        newEnemyMove.description = newDescription;
        newEnemyMove.type = newType;
        newEnemyMove.cost = newCost;
        newEnemyMove.value = newValue;
        enemyMoves.Add(newEnemyMove);
    }

    IEnumerator HandleEnemyMoves()
    {
        battleHandler.informationText.text = "Tura wroga!";
        yield return new WaitForSeconds(2);
        for(int i = 2; i > 0; i--){
            battleHandler.informationText.text = "Wróg coś robi!";
            yield return new WaitForSeconds(2);
            Debug.Log("FOR " + battleHandler.remainingMoves);
            battleHandler.remainingMoves--;
        }
        yield return new WaitForSeconds(2);
        Debug.Log("AFTER FOR " + battleHandler.remainingMoves);
        battleHandler.informationText.text = "Wróg zakończył turę!";
        yield return new WaitForSeconds(2);

        if(battleHandler.remainingMoves == 0){
            UnHideAllBattleCards();
            battleHandler.remainingMoves = 2;
        }
    }

    public void UnHideAllBattleCards()
    {
        int howManyCards = battleCardHandler.playerCardsPanel.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.playerCardsPanel.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}