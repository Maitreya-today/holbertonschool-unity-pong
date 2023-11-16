using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle paddle;  // Assuming your player paddle script is named Paddle.cs

    public float difficultyFactor = 1.0f;  // Adjust this based on difficulty settings

    void Start()
    {
        FindPlayerPaddle();
        DisableIfPlayerExists();
    }

    void FixedUpdate()
    {
        // Track the ball's Y position
        float targetY = Ball.Instance.transform.position.y;

        // Adjust the paddle's Y position based on the ball's position with some randomness
        float yOffset = Random.Range(-0.5f, 0.5f) * difficultyFactor;
        float newY = Mathf.Lerp(transform.position.y, targetY + yOffset, Time.deltaTime * difficultyFactor);

        // Apply the new Y position to the paddle
        transform.position = new Vector2(transform.position.x, newY);
    }

    void FindPlayerPaddle()
    {
        // Find the player paddle in the parent object
        paddle = GetComponentInParent<Paddle>();
    }

    void DisableIfPlayerExists()
    {
        // Check if the player script is present in the parent object
        Player player

