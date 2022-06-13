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

        public NormalEnemies(int newId, string newEnemyName, int newHealth)
        {
            id = newId;
            enemyName = newEnemyName;
            health = newHealth;
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
        
        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(1, "Imp", 25));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Kly",   "Imp uzywa kiel!",      "Atak",     2, 4));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Krzyk", "Imp uzywa krzyku!",    "Atak",     1, 4));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(1, "Unik",  "Imp uzywa uniku!",     "Obrona",   1, 3));

        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(2, "Zombie", 20));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(2, "Ugryzienie", "Zombie uzywa ugryzienia!", "Atak", 5, 5));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(2, "Ugryzienie", "Zombie uzywa ugryzienia!", "Atak", 4, 3));

        normalEnemiesList.Add(new NormalEnemiesList.NormalEnemies(3, "Szczur", 15));
        normalEnemiesMovesList.Add(new NormalEnemiesList.NormalEnemiesMoves(3, "Ugryzienie",    "Szczur uzywa ugryzienia!", "Atak",     2, 4));
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