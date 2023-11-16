using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle paddle;  // Assuming your player paddle script is named Paddle.cs

    void Start()
    {
        FindPlayerPaddle();
        DisableIfPlayerExists();
    }

    void FindPlayerPaddle()
    {
        // Find the player paddle in the parent object
        paddle = GetComponentInParent<Paddle>();
    }

    void DisableIfPlayerExists()
    {
        // Check if the player script is present in the parent object
        Player player = paddle.GetComponent<Player>();
        
        if (player != null)
        {
            // If player script is present, disable it
            player.enabled = false;
        }
    }

    // Add your AI logic for paddle movement here

    // You might want to use FixedUpdate for physics-related updates
    void FixedUpdate()
    {
        // Add your AI logic for paddle movement based on ball position
    }
}
