using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float velocity = 6;

    private int lives;

    private Transform enemyTransform;
    private Vector2 targetPosition;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    void Update()
    {
        targetPosition = PlayerInfo.instance.playerTransform.position;
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            GameManager.instance.SetGameScore(1);
            Destroy(this.gameObject);
        }
    }

}
