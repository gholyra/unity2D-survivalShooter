using JetBrains.Annotations;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 3;

    public Animator animator { get; private set; }
    public Transform playerTransform { get; private set; }
    public bool isMoving { get; private set; }
    public bool isHurt { get; private set; }

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
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        MoveHandler();
        LifeHandler();
        AnimationHandler();
    }

    #region Handlers
    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, moveY, 0f);
        isMoving = moveX != 0 || moveY != 0;
    }

    private void LifeHandler()
    {
        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void AnimationHandler()
    {
        bool isMovingAnimation = animator.GetBool("isMoving");
        bool isHurtAnimation = animator.GetBool("isHurt");

        if (isMoving && !isMovingAnimation)
        {
            animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnimation)
        {
            animator.SetBool("isMoving", false);
        }

        if (isHurt && !isHurtAnimation)
        {
            animator.SetBool("isHurt", true);
            isHurt = false;
        }
        else if (!isHurt && isHurtAnimation)
        {
            animator.SetBool("isHurt", true);
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHurt = true;
        lives--;
    }

}
