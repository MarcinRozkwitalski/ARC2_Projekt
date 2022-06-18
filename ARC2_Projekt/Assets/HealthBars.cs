using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    public BattleHandler battleHandler;

    public Image playerHealthBar;
    public Image enemyHealthBar;

    public float currentPlayerHealth;
    public float currentEnemyHealth;

    public float currentPlayerMaxHealth;
    public float currentEnemyMaxHealth;

    private void Update() {
        currentPlayerHealth = battleHandler.currentPlayerHealth;
        currentEnemyHealth = battleHandler.currentEnemyHealth;

        currentPlayerMaxHealth = battleHandler.playerMaxHealth;
        currentEnemyMaxHealth = battleHandler.currentEnemyMaxHealth;

        playerHealthBar.fillAmount = currentPlayerHealth/currentPlayerMaxHealth;
        enemyHealthBar.fillAmount = currentEnemyHealth/currentEnemyMaxHealth;
    }
}   