using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public static PlayerInfo instance;

    [SerializeField] private int playerLives = 3;
    [SerializeField] private float playerVelocity = 10;
    
    public Animator playerAnimator { get; private set; }

    public Transform playerTransform { get; set; }

    public SpriteRenderer spriteRenderer { get; private set; }

    public bool isMoving { get; set; }
    public bool isHurt { get; set; }
    public int playerLevel { get; private set; } = 0;
    public int currentPlayerXP { get; set; } = 0;
    public int toLevelUpXP { get; set; } = 5;

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
        playerTransform = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameManager.instance.SetPlayerLife(playerLives);
        GameManager.instance.SetNewXPInfo(playerLevel, currentPlayerXP, toLevelUpXP);
    }

    #region Handlers
    private void LifeHandler()
    {
        isHurt = true;
        playerLives--;
        GameManager.instance.SetPlayerLife(playerLives);
        if (playerLives <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
            LifeHandler();
    }

    public float GetPlayerVelocity()
    {
        return this.playerVelocity;
    }

    public void SetCurrentXP(int xpToAdd)
    {
        currentPlayerXP += xpToAdd;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if (currentPlayerXP >= toLevelUpXP)
        {
            playerLevel++;
            currentPlayerXP -= toLevelUpXP;
            toLevelUpXP += 5;
        }
        GameManager.instance.SetNewXPInfo(playerLevel, currentPlayerXP, toLevelUpXP);
    }
}
