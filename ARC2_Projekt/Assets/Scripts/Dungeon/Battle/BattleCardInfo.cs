using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardInfo : MonoBehaviour
{
    public BattleHandler battleHandler;

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
            }
        }
        else if(this.type == "Obrona")
        {
            battleHandler.currentPlayerHealth -= healthPoints;
            battleHandler.playerHealthText.text = battleHandler.currentPlayerHealth.ToString() + "/" + battleHandler.playerMaxHealth;
            battleHandler.currentPlayerDefence += points;
            battleHandler.playerDefenceText.text = "Shield: " + battleHandler.currentPlayerDefence.ToString();
            battleHandler.remainingMoves--;
        }
    }

    public void HideBattleCard()
    {
        this.gameObject.SetActive(false);
    }
}
