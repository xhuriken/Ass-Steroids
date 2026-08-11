using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public Vector2 target = Vector2.zero;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector2 mousePos;
    Vector2 dirToMouse;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Get Mouse Pos
        Vector2 mousePos = MouseManager.Instance.MousePos;

        // get dir (destination - target) and normalize !
        Vector2 dirToMouse = (mousePos - (Vector2)transform.position).normalized;

        // GO GO GO !
        rb.linearVelocity = dirToMouse * speed;
        Destroy(this.gameObject, 1.5f);
    }
}
