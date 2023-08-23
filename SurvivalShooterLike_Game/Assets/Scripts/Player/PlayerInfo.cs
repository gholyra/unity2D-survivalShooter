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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Handlers
    private void LifeHandler()
    {
        isHurt = true;
        playerLives--;
        if (playerLives <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeHandler();
    }

    public float GetPlayerVelocity()
    {
        return this.playerVelocity;
    }

}
