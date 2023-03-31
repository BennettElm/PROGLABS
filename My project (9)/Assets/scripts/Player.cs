using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        
        Enemy1.playerPosition = transform.position;
    }
}

