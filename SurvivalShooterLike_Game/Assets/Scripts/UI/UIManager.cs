using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [Header ("Containers")]
    [SerializeField] private Transform powerUpContainer;

    [Header ("Top View Text")]
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI xpInfoText;
    [SerializeField] private TextMeshProUGUI currentLevelText;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Another UI instance is active.");
            Destroy(this.gameObject);
        }
        #endregion
        SetupUI();
    }

    private void SetupUI()
    {
        livesText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        SetPowerUpContainer(false);
    }

    public void SetPowerUpContainer(bool isActive)
    {
        powerUpContainer.gameObject.SetActive(isActive);
    }

    public void SetScoreText(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetLivesText(int updatedLife)
    {
        livesText.text = "Lifes: " + updatedLife;
    }

    public void SetXPInfoText(int currentXP, int toLevelUpXP)
    {
        xpInfoText.text = "XP: " + currentXP + "/" + toLevelUpXP;
    }

    public void SetPlayerLevelText(int currentPlayerLevel)
    {
        currentLevelText.text = "Level: " + currentPlayerLevel;
    }
}
