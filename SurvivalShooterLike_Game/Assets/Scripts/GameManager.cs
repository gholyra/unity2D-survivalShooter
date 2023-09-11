using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int gameScore { get; private set; } 
    public int playerLives { get; private set; } 

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
             Destroy(this.gameObject);
        }
        #endregion
    }

    public Vector3 GetMousePosition() 
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    public void SetGameScore(int score)
    {
        this.gameScore += score;
        PlayerInfo.instance.SetCurrentXP(score);
        UIManager.instance.SetScoreText(this.gameScore);
    }

    public void SetPlayerLife(int life)
    {
        this.playerLives = life;
        UIManager.instance.SetLivesText(this.playerLives);
    }

    public void SetPlayerLevel(int currentPlayerLevel, int currentXP, int toLevelUpXP)
    {
        UIManager.instance.SetXPInfoText(currentXP, toLevelUpXP);
        UIManager.instance.SetPlayerLevelText(currentPlayerLevel);
    }

    public void OnLevelUp()
    {
        Time.timeScale = 0;
        UIManager.instance.SetPowerUpContainer(true);
        if (EnemySpawn.instance.GetTimeToSpawn() >= 1f)
        {
            EnemySpawn.instance.SubtractTimeToSpawn(0.010f);
        }
    }
}
