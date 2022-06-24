using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            // Debug.Log(x.enemyId + "/" + x.moveName + "/" + x.description + "/" + x.type + "/" + x.cost + "/" + x.value);
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
        yield return new WaitForSeconds(1f);
        battleHandler.informationText.text = "Tura wroga!";
        battleHandler.ResetRemainingMoves();
        battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;
        yield return new WaitForSeconds(1f);

        for(int i = battleHandler.remainingMoves; i > 0; i--){
            int randomMove = Random.Range(0, enemyMoves.Count);
            EnemyMoves currentEnemyMove = enemyMoves[randomMove];

            battleHandler.informationText.text = currentEnemyMove.description;
            yield return new WaitForSeconds(1f);          

            string current_level_buff = battleHandler.mapStatus.battle_buff;
            int currentAttackValue = currentEnemyMove.value;

            switch (current_level_buff)
            {
                case "DoubleMonterDamage":
                    currentAttackValue *= 2;
                    break;

                case "IncreaseMonsterDamage":
                    int randomPercentage = Random.Range(1, 4);
                    if      (randomPercentage == 1) currentAttackValue += 2;
                    else if (randomPercentage == 2) currentAttackValue += 3;
                    else if (randomPercentage == 3) currentAttackValue += 4;                           
                    break;

                default:
                    break;
            }

            if(battleHandler.debuffFlagPlayer == true)
            {
                battleHandler.debuffFlagPlayer = false;
                currentAttackValue = Mathf.RoundToInt((float)currentAttackValue * (1f - (battleHandler.debuffValue/100)));
                battleHandler.debuffValue = 0;
            } 

            if(currentEnemyMove.type == "Atak")
            {
                if(battleHandler.currentPlayerDefence > currentAttackValue)
                {
                    battleHandler.currentPlayerDefence -= currentAttackValue;
                    battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                    battleHandler.remainingMoves--;
                    battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                }
                else if (battleHandler.currentPlayerDefence < currentAttackValue)
                {
                    int remainingPoints = battleHandler.currentPlayerDefence - currentAttackValue;
                    if(battleHandler.currentPlayerDefence == 0) battleHandler.currentPlayerHealth -= currentAttackValue;
                    else battleHandler.currentPlayerHealth += remainingPoints;

                    battleHandler.currentPlayerDefence = 0;
                    battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.remainingMoves--;
                    battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;
                    DebuggingInfo();
                    if(battleHandler.currentPlayerHealth <= 0)
                    {
                        battleHandler.currentPlayerHealth = 0;
                        battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                        ShowGoBackToDungeonButton();
                    }
                    else CheckIfRemainingMovesIsZero();
                }
                else if (battleHandler.currentPlayerDefence == currentAttackValue)
                {
                    battleHandler.currentPlayerDefence = 0;
                    battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                    battleHandler.remainingMoves--;
                    battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                }
            }
            else if(currentEnemyMove.type == "Obrona")
            {
                battleHandler.currentEnemyDefence += currentEnemyMove.value;
                battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                battleHandler.remainingMoves--;
                battleHandler.remainingMovesText.text = "Moves: \n" + battleHandler.remainingMoves.ToString() + "/" + battleHandler.basicRemainingMovesAmount;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
            }
        }
        yield return new WaitForSeconds(1f);
        
        if(battleHandler.whoWon != "enemy"){
            battleHandler.enemyStunIcon.GetComponent<Image>().enabled = false;
            battleHandler.enemyHealthBarHealth.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            battleHandler.informationText.text = "Wróg zakończył turę.";
            yield return new WaitForSeconds(1f);
            StartCoroutine(battleHandler.CheckRemainingPlayerCards());
            SetDefaultDefenceForPlayer();
            battleHandler.informationText.text = "Twoja tura!";
            battleHandler.ResetRemainingMoves();
            // Debug.Log("Nowe ruchy dla gracza: " + battleHandler.remainingMoves);
        }
    }

    public void ShowGoBackToDungeonButton()
    {
        battleHandler.informationText.text = "Zostales pokonany przez " + battleHandler.currentEnemyName + "!";
        battleHandler.whoWon = "enemy";
        battleHandler.backToDungeonButton.gameObject.SetActive(true);
    }

    public IEnumerator UnHideAllBattleCards()
    {
        int howManyCards = battleCardHandler.cardsDeckToPick.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.cardsDeckToPick.transform.GetChild(i).gameObject.GetComponent<Button>().enabled = true;
            battleCardHandler.cardsDeckToPick.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }

        yield return null;
    }

    public void CheckIfRemainingMovesIsZero()
    {
        if(battleHandler.remainingMoves == 0)
        {
            battleHandler.whosTurn = "player";
            UnHideAllBattleCards();
        }
    }

    public void PreventHealthPointsFallingBelowZero()
    {
        if(battleHandler.currentEnemyHealth < 1) battleHandler.currentEnemyHealth = 1;
    }

    public void SetDefaultDefenceForPlayer()
    {
        if(battleHandler.keepDefenceFlagPlayer == true) 
        {
            battleHandler.keepDefenceFlagPlayer = false;
            battleHandler.playerShield.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if(battleHandler.keepDefenceFlagPlayer == false)
        {
            battleHandler.playerShield.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            battleHandler.currentPlayerDefence = 0;
            battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
        }
    }

    public void DebuggingInfo()
    {
        // Debug.Log("Remaining moves enemy:" + battleHandler.remainingMoves);
    }
}