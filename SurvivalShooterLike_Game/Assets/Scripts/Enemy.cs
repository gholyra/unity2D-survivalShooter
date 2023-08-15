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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Player.instance.playerTransform.position;
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }
}
