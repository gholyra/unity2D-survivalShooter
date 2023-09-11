using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public static EnemySpawn instance;

    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeToSpawn = 1.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies(timeToSpawn));
    }

    public float GetTimeToSpawn()
    {
        return timeToSpawn;
    } 
    
    public void SubtractTimeToSpawn(float value)
    {
        timeToSpawn -= value;
    }

    private IEnumerator SpawnEnemies(float timeToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawn);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(enemyPrefab, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }
}
