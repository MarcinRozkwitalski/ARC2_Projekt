using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BattleHandler : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;
    public NormalEnemiesList normalEnemiesList;
    public PowerfulEnemiesList powerfulEnemiesList;
    public RandomizeCardsPositions randomizeCardsPositions;

    public TMP_Text informationText;
    public GameObject backToDungeonButton;

    public GameObject usedCardsPanel;
    public GameObject playableCardsPanel;
    public GameObject cardsOnHandRevealPanel;

    public GameObject deckCardsToPick;

    public TMP_Text playerNameText;
    public TMP_Text playerHealthText;
    public int currentPlayerHealth;
    public int playerMaxHealth = 100;
    public TMP_Text playerDefenceText;
    public int currentPlayerDefence;
    public TMP_Text enemyNameText;
    public TMP_Text enemyHealthText;
    public TMP_Text enemyDefenceText;
    public int currentEnemyMaxHealth;

    public bool keepDefenceFlagPlayer = false;
    public bool stunFlagPlayer = false;
    public bool debuffFlagPlayer = false;
    public bool improvementFlagPlayer = false;

    public int remainingMoves;
    public int basicRemainingMovesAmount = 3;
    public string whosTurn;
    public string whoWon;
    public string enemyType;
    
    public int currentEnemyId;
    public string currentEnemyName;
    public int currentEnemyHealth;
    public int currentEnemyDefence;

    public bool moveCardsToUsedCardsAnimation = false;
    public bool moveCardsToPlayerCardsPanelAnimation = false;
    public bool moveCardsSidewaysInPlayerCardsPanelAnimation = false;
    public bool moveCardsFromUsedCardsToDeckCardsAnimation = false;

    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
        normalEnemiesList = GameObject.Find("BattleHandler").GetComponent<NormalEnemiesList>();
        powerfulEnemiesList = GameObject.Find("BattleHandler").GetComponent<PowerfulEnemiesList>();
        playerNameText = GameObject.Find("PlayerNameText (TMP)").GetComponent<TMP_Text>();
        playerHealthText = GameObject.Find("PlayerHealthText (TMP)").GetComponent<TMP_Text>();
        playerDefenceText = GameObject.Find("PlayerDefenceText (TMP)").GetComponent<TMP_Text>();
        enemyNameText = GameObject.Find("EnemyNameText (TMP)").GetComponent<TMP_Text>();
        enemyHealthText = GameObject.Find("EnemyHealthText (TMP)").GetComponent<TMP_Text>();
        enemyDefenceText = GameObject.Find("EnemyDefenceText (TMP)").GetComponent<TMP_Text>();
        informationText = GameObject.Find("InformationText (TMP)").GetComponent<TMP_Text>();

        usedCardsPanel = GameObject.Find("UsedCardsPanel");
        playableCardsPanel = GameObject.Find("PlayableCardsPanel");
        cardsOnHandRevealPanel = GameObject.Find("CardsOnHandRevealPanel");

        deckCardsToPick = GameObject.Find("CardsDeckToPick");

        backToDungeonButton = GameObject.Find("BackToDungeonButton");
        backToDungeonButton.gameObject.SetActive(false);

        GetEnemyTypeByLastDoorValue();
        GetRandomEnemy();

        playerNameText.text = CurrentPlayerUsername;
        currentPlayerHealth = tempCurrentPlayer.TempPlayerLife;
        playerHealthText.text = currentPlayerHealth.ToString() + "/" + playerMaxHealth;
        currentPlayerDefence = 0;
        playerDefenceText.text = "" + currentPlayerDefence.ToString();
        enemyNameText.text = currentEnemyName;
        enemyHealthText.text = currentEnemyHealth.ToString() + "/" + currentEnemyMaxHealth;
        currentEnemyDefence = 0;
        enemyDefenceText.text = "" + currentEnemyDefence.ToString();

        randomizeCardsPositions.RandomizePositionsInCardsDeck();
        StartCoroutine(GiveFirstFiveCards());

        ResetRemainingMoves();
        whosTurn = "player";
    }

    public void GetEnemyTypeByLastDoorValue()
    {
        if(tempCurrentPlayer.LastDoorValue == "czaszka")    enemyType = "normal";
        else                                                enemyType = "powerful";
    }

    public void GetRandomEnemy()
    {
        if(enemyType == "normal")   GetNormalEnemy();
        else                        GetPowerfulEnemy();
    }

    public void GetNormalEnemy()
    {
        currentEnemyId = Random.Range(normalEnemiesList.startingId, normalEnemiesList.startingId + normalEnemiesList.normalEnemiesList.Count);
        currentEnemyName = normalEnemiesList.normalEnemiesList[currentEnemyId - normalEnemiesList.startingId].enemyName;
        currentEnemyHealth = normalEnemiesList.normalEnemiesList[currentEnemyId - normalEnemiesList.startingId].health;
        currentEnemyMaxHealth = currentEnemyHealth;
    }

    public void GetPowerfulEnemy()
    {
        currentEnemyId = Random.Range(powerfulEnemiesList.startingId, powerfulEnemiesList.startingId + powerfulEnemiesList.powerfulEnemiesList.Count);
        currentEnemyName = powerfulEnemiesList.powerfulEnemiesList[currentEnemyId - powerfulEnemiesList.startingId].enemyName;
        currentEnemyHealth = powerfulEnemiesList.powerfulEnemiesList[currentEnemyId - powerfulEnemiesList.startingId].health;
        currentEnemyMaxHealth = currentEnemyHealth;
    }

    public void ResetRemainingMoves()
    {
        if(stunFlagPlayer == true){
            remainingMoves = 2;
            stunFlagPlayer = false;
            Debug.Log("Nowe ruchy: " + remainingMoves);
        }
        else{
            remainingMoves = basicRemainingMovesAmount;
            Debug.Log("Nowe ruchy: " + remainingMoves);
        }
    }

    public IEnumerator GiveFirstFiveCards()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 5; i++)
        {
            deckCardsToPick.transform.GetChild(0).GetComponent<BattleCardInfo>().allow_to_animate = true;
            deckCardsToPick.transform.GetChild(0).SetParent(cardsOnHandRevealPanel.transform, true);
        }
        moveCardsToPlayerCardsPanelAnimation = true;
        StopCoroutine(GiveFirstFiveCards());
    }

    public IEnumerator CheckRemainingPlayerCards()
    {
        if(deckCardsToPick.transform.childCount < 5)
        {
            int howManyCards = usedCardsPanel.transform.childCount;
            randomizeCardsPositions.RandomizePositionsInUsedCards();

            for (int i = 0; i < howManyCards; i++)
            {
                usedCardsPanel.transform.GetChild(0).GetComponent<BattleCardInfo>().AssignBackImage();
                usedCardsPanel.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                usedCardsPanel.transform.GetChild(0).GetComponent<BattleCardInfo>().allow_to_animate = true;
                usedCardsPanel.transform.GetChild(0).SetParent(deckCardsToPick.transform, true);
            }

            moveCardsFromUsedCardsToDeckCardsAnimation = true;
            yield return new WaitForSeconds(1.1f);
            moveCardsFromUsedCardsToDeckCardsAnimation = false;

            StartCoroutine(GiveFirstFiveCards());
        }
        else 
        {
            StartCoroutine(GiveFirstFiveCards());
        }
    }
}