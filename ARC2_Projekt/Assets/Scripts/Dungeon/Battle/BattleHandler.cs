using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;
    public NormalEnemiesList normalEnemiesList;
    public PowerfulEnemiesList powerfulEnemiesList;

    public Text informationText;
    public GameObject backToDungeonButton;

    public Text playerNameText;
    public Text playerHealthText;
    public int currentPlayerHealth;
    public int playerMaxHealth = 100;
    public Text playerDefenceText;
    public int currentPlayerDefence;
    public Text enemyNameText;
    public Text enemyHealthText;
    public Text enemyDefenceText;
    public int currentEnemyMaxHealth;

    public int remainingMoves;
    public string whosTurn;
    public string whoWon;
    public string enemyType;
    
    public int currentEnemyId;
    public string currentEnemyName;
    public int currentEnemyHealth;
    public int currentEnemyDefence;

    //wsadzić karty wszystkie do obecnej "ręki" stack lub heap, wyświetlać tylko pierwsze pięć
    //gdy gracz PO swoim ruchu zostanie tylko z jedną kartą niech dobierze cztery karty "na rękę"
    //zużyte karty będące na odłożonej talii powinny się losowo poustawiać gdy zabraknie kart u gracza

    //gdy gracz pojedzie dwa razy wtedy dwie tury należą do potwora
    //ruchy potwora nie powinny dziać się dosłownie przez chwilę, niech gracz widzi co potwór robi przez WaitForSeconds
    //przy każdym ruchu czy to gracza czy potwora powinny być sprawdzane warunki czy któryś z nich ma obecnie życie równe 0 po ataku
    //niech obrony gracza i potwora istnieją tylko do końca następnej tury przeciwnika, tak aby obrona znikała przy swoim następnym ruchu

    //co do zczytywania danych z karty powinna być jedna uniwersalna metoda, patrzy czy typ karty to atak czy obrona
    //potem z odpowiednich pól niech zbiera dane o ataku/obronie i koszcie karty z życia

    void Start()
    {
        var CurrentPlayer = GameObject.FindGameObjectWithTag("CurrentPlayer");
        string CurrentPlayerUsername = CurrentPlayer.GetComponent<CurrentPlayer>().Username;
        tempCurrentPlayer = GameObject.Find("DoorHandler").GetComponent<TempCurrentPlayer>();
        normalEnemiesList = GameObject.Find("BattleHandler").GetComponent<NormalEnemiesList>();
        powerfulEnemiesList = GameObject.Find("BattleHandler").GetComponent<PowerfulEnemiesList>();
        playerNameText = GameObject.Find("PlayerNameText").GetComponent<Text>();
        playerHealthText = GameObject.Find("PlayerHealthText").GetComponent<Text>();
        playerDefenceText = GameObject.Find("PlayerDefenceText").GetComponent<Text>();
        enemyNameText = GameObject.Find("EnemyNameText").GetComponent<Text>();
        enemyHealthText = GameObject.Find("EnemyHealthText").GetComponent<Text>();
        enemyDefenceText = GameObject.Find("EnemyDefenceText").GetComponent<Text>();
        informationText = GameObject.Find("InformationText").GetComponent<Text>();

        backToDungeonButton = GameObject.Find("BackToDungeonButton");
        backToDungeonButton.gameObject.SetActive(false);

        GetEnemyTypeByLastDoorValue();
        GetRandomEnemy();

        playerNameText.text = CurrentPlayerUsername;
        currentPlayerHealth = tempCurrentPlayer.TempPlayerLife;
        playerHealthText.text = currentPlayerHealth.ToString() + "/" + playerMaxHealth;
        currentPlayerDefence = 0;
        playerDefenceText.text = "Shield: " + currentPlayerDefence.ToString();
        enemyNameText.text = currentEnemyName;
        enemyHealthText.text = currentEnemyHealth.ToString() + "/" + currentEnemyMaxHealth;
        currentEnemyDefence = 0;
        enemyDefenceText.text = "Shield: " + currentEnemyDefence.ToString();

        remainingMoves = 2;
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

    //każda karta musi mieć takie metody:
    // - sprawdzenie pól i rozliczenie ich
    // - sprawdzenie czy przeciwnik umarł (tylko dla gracza kolejne ify)
    // - jeśli tak to zakończ pojedynek i pokaż przycisk z wyjściem 
    // - DALEJ jeśli tak to dodaj do nieusuwalnej tablicy nazwę pokonanego przeciwnika
    // - jeśli nie to odejmij raz "remainingMoves" i zobacz czy równa się 0,
    // - jeśli "remainingMoves" równa się 0 to zakończ turę obecnej strony i przekaż turę drugiej stronie
    // - ustawić "remainingMoves" na 2
}