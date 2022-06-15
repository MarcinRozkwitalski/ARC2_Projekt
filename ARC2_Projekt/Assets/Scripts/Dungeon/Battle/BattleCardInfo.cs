using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardInfo : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardHandler battleCardHandler;
    public EnemyFightingLogic enemyFightingLogic;

    public Text CardName;
    public Text Type;
    public Text Description;
    public Text Points;
    public Text HealthPoints;

    public string cardname;
    public string type;
    public string description;
    public int points;
    public int healthPoints;
    public int id;
    public bool is_equipped = false;
    
    private void Start() {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
        enemyFightingLogic = GameObject.Find("BattleHandler").GetComponent<EnemyFightingLogic>();
    }

    public void AssignInfo()
    {
        CardName.text = cardname;
        Type.text = type;
        Description.text = description;
        Points.text = points.ToString();
        HealthPoints.text = healthPoints.ToString();
    }

    public bool IsCardEquipped()
    {
        return is_equipped;
    }

    public void HandleCardAction()
    {
        if(this.type == "Atak")
        {
            if(battleHandler.currentEnemyDefence <= 0)
            {
                battleHandler.currentPlayerHealth -= healthPoints;
                battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                battleHandler.currentEnemyHealth -= points;
                battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                battleHandler.remainingMoves--;
                if(battleHandler.currentEnemyHealth <= 0)
                {
                    battleHandler.currentEnemyHealth = 0;
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    HideAllBattleCards();
                    ShowGoBackToDungeonButton();
                }
                else if(battleHandler.remainingMoves == 0)
                {
                    HideAllBattleCards();
                    battleHandler.whosTurn = "enemy";
                    battleHandler.remainingMoves = 2;
                    enemyFightingLogic.StartEnemyTurn();
                }
            }
            else if (battleHandler.currentEnemyDefence < points)
            {
                int remainingPoints = battleHandler.currentEnemyDefence - points;
                battleHandler.currentPlayerHealth -= healthPoints;
                battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                battleHandler.currentEnemyDefence = 0;
                battleHandler.enemyDefenceText.text = "Shield: " + battleHandler.currentEnemyDefence.ToString();
                battleHandler.currentEnemyHealth -= remainingPoints;
                battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                battleHandler.remainingMoves--;
                if(battleHandler.currentEnemyHealth <= 0)
                {
                    battleHandler.currentEnemyHealth = 0;
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    HideAllBattleCards();
                    ShowGoBackToDungeonButton();
                }
                else if(battleHandler.remainingMoves == 0)
                {
                    HideAllBattleCards();
                    battleHandler.whosTurn = "enemy";
                    battleHandler.remainingMoves = 2;
                    enemyFightingLogic.StartEnemyTurn();
                }
            }
            else if (battleHandler.currentEnemyDefence == points)
            {
                battleHandler.currentPlayerHealth -= healthPoints;
                battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                battleHandler.currentEnemyDefence = 0;
                battleHandler.enemyDefenceText.text = "Shield: " + battleHandler.currentEnemyDefence.ToString();
                battleHandler.remainingMoves--;
                if(battleHandler.remainingMoves == 0)
                {
                    HideAllBattleCards();
                    battleHandler.whosTurn = "enemy";
                    battleHandler.remainingMoves = 2;
                    enemyFightingLogic.StartEnemyTurn();
                }
            }
        }
        else if(this.type == "Obrona")
        {
            battleHandler.currentPlayerHealth -= healthPoints;
            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
            battleHandler.currentPlayerDefence += points;
            battleHandler.playerDefenceText.text = "Shield: " + battleHandler.currentPlayerDefence.ToString();
            battleHandler.remainingMoves--;
            if(battleHandler.remainingMoves == 0)
            {
                HideAllBattleCards();
                battleHandler.whosTurn = "enemy";
                battleHandler.remainingMoves = 2;
                enemyFightingLogic.StartEnemyTurn();
            }
        }
    }

    public void HideBattleCard()
    {
        this.gameObject.SetActive(false);
    }

    public void HideAllBattleCards()
    {
        int howManyCards = battleCardHandler.playerCardsPanel.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.playerCardsPanel.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ShowGoBackToDungeonButton()
    {
        battleHandler.informationText.text = "Pokonales " + battleHandler.currentEnemyName + "!";
        battleHandler.whoWon = "player";
        battleHandler.backToDungeonButton.gameObject.SetActive(true);
    }
}
