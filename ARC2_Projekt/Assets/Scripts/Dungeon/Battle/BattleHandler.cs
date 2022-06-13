using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer; 
    public NormalEnemiesList normalEnemiesList;
    public PowerfulEnemiesList powerfulEnemiesList;

    Text playerNameText;
    Text playerHealthText;
    int playerMaxHealth = 100;
    Text enemyNameText;
    Text enemyHealthText;
    int currentEnemyMaxHealth;

    public int remainingMoves;
    public string whosTurn;
    string enemyType;
    
    public int currentEnemyId;
    public string currentEnemyName;
    public int currentEnemyHealth;

    //na samym początku zczytać jakie gracz ma karty w ekwipunku z bazy danych
    //wsadzić je wszystkie do obecnej "ręki" stack lub heap, wyświetlać tylko pierwsze pięć
    //gdy gracz PO swoim ruchu zostanie tylko z jedną kartą niech dobierze cztery karty "na rękę"
    //zużyte karty będące na odłożonej talii powinny się losowo poustawiać gdy zabraknie kart u gracza

    //nadać licznik "int pozostałeRuchy = 2"
    //przy użyciu jakiejś karty wykonać metodę "pozostałeRuchy--" oraz 
    //wykonanie akcji z karty (atak lub obrona oraz wartość atakująca i odejmująca życie) oraz 
    //pozbycie się karty do "odłożonej talii"
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
        enemyNameText = GameObject.Find("EnemyNameText").GetComponent<Text>();
        enemyHealthText = GameObject.Find("EnemyHealthText").GetComponent<Text>();

        GetEnemyTypeByLastDoorValue();
        GetRandomEnemy();

        playerNameText.text = CurrentPlayerUsername;
        playerHealthText.text = tempCurrentPlayer.TempPlayerLife.ToString() + "/" + playerMaxHealth;
        enemyNameText.text = currentEnemyName;
        enemyHealthText.text = currentEnemyHealth.ToString() + "/" + currentEnemyMaxHealth;

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