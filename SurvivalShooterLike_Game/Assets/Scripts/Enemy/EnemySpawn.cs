using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;
    [SerializeField] GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(enemyPrefab, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
    }
}
