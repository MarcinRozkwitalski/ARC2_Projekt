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

    public Sprite CardSprite;
    public Sprite BackSprite;

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
    public bool is_back_active = false;
    public bool allow_to_animate = false;
    
    private void Start() {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        battleCardHandler = GameObject.Find("NetworkManager").GetComponent<BattleCardHandler>();
        enemyFightingLogic = GameObject.Find("BattleHandler").GetComponent<EnemyFightingLogic>();

        AssignNewTransform();
        AssignBackImage();
        TurnOffButton();
    }

    public void TurnOffButton()
    {
        int howManyCards = battleCardHandler.cardsDeckToPick.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.cardsDeckToPick.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }
    }

    public void TurnOnButton()
    {
        int howManyCards = battleCardHandler.cardsOnHandRevealPanel.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }
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

    public void AssignNewTransform()
    {
        transform.position += new Vector3(103f, 483f, 0f);
        transform.position += new Vector3(48f, 230f, 0f);
        transform.localScale = new Vector2(0.43f, 0.37f);
    }

    public void AssignBackImage()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = BackSprite;
        for (int i = 1; i < 21; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        is_back_active = true;
    }

    public void AssignCardImage()
    {
        int howManyCards = battleCardHandler.cardsOnHandRevealPanel.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = CardSprite;
        }

        for (int i = 0; i < howManyCards; i++)
        {
            CheckSubtype(battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(i).gameObject, battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(i).GetComponent<BattleCardInfo>().type);
            battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(i).GetComponent<BattleCardInfo>().is_back_active = false;
        }
        
        for (int j = 0; j < howManyCards; j++)
        {
            for (int i = 14; i < 21; i++)
            {
                battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(j).gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < howManyCards; i++)
        {
            battleCardHandler.cardsOnHandRevealPanel.transform.GetChild(0).transform.SetParent(battleHandler.playableCardsPanel.transform);
        }   
    }

    public void DoAnimationMovingCardsSidewaysInPlayerCardsPanel()
    {
        battleHandler.moveCardsSidewaysInPlayerCardsPanelAnimation = true;
    }

    public bool IsCardEquipped()
    {
        return is_equipped;
    }

    public void HandleCardAction()
    {
        if(is_back_active == true){
            DoAnimationMovingCardsSidewaysInPlayerCardsPanel();
        }
        else if(is_back_active == false)
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
                        battleHandler.currentAmmountOfMoves++;
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
                        battleHandler.currentAmmountOfMoves++;
                        DebuggingInfo();
                        if(battleHandler.currentEnemyHealth <= 0)
                        {
                            battleHandler.currentEnemyHealth = 0;
                            battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                            StartCoroutine(HideAllBattleCards());
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
                        battleHandler.currentAmmountOfMoves++;
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
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Wytrwalosc":
                    battleHandler.informationText.text = "Zyskujesz przedluzenie tarczy.";
                    battleHandler.keepDefenceFlagPlayer = true;
                    battleHandler.remainingMoves--;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Pospiech":
                    battleHandler.informationText.text = "Zyskujesz dodatkowy ruch.";
                    battleHandler.remainingMoves++;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Ogluszenie":
                    battleHandler.informationText.text = "Ogluszyles przeciwnika na ture.";
                    battleHandler.stunFlagPlayer = true;
                    battleHandler.remainingMoves--;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Oslabienie":
                    battleHandler.informationText.text = "Oslabiles przeciwnika.";
                    battleHandler.debuffFlagPlayer = true;
                    battleHandler.remainingMoves--;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Leczenie": 
                    battleHandler.informationText.text = "Uleczyles sie " + points + "HP.";
                    battleHandler.currentPlayerHealth += points;
                    if(battleHandler.currentPlayerHealth > 100) battleHandler.currentPlayerHealth = 100;
                    battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                    battleHandler.remainingMoves--;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Wzmocnienie":
                    battleHandler.informationText.text = "Podwoiles tarcze.";
                    battleHandler.currentPlayerDefence *= 2;
                    battleHandler.currentAmmountOfMoves++;
                    battleHandler.playerDefenceText.text = battleHandler.currentPlayerDefence.ToString();
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
                    break;

                case "Ulepszenie": //bez remainingMoves--; //co w przypadkach użycia na wszystkich specjalnych kartach?
                    battleHandler.informationText.text = "Ulepszasz nastepna karte.";
                    battleHandler.improvementFlagPlayer = true;
                    battleHandler.currentAmmountOfMoves++;
                    DebuggingInfo();
                    CheckIfRemainingMovesIsZero();
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
                                battleHandler.currentAmmountOfMoves++;
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
                                battleHandler.currentAmmountOfMoves++;
                                DebuggingInfo();
                                if(battleHandler.currentEnemyHealth <= 0)
                                {
                                    battleHandler.currentEnemyHealth = 0;
                                    battleHandler.enemyHealthText.text = battleHandler.currentEnemyHealth.ToString() + "/" + battleHandler.currentEnemyMaxHealth;
                                    StartCoroutine(HideAllBattleCards());
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
                                battleHandler.currentAmmountOfMoves++;
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
                            battleHandler.currentAmmountOfMoves++;
                            DebuggingInfo();
                            CheckIfRemainingMovesIsZero();
                            break;
                            
                        case 3: //leczenie
                            battleHandler.informationText.text = "Uleczyles sie " + points + "HP.";
                            battleHandler.currentPlayerHealth += points;
                            if(battleHandler.currentPlayerHealth > 100) battleHandler.currentPlayerHealth = 100;
                            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
                            battleHandler.remainingMoves--;
                            battleHandler.currentAmmountOfMoves++;
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
    }

    public void HideBattleCard()
    {
        if(is_back_active == false){
            this.gameObject.GetComponent<Button>().enabled = false;
            this.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        }
    }

    public IEnumerator HideAllBattleCards()
    {
        int howManyCards = battleHandler.playableCardsPanel.transform.childCount;

        for (int i = 0; i < howManyCards; i++)
        {
            battleHandler.playableCardsPanel.transform.GetChild(0).gameObject.GetComponent<Button>().enabled = false;
            battleHandler.playableCardsPanel.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(128, 128, 128, 255);
            battleHandler.playableCardsPanel.transform.GetChild(0).transform.SetParent(battleHandler.usedCardsPanel.transform, true);
        }

        yield return new WaitForSeconds(1);
        battleHandler.moveCardsToUsedCardsAnimation = true;
        StopCoroutine(HideAllBattleCards());
    }

    public void ShowGoBackToDungeonButton()
    {
        battleHandler.informationText.text = "Pokonales " + battleHandler.currentEnemyName + "!";
        battleHandler.whoWon = "player";
        battleHandler.backToDungeonButton.gameObject.SetActive(true);
    }

    public void CheckIfRemainingMovesIsZero()
    {
        if(battleHandler.remainingMoves == 0 || battleHandler.maxAmmountOfMoves == battleHandler.currentAmmountOfMoves)
        {
            SetDefaultDefenceForEnemy();
            StartCoroutine(HideAllBattleCards());
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
        // Debug.Log("Remaining moves player: " + battleHandler.remainingMoves);
        // Debug.Log("Current ammount of moves: " + battleHandler.currentAmmountOfMoves);
    }

    public void CheckSubtype(GameObject cardInfo, string subtype)
    {
        switch (subtype)
        {
            case "Atak":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(true);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(true);
                break;
            case "Obrona":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(true);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(true);
                break;
            case "Ogluszenie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(true);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Leczenie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(true);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Oslabienie":
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Pospiech":
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(true);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Wzmocnienie":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(true);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Wytrwalosc":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(true);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Tecza":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(false);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(true);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
            case "Ulepszenie":
            cardInfo.transform.Find("Life").gameObject.SetActive(false);
            cardInfo.transform.Find("Haste").gameObject.SetActive(false);
            cardInfo.transform.Find("Heal").gameObject.SetActive(false);
            cardInfo.transform.Find("Stun").gameObject.SetActive(false);
            cardInfo.transform.Find("HoldDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("DoubleDefence").gameObject.SetActive(false);
            cardInfo.transform.Find("Debuff").gameObject.SetActive(false);
            cardInfo.transform.Find("Buff").gameObject.SetActive(true);
            cardInfo.transform.Find("PowerfullRandom").gameObject.SetActive(false);
            cardInfo.transform.Find("DefenceType").gameObject.SetActive(false);
            cardInfo.transform.Find("AttackType").gameObject.SetActive(false);
            cardInfo.transform.Find("SpecialType").gameObject.SetActive(true);
                break;
        }
    }
}
