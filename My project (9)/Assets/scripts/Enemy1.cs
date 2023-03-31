using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // The player pos
    public static Vector3 playerPosition;

    // The enemy speed
    public float speed = 5f;

    // Singleton
    public static Enemy1 instance;

    private void Awake()
    {
        // Use the Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check player positio
        if (playerPosition != null)
        {
            // Move toward player
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        }
    }
}

