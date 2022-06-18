using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleCardInfo : MonoBehaviour
{
    public BattleHandler battleHandler;
    public BattleCardHandler battleCardHandler;
    public EnemyFightingLogic enemyFightingLogic;

    public TMP_Text CardName;
    public TMP_Text Type;
    public TMP_Text Description;
    public TMP_Text Price;
    public TMP_Text Points;
    public TMP_Text HealthPoints;

    public string cardname;
    public string type;
    public string description;
    public int price;
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
        Price.text = price.ToString();
        Points.text = points.ToString();
        HealthPoints.text = healthPoints.ToString();
    }

    public bool IsCardEquipped()
    {
        return is_equipped;
    }

    public void HandleCardAction()
    {
        string cardType = this.type;

        switch (cardType)
        {
            case "Atak":
                if(battleHandler.currentEnemyDefence > points)
                {
                    battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                    battleHandler.currentPlayerHealth -= healthPoints;
                    PreventHealthPointsFallingBelowZero();
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.currentEnemyDefence -= points;
                    battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                    battleHandler.remainingMoves--;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                }
                else if (battleHandler.currentEnemyDefence < points)
                {
                    int remainingPoints = battleHandler.currentEnemyDefence - points;
                    if(battleHandler.currentEnemyDefence == 0) battleHandler.currentEnemyHealth -= points;
                    else battleHandler.currentEnemyHealth += remainingPoints;

                    battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                    
                    battleHandler.currentPlayerHealth -= healthPoints;
                    PreventHealthPointsFallingBelowZero();
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.currentEnemyDefence = 0;
                    battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                    battleHandler.remainingMoves--;
                    DebuggingInfo();
                    if(battleHandler.currentEnemyHealth <= 0)
                    {
                        battleHandler.currentEnemyHealth = 0;
                        battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                        HideAllBattleCards();
                        ShowGoBackToDungeonButton();
                    }
                    else CheckIfRemainingMovesIsZero();
                }
                else if (battleHandler.currentEnemyDefence == points)
                {
                    battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                    battleHandler.currentPlayerHealth -= healthPoints;
                    PreventHealthPointsFallingBelowZero();
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.currentEnemyDefence = 0;
                    battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                    battleHandler.remainingMoves--;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                }
                break;

            case "Obrona":
                battleHandler.informationText.text = "Zyskujesz " + points + " tarczy.";
                battleHandler.currentPlayerHealth -= healthPoints;
                PreventHealthPointsFallingBelowZero();
                battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                battleHandler.currentPlayerDefence += points;
                battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                battleHandler.remainingMoves--;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
                break;

            case "Wytrwalosc":
                battleHandler.informationText.text = "Zyskujesz przedluzenie tarczy.";
                battleHandler.keepDefenceFlagPlayer = true;
                battleHandler.remainingMoves--;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
                break;

            case "Pospiech":
                battleHandler.informationText.text = "Zyskujesz dodatkowy ruch.";
                battleHandler.remainingMoves++;
                DebuggingInfo();
                break;

            case "Ogluszenie":
                battleHandler.informationText.text = "Ogluszyles przeciwnika na ture.";
                battleHandler.stunFlagPlayer = true;
                battleHandler.remainingMoves--;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
                break;

            case "Oslabienie":
                battleHandler.informationText.text = "Oslabiles przeciwnika.";
                battleHandler.debuffFlagPlayer = true;
                battleHandler.remainingMoves--;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
                break;

            case "Leczenie": 
                battleHandler.informationText.text = "Uleczyles sie " + points + "HP.";
                battleHandler.currentPlayerHealth += points;
                if(battleHandler.currentPlayerHealth > 100) battleHandler.currentPlayerHealth = 100;
                battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                battleHandler.remainingMoves--;
                DebuggingInfo();
                CheckIfRemainingMovesIsZero();
                break;

            case "Wzmocnienie":
                battleHandler.informationText.text = "Podwoiles tarcze.";
                battleHandler.currentPlayerDefence *= 2;
                battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                break;

            case "Ulepszenie": //bez remainingMoves--; //co w przypadkach użycia na wszystkich specjalnych kartach?
                battleHandler.informationText.text = "Ulepszasz nastepna karte.";
                battleHandler.improvementFlagPlayer = true;

                break;

            case "Tecza":
                int randomAction = Random.Range(1, 4);
                switch (randomAction)
                {
                    case 1: //atak
                        if(battleHandler.currentEnemyDefence > points)
                        {
                            battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                            battleHandler.currentPlayerHealth -= healthPoints;
                            PreventHealthPointsFallingBelowZero();
                            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                            battleHandler.currentEnemyDefence -= points;
                            battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                            battleHandler.remainingMoves--;
                            DebuggingInfo();
                            CheckIfRemainingMovesIsZero();
                        }
                        else if (battleHandler.currentEnemyDefence < points)
                        {
                            int remainingPoints = battleHandler.currentEnemyDefence - points;
                            if(battleHandler.currentEnemyDefence == 0) battleHandler.currentEnemyHealth -= points;
                            else battleHandler.currentEnemyHealth += remainingPoints;

                            battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                            
                            battleHandler.currentPlayerHealth -= healthPoints;
                            PreventHealthPointsFallingBelowZero();
                            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                            battleHandler.currentEnemyDefence = 0;
                            battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                            battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                            battleHandler.remainingMoves--;
                            DebuggingInfo();
                            if(battleHandler.currentEnemyHealth <= 0)
                            {
                                battleHandler.currentEnemyHealth = 0;
                                battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                                HideAllBattleCards();
                                ShowGoBackToDungeonButton();
                            }
                            else CheckIfRemainingMovesIsZero();
                        }
                        else if (battleHandler.currentEnemyDefence == points)
                        {
                            battleHandler.informationText.text = "Zadajesz " + points + " obrazen.";
                            battleHandler.currentPlayerHealth -= healthPoints;
                            PreventHealthPointsFallingBelowZero();
                            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                            battleHandler.currentEnemyDefence = 0;
                            battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
                            battleHandler.remainingMoves--;
                            DebuggingInfo();
                            CheckIfRemainingMovesIsZero();
                        }
                        break;
                        
                    case 2: //obrona
                        battleHandler.informationText.text = "Zyskujesz " + points + " tarczy.";
                        battleHandler.currentPlayerHealth -= healthPoints;
                        PreventHealthPointsFallingBelowZero();
                        battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                        battleHandler.currentPlayerDefence += points;
                        battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                        battleHandler.remainingMoves--;
                        DebuggingInfo();
                        CheckIfRemainingMovesIsZero();
                        break;
                        
                    case 3: //leczenie
                        battleHandler.informationText.text = "Uleczyles sie " + points + "HP.";
                        battleHandler.currentPlayerHealth += points;
                        if(battleHandler.currentPlayerHealth > 100) battleHandler.currentPlayerHealth = 100;
                        battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                        battleHandler.remainingMoves--;
                        DebuggingInfo();
                        CheckIfRemainingMovesIsZero();
                        break;
                        
                    default:
                        Debug.Log("Number out of range!");
                        break;
                }
                break;

            default:
                Debug.Log("Non-existing card OR failure with naming");
                break;
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

    public void CheckIfRemainingMovesIsZero()
    {
        if(battleHandler.remainingMoves == 0)
        {
            SetDefaultDefenceForEnemy();
            HideAllBattleCards();
            battleHandler.whosTurn = "enemy";
            battleHandler.ResetRemainingMoves();
            enemyFightingLogic.StartEnemyTurn();
        }
    }

    public void PreventHealthPointsFallingBelowZero()
    {
        if(battleHandler.currentPlayerHealth < 1) battleHandler.currentPlayerHealth = 1;
    }

    public void SetDefaultDefenceForEnemy()
    {
        battleHandler.currentEnemyDefence = 0;
        battleHandler.enemyDefenceText.text = battleHandler.currentEnemyDefence.ToString();
    }

    public void DebuggingInfo()
    {
        Debug.Log("Remaining moves player:" + battleHandler.remainingMoves);
    }
}
