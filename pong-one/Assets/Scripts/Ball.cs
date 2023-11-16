using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    void Start()
    {
        // Initialize the ball's direction
        direction = new Vector2(1, 0).normalized;
    }

    void Update()
    {
        // Move the ball
        transform.Translate(direction * speed * Time.deltaTime);

        // Check for collisions with paddles
        CheckPaddleCollision();
    }

    void CheckPaddleCollision()
    {
        // Use this to check for collisions with the paddles
        // You can replace "Player One" and "Player Two" with your actual paddle GameObject names
        GameObject playerOne = GameObject.Find("Player One");
        GameObject playerTwo = GameObject.Find("Player Two");

        if (playerOne != null && playerTwo != null)
        {
            Collider2D playerOneCollider = playerOne.GetComponent<Collider2D>();
            Collider2D playerTwoCollider = playerTwo.GetComponent<Collider2D>();

            if (playerOneCollider.bounds.Intersects(GetComponent<Collider2D>().bounds))
            {
                // Calculate rebound angle based on the sweet spot effect
                float hitPoint = transform.position.y - playerOne.transform.position.y;
                float normalizedHitPoint = hitPoint / (playerOneCollider.bounds.size.y / 2f);

                direction = new Vector2(1, normalizedHitPoint).normalized;
            }
            else if (playerTwoCollider.bounds.Intersects(GetComponent<Collider2D>().bounds))
            {
                // Similar calculations for Player Two's paddle
                float hitPoint = transform.position.y - playerTwo.transform.position.y;
                float normalizedHitPoint = hitPoint / (playerTwoCollider.bounds.size.y / 2f);

                direction = new Vector2(-1, normalizedHitPoint).normalized;
            }
        }
    }
}