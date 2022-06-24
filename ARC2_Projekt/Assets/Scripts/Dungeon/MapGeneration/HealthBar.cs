using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TempCurrentPlayer tempCurrentPlayer;

    public Image playerHealthBar;

    public TMP_Text PlayerHealthText;

    public float currentPlayerHealth;
    public float currentPlayerMaxHealth = 100;
    
    private void Start() {
        tempCurrentPlayer = GameObject.Find("PlayerManager").GetComponent<TempCurrentPlayer>();
    }

    private void Update() {
        currentPlayerHealth = tempCurrentPlayer.TempPlayerLife;
        PlayerHealthText.text = currentPlayerHealth.ToString() + "/" + currentPlayerMaxHealth;
        playerHealthBar.fillAmount = currentPlayerHealth/currentPlayerMaxHealth;
    }
}   