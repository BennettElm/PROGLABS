using UnityEngine;

public class NEWENEMYCHASE : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10.0f;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 5.0f;
    public float rotationSpeed = 10.0f;
    public float waitTime = 2.0f;
    public float patrolRadius = 10.0f;

    private Vector3 destination;
    private float patrolTimer;
    private bool isWaiting;

    private void Start()
    {
        SetNewDestination();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseDistance)
        {
            ChasePlayer();
        }
        else if (isWaiting)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer >= waitTime)
            {
                SetNewDestination();
                isWaiting = false;
                patrolTimer = 0.0f;
            }
        }
        else if (Vector3.Distance(transform.position, destination) <= 0.1f)
        {
            isWaiting = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, patrolSpeed * Time.deltaTime);

            Vector3 direction = (destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            SetNewDestination();
        }
        else
        {
            transform.position += transform.forward * chaseSpeed * Time.deltaTime;
        }
    }

    private void SetNewDestination()
    {
        float randomAngle = Random.Range(0.0f, 360.0f);
        Vector3 randomDirection = Quaternion.Euler(0.0f, randomAngle, 0.0f) * Vector3.forward;
        destination = transform.position + randomDirection * patrolRadius;
    }
}
