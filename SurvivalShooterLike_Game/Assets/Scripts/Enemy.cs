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

    void Start()
    {

    }

    void Update()
    {
        targetPosition = PlayerInfo.instance.playerTransform.position;
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }
}
