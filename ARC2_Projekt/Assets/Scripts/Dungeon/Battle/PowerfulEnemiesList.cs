using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PowerfulEnemiesList : MonoBehaviour
{
    public int startingId;

    [System.Serializable]
    public class PowerfulEnemies
    {
        public int id;
        public string enemyName;
        public int health;

        public PowerfulEnemies(int newId, string newEnemyName, int newHealth)
        {
            id = newId;
            enemyName = newEnemyName;
            health = newHealth;
        }
    }

    [System.Serializable]
    public class PowerfulEnemiesMoves
    {
        public int enemyId;
        public string moveName;
        public string description;
        public string type;
        public int cost;
        public int value;

        public PowerfulEnemiesMoves(int newEnemyId, string newMoveName, string newDescription, string newType, int newCost, int newValue)
        {
            enemyId = newEnemyId;
            moveName = newMoveName;
            description = newDescription;
            type = newType;
            cost = newCost;
            value = newValue;
        }
    }
    
    public List<PowerfulEnemies> powerfulEnemiesList = new List<PowerfulEnemies>();
    public List<PowerfulEnemiesMoves> powerfulEnemiesMovesList = new List<PowerfulEnemiesMoves>();

    private void Awake() {
        powerfulEnemiesList.Add(new PowerfulEnemiesList.PowerfulEnemies(10, "Minotaur", 80));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(10, "Szarza",         "Minotaur uzywa szarzy!",           "Atak",     0, 10));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(10, "Ciecie toporem", "Minotaur uzywa ciecie toporem!",   "Atak",     0, 8));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(10, "Garda",          "Minotaur uzywa gardy!",            "Obrona",   0, 7));

        powerfulEnemiesList.Add(new PowerfulEnemiesList.PowerfulEnemies(11, "Cerber", 100));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(11, "Potrojne ugryzienie",    "Cerber uzywa potrojnego ugryzienia!",  "Atak",     0, 12));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(11, "Szarza",                 "Cerber uzywa szarzy!",                 "Atak",     0, 8));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(11, "Unik",                   "Cerber uzywa uniku!",                  "Obrona",   0, 5));

        powerfulEnemiesList.Add(new PowerfulEnemiesList.PowerfulEnemies(12, "Anubis", 90));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(12, "Magia rozkladania",  "Anubis uzywa magii rozkladania!",  "Atak",     0, 9));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(12, "Uderzenie laska",    "Anubis uzywa uderzenie laska!",    "Atak",     0, 7));
        powerfulEnemiesMovesList.Add(new PowerfulEnemiesList.PowerfulEnemiesMoves(12, "Ochronny krag",      "Anubis uzywa ochronnego kregu!",   "Obrona",   0, 10));

        startingId = powerfulEnemiesList[0].id;

        // for(int i = 0; i < powerfulEnemiesList.Count; i++)
        // {
        //     Debug.Log(powerfulEnemiesList[i].id + " " + powerfulEnemiesList[i].enemyName + " " + powerfulEnemiesList[i].health);
        // }

        // for(int i = 0; i < powerfulEnemiesMovesList.Count; i++)
        // {
        //     Debug.Log(powerfulEnemiesMovesList[i].enemyId + " " + powerfulEnemiesMovesList[i].moveName + " " + 
        //     powerfulEnemiesMovesList[i].description + " " + powerfulEnemiesMovesList[i].type + " " + 
        //     powerfulEnemiesMovesList[i].cost + " " + powerfulEnemiesMovesList[i].value);
        // }
    }
}