using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;

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
    }

    public void SetScoreText(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore;
    }

    public void SetLivesText(int updatedLife)
    {
        livesText.text = "Lifes: " + updatedLife;
    }
}