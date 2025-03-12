using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb;
    [SerializeField] private MovementStats stats;  

    private Vector2 direction;
    private Vector2 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.D)) 
        {
            direction.x = 1f;
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            direction.x = -1f;
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            direction.y = 1f;
        }

        if (Input.GetKey(KeyCode.S)) 
        {
            direction.y = -1f;
        }

       
    }

    void FixedUpdate()
    {
        
        MovePlayer();
    }


    void MovePlayer()
    {
        if (direction != Vector2.zero)
        {
            direction.Normalize();

            currentVelocity = Vector2.MoveTowards(currentVelocity, direction * stats.maxSpeed, stats.acceleration * Time.fixedDeltaTime);

            rb.velocity = currentVelocity;
        }
        else
        {
            ApplyFriction();
        }
    }

    void ApplyFriction()
    {
        if (rb.velocity.x > 0)
            rb.velocity = new Vector2(rb.velocity.x - stats.friction * Time.deltaTime, rb.velocity.y);
        else if (rb.velocity.x < 0)
            rb.velocity = new Vector2(rb.velocity.x + stats.friction * Time.deltaTime, rb.velocity.y);

        if (rb.velocity.y > 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - stats.friction * Time.deltaTime);
        else if (rb.velocity.y < 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + stats.friction * Time.deltaTime);
    }

    public void UpdateStats(MovementStats newStats)
    {
        stats = newStats;
    }
}
