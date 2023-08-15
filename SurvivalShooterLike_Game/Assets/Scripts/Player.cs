using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance;

    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 3;

    private Animator animator;
    public Transform playerTransform { get; private set; }

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else
        { 
            Destroy(this.gameObject);
        }
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, moveY, 0f);
        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
    }

}
