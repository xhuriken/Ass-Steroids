using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public Vector2 target = Vector2.zero;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rb = GetComponent<Rigidbody2D>();

        // Get Mouse Pos
        

        Vector2 playerPos = GameManager.Instance.Player.transform.position;

        // get dir (destination - target) and normalize !
        Vector2 dirToPlayer = (playerPos - (Vector2)transform.position).normalized;

        // GO GO GO !
        rb.linearVelocity = dirToPlayer * speed;
    }
}
