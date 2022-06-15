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
            int randomMove = Random.Range(0, enemyMoves.Count);
            EnemyMoves currentEnemyMove = enemyMoves[randomMove];

            battleHandler.informationText.text = currentEnemyMove.description;
            yield return new WaitForSeconds(2);

            if(currentEnemyMove.type == "Atak")
            {
                if(battleHandler.currentPlayerDefence > currentEnemyMove.value)
                {
                    battleHandler.currentEnemyHealth -= currentEnemyMove.cost;
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    battleHandler.currentPlayerDefence -= currentEnemyMove.value;
                    battleHandler.playerDefenceText.text = "Shield: " + battleHandler.currentPlayerDefence.ToString();
                    battleHandler.remainingMoves--;
                if(battleHandler.remainingMoves == 0)
                {
                    battleHandler.whosTurn = "player";
                    battleHandler.remainingMoves = 2;
                    UnHideAllBattleCards();
                }
                }
                else if (battleHandler.currentPlayerDefence < currentEnemyMove.value)
                {
                    int remainingPoints = battleHandler.currentPlayerDefence - currentEnemyMove.value;
                    if(battleHandler.currentPlayerDefence == 0) battleHandler.currentPlayerHealth -= currentEnemyMove.value;
                    else battleHandler.currentPlayerHealth += remainingPoints;

                    battleHandler.currentEnemyHealth -= currentEnemyMove.cost;
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    battleHandler.currentPlayerDefence = 0;
                    battleHandler.playerDefenceText.text = "Shield: " + battleHandler.currentPlayerDefence.ToString();
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.remainingMoves--;
                    if(battleHandler.currentPlayerHealth <= 0)
                    {
                        battleHandler.currentPlayerHealth = 0;
                        battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                        ShowGoBackToDungeonButton();
                    }
                    else if(battleHandler.remainingMoves == 0)
                    {
                        battleHandler.whosTurn = "player";
                        battleHandler.remainingMoves = 2;
                        UnHideAllBattleCards();
                    }
                }
                else if (battleHandler.currentPlayerDefence == currentEnemyMove.value)
                {
                    battleHandler.currentEnemyHealth -= currentEnemyMove.cost;
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    battleHandler.currentPlayerDefence = 0;
                    battleHandler.playerDefenceText.text = "Shield: " + battleHandler.currentPlayerDefence.ToString();
                    battleHandler.remainingMoves--;
                    if(battleHandler.remainingMoves == 0)
                    {
                        battleHandler.whosTurn = "player";
                        battleHandler.remainingMoves = 2;
                        UnHideAllBattleCards();
                    }
                }
            }
            else if(currentEnemyMove.type == "Obrona")
            {
                battleHandler.currentEnemyHealth -= currentEnemyMove.cost;
                battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                battleHandler.currentEnemyDefence += currentEnemyMove.value;
                battleHandler.enemyDefenceText.text = "Shield: " + battleHandler.currentEnemyDefence.ToString();
                battleHandler.remainingMoves--;
                if(battleHandler.remainingMoves == 0)
                {
                    battleHandler.whosTurn = "player";
                    battleHandler.remainingMoves = 2;
                    UnHideAllBattleCards();
                }
            }
            battleHandler.remainingMoves--;
        }
        yield return new WaitForSeconds(2);
        
        if(battleHandler.whoWon != "enemy"){
            battleHandler.informationText.text = "Wróg zakończył turę!";
            UnHideAllBattleCards();
            battleHandler.remainingMoves = 2;
        }
    }

    public void ShowGoBackToDungeonButton()
    {
        battleHandler.informationText.text = "Zostales pokonany przez " + battleHandler.currentEnemyName + "!";
        battleHandler.whoWon = "enemy";
        battleHandler.backToDungeonButton.gameObject.SetActive(true);
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