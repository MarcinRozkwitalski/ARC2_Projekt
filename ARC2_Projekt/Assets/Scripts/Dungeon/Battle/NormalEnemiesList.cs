using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NormalEnemiesList : MonoBehaviour
{
    public int startingId;

    [System.Serializable]
    public class NormalEnemies
    {
        public int id;
        public string enemyName;
        public int health;
        public int money;

        public NormalEnemies(int newId, string newEnemyName, int newHealth, int newMoney)
        {
            id = newId;
            enemyName = newEnemyName;
            health = newHealth;
            money = newMoney;
        }
    }

    [System.Serializable]
    public class NormalEnemiesMoves
    {
        public int enemyId;
        public string moveName;
        public string description;
        public string type;
        public int cost;
        public int value;

        public NormalEnemiesMoves(int newEnemyId, string newMoveName, string newDescription, string newType, int newCost, int newValue)
        {
            enemyId = newEnemyId;
            moveName = newMoveName;
            description = newDescription;
            type = newType;
            cost = newCost;
            value = newValue;
        }
    }
    
    public List<NormalEnemies> normalEnemiesList = new List<NormalEnemies>();
    public List<NormalEnemiesMoves> normalEnemiesMovesList = new List<NormalEnemiesMoves>();

    private void Awake() {
        
        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(1, "Imp", 25, 100));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Kly",   "Imp uzywa kiel!",      "Atak",     0, 4));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Krzyk", "Imp uzywa krzyku!",    "Atak",     0, 4));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Unik",  "Imp uzywa uniku!",     "Obrona",   0, 3));

        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(2, "Zombie", 20, 100));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(2, "Ugryzienie", "Zombie uzywa poteznego ugryzienia!", "Atak", 0, 5));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(2, "Ugryzienie", "Zombie uzywa ugryzienia!", "Atak", 0, 3));

        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(3, "Szczur", 15, 100));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(3, "Ugryzienie",    "Szczur uzywa ugryzienia!", "Atak",     0, 4));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(3, "Unik",          "Szczur uzywa uniku!",      "Obrona",   0, 4));

        startingId = normalEnemiesList[0].id;

        // for(int i = 0; i < normalEnemiesList.Count; i++)
        // {
        //     Debug.Log(normalEnemiesList[i].id + " " + normalEnemiesList[i].enemyName + " " + normalEnemiesList[i].health);
        // }

        // for(int i = 0; i < normalEnemiesMovesList.Count; i++)
        // {
        //     Debug.Log(normalEnemiesMovesList[i].enemyId + " " + normalEnemiesMovesList[i].moveName + " " + 
        //     normalEnemiesMovesList[i].description + " " + normalEnemiesMovesList[i].type + " " + 
        //     normalEnemiesMovesList[i].cost + " " + normalEnemiesMovesList[i].value);
        // }
    }
}